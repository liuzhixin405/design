using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarvellousWorks.PracticalPattern.DecoratorPattern.Interception
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
    abstract class DecoratorAttributeBase : Attribute
    {
        public abstract void Intercept(object target);
    }

    class CustomProxy<T> : RealProxy, IDisposable
        where T : MarshalByRefObject
    {
        /// <summary>
        /// 构造过程中把Proxy需要操作的内容与实际目标对象实例Attach到一起。
        /// </summary>
        /// <param name="subject"></param>
        public CustomProxy(T target) : base(target.GetType()) { AttachServer(target); }

        /// <summary>
        /// 析构过程则借助proxy和目标对象实例的Attach，便于GC回收。
        /// </summary>
        public void Dispose() { DetachServer(); }

        public static T Create(T target)
        {
            if (target == null) throw new ArgumentNullException("target");
            return (T)(new CustomProxy<T>(target).GetTransparentProxy());
        }

        /// <summary>
        /// 实际执行的拦截，并根据装饰属性进行定制处理。
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public override IMessage Invoke(IMessage msg)
        {
            MethodCallMessageWrapper caller =
                new MethodCallMessageWrapper((IMethodCallMessage)msg);
            // 提取实际宿主对象
            MethodInfo method = (MethodInfo)caller.MethodBase;
            T target = (T)GetUnwrappedServer();
            if (target == null) return msg;

            DecoratorAttributeBase[] attributes = (DecoratorAttributeBase[])
                method.GetCustomAttributes(typeof(DecoratorAttributeBase), true);
            if (attributes.Length > 0)
                foreach (DecoratorAttributeBase attribute in attributes)
                    attribute.Intercept(caller);
            object ret = method.Invoke(target, caller.Args);
            // 拦截处理后，继续回到宿主对象的调用过程
            return new ReturnMessage(ret, caller.Args, caller.ArgCount,
                caller.LogicalCallContext, caller);
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    class ArgumentTypeRestrictionAttribute : DecoratorAttributeBase
    {
        private Type type;
        public ArgumentTypeRestrictionAttribute(Type type) { this.type = type; }

        public override void Intercept(object target)
        {
            MethodCallMessageWrapper caller = (MethodCallMessageWrapper)target;
            if (caller.ArgCount == 0) return;
            for (int i = 0; i < caller.ArgCount; i++)
            {
                object arg = caller.Args[i];
                if ((arg.GetType() != type) && (!arg.GetType().IsAssignableFrom(type)))
                    throw new ArgumentException(i.ToString());
            }
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    class ArgumentNotEmptyAttribute : DecoratorAttributeBase
    {
        public override void Intercept(object target)
        {
            MethodCallMessageWrapper caller = (MethodCallMessageWrapper)target;
            if (caller.ArgCount == 0) return;
            foreach (object arg in caller.Args)
                if (string.IsNullOrEmpty((string)arg))
                    throw new ArgumentException("string is null or empty");
        }
    }

    class User : MarshalByRefObject
    {
        private string name;
        private string title;

        [ArgumentTypeRestriction(typeof(string))]   // 提供拦截入口
        [ArgumentNotEmpty()]                        // 提供拦截入口
        public void SetUserInfo(object name, object title)
        {
            this.name = (string)name;
            this.title = (string)title;
        }
    }

    [TestClass]
    public class TestInterception
    {

        [TestMethod]
        public void Test()
        {
            User user = CustomProxy<User>.Create(new User());
            user.SetUserInfo("joe", "manager"); // 成功
            try
            {
                user.SetUserInfo(20, "manager");
            }
            catch (Exception exception)
            {
                // 因第一个参数类型异常被拦截后抛出异常
                Assert.AreEqual<string>("0", exception.Message);
            }
            try
            {
                user.SetUserInfo("", "manager"); 
            }
            catch (Exception exception)
            {
                // 因name为空被拦截后抛出异常
                Assert.AreEqual<string>("string is null or empty", exception.Message);
            }
        }
    }
}
