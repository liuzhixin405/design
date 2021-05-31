using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.Concept.DependencyInjection
{
    public class Assembler
    {
        /// <summary>
        /// 保存“抽象类型/实体类型”对应关系的字典
        /// </summary>
        private static Dictionary<Type, Type> dictionary = new Dictionary<Type, Type>();

        static Assembler()
        {
            // 注册抽象类型需要使用的实体类型
            // 实际的配置信息可以从外层机制获得,例如通过配置定义.
            dictionary.Add(typeof(ITimeProvider), typeof(SystemTimeProvider));
        }

        /// <summary>
        /// 根据客户程序需要的抽象类型选择相应的实体类型，并返回类型实例
        /// </summary>
        /// <typeparam name="T">抽象类型（抽象类/接口/或者某种基类）</typeparam>
        /// <returns>实体类型实例</returns>
        public object Create(Type type)     // 主要用于非泛型方式调用
        {
            if ((type == null) || !dictionary.ContainsKey(type)) throw new NullReferenceException();
            Type targetType = dictionary[type];
            return Activator.CreateInstance(targetType);
        }

        /// <typeparam name="T">抽象类型（抽象类/接口/或者某种基类）</typeparam>
        public T Create<T>()    // 主要用于泛型方式调用
        {
            return (T)Create(typeof(T));
        }
    }
}
