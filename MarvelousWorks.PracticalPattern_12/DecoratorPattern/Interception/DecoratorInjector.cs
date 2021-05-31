using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
namespace MarvellousWorks.PracticalPattern.DecoratorPattern.Interception
{
    public delegate object MethodCall(object target, MethodBase method,
        object[] parameters, DecoratorAttribute[] attributes);

    public class DecoratorInjector
    {
        public const string AssemblyName = "TEMP_DYNAMIC_ASSEMBLY";
        public const string ClassName = "TEMP_CLASS_NAME";
        private static TypeBuilder typeBuilder;
        private static FieldBuilder target, iface;

        public static object InjectHandlerMethod(object target, MethodBase method,
            object[] parameters, DecoratorAttribute[] attributes)
        {
            object returnValue = null;
            foreach (DecoratorAttribute attribute in attributes)
                if (attribute is BeforeDecoratorAttribute)
                    attribute.Process(target, method, parameters);
            returnValue = target.GetType().GetMethod(method.Name).Invoke(target, parameters);
            foreach (DecoratorAttribute attribute in attributes)
                if (attribute is AfterDecoratorAttribute)
                    attribute.Process(target, method, parameters);
            return returnValue;
        }

        public static object Create(object target, Type interfaceType)
        {
            Type proxyType = EmiProxyType(target.GetType(), interfaceType);
            return Activator.CreateInstance(proxyType, new object[] { target, interfaceType });
        }

        private static Type EmiProxyType(Type targetType, Type interfaceType)
        {
            AppDomain currentDomain = System.Threading.Thread.GetDomain();
            AssemblyName assemblyName = new AssemblyName();
            assemblyName.Name = AssemblyName;
            AssemblyBuilder assemblyBuilder =
                currentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder modBuilder = assemblyBuilder.DefineDynamicModule(ClassName);

            string typeName = assemblyName + "__Proxy" + interfaceType.Name + targetType.Name;
            Type type = modBuilder.GetType(typeName);
            if (type == null)
            {
                typeBuilder = modBuilder.DefineType(typeName, TypeAttributes.Class | TypeAttributes.Public,
                    targetType.BaseType, new Type[] { interfaceType });
                target = typeBuilder.DefineField("target", interfaceType, FieldAttributes.Private);
                iface = typeBuilder.DefineField("iface", typeof(Type), FieldAttributes.Private);
                EmitConstructor(typeBuilder, target, iface);
                MethodInfo[] methods = interfaceType.GetMethods();
                foreach (MethodInfo m in methods)
                    EmitProxyMethod(m, typeBuilder);
                type = typeBuilder.CreateType();
            }
            return type;
        }

        private static void EmitProxyMethod(MethodInfo method, TypeBuilder typeBuilder)
        {
            // 1、定义动态 IL 生成对象
            Type[] paramTypes = GetParameterTypes(method);
            MethodBuilder methodBuilder = typeBuilder.DefineMethod(method.Name,
                MethodAttributes.Public | MethodAttributes.Virtual, method.ReturnType, paramTypes);
            ILGenerator il = methodBuilder.GetILGenerator();
            LocalBuilder parameters = il.DeclareLocal(typeof(object[]));
            il.Emit(OpCodes.Ldc_I4, paramTypes.Length);
            il.Emit(OpCodes.Newarr, typeof(object));
            il.Emit(OpCodes.Stloc, parameters);
            for (int i = 0; i < paramTypes.Length; i++)
            {
                il.Emit(OpCodes.Ldloc, parameters);
                il.Emit(OpCodes.Ldc_I4, i);
                il.Emit(OpCodes.Ldarg, i + 1);
                if (paramTypes[i].IsValueType)
                    il.Emit(OpCodes.Box, paramTypes[i]);
                il.Emit(OpCodes.Stelem_Ref);
            }
            il.EmitCall(OpCodes.Callvirt,
                typeof(DecoratorInjector).GetProperty("InjectHandler").GetGetMethod(), null);

            // 2、生成目标对象实例
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, (FieldInfo)target);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, (FieldInfo)target);
            il.EmitCall(OpCodes.Call, typeof(object).GetMethod("GetType"), null);
            il.EmitCall(OpCodes.Call, typeof(MethodBase).GetMethod("GetCurrentMethod"), null);

            // 3、生成目标对象方法
            il.EmitCall(OpCodes.Call, typeof(DecoratorInjector).GetMethod("GetMethod"), null);

            // 4、生成参数
            il.Emit(OpCodes.Ldloc, parameters);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, (FieldInfo)iface);
            il.EmitCall(OpCodes.Call, typeof(MethodBase).GetMethod("GetCurrentMethod"), null);
            il.EmitCall(OpCodes.Call, typeof(DecoratorInjector).GetMethod("GetMethod"), null);
            il.Emit(OpCodes.Ldtoken, typeof(DecoratorAttribute));
            il.Emit(OpCodes.Call, typeof(Type).GetMethod("GetTypeFromHandle"));
            il.Emit(OpCodes.Ldc_I4, 1);
            il.EmitCall(OpCodes.Callvirt,
                typeof(MethodInfo).GetMethod("GetCustomAttributes",
                new Type[] { typeof(Type), typeof(bool) }), null);

            // 5、导入“横切”对象
            il.EmitCall(OpCodes.Callvirt, typeof(DecoratorInjector).GetMethod("UnionDecorators"), null);
            il.EmitCall(OpCodes.Callvirt, typeof(MethodCall).GetMethod("Invoke"), null);
            if (method.ReturnType == typeof(void))
                il.Emit(OpCodes.Pop);
            else if (method.ReturnType.IsValueType)
            {
                il.Emit(OpCodes.Unbox, method.ReturnType);
                il.Emit(OpCodes.Ldind_Ref);
            }
            il.Emit(OpCodes.Ret);
        }

        /// <summary>
        /// 通过动态生成的MSIL形成构造方法
        /// </summary>
        /// <param name="typeBuilder"></param>
        /// <param name="target"></param>
        /// <param name="iface"></param>
        private static void EmitConstructor(TypeBuilder typeBuilder, FieldBuilder target, FieldBuilder iface)
        {
            Type objType = Type.GetType("System.Object");
            ConstructorInfo objCtor = objType.GetConstructor(new Type[0]);
            ConstructorBuilder pointCtor = typeBuilder.DefineConstructor(MethodAttributes.Public,
                CallingConventions.Standard, new Type[] { typeof(object), typeof(Type) });

            ILGenerator ctorIL = pointCtor.GetILGenerator();
            ctorIL.Emit(OpCodes.Ldarg_0);
            ctorIL.Emit(OpCodes.Call, objCtor);
            ctorIL.Emit(OpCodes.Ldarg_0);
            ctorIL.Emit(OpCodes.Ldarg_1);
            ctorIL.Emit(OpCodes.Stfld, target);
            ctorIL.Emit(OpCodes.Ldarg_0);
            ctorIL.Emit(OpCodes.Ldarg_2);
            ctorIL.Emit(OpCodes.Stfld, iface);
            ctorIL.Emit(OpCodes.Ret);
        }

        public static MethodCall InjectHandler
        {
            get { return new MethodCall(InjectHandlerMethod); }
        }

        public static Type[] GetParameterTypes(MethodInfo method)
        {
            if (method == null) return null;
            Type[] types = new Type[method.GetParameters().Length];
            int i = 0;
            foreach (ParameterInfo parameter in method.GetParameters())
                types[i++] = parameter.ParameterType;
            return types;
        }

        public static MethodInfo GetMethod(Type type, MethodBase method)
        {
            return type.GetMethod(method.Name);
        }

        public static DecoratorAttribute[] UnionDecorators(object[] obj)
        {
            return (DecoratorAttribute[])obj;
        }
    }
}
