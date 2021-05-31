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
        /// ��������а�Proxy��Ҫ������������ʵ��Ŀ�����ʵ��Attach��һ��
        /// </summary>
        /// <param name="subject"></param>
        public CustomProxy(T target) : base(target.GetType()) { AttachServer(target); }

        /// <summary>
        /// �������������proxy��Ŀ�����ʵ����Attach������GC���ա�
        /// </summary>
        public void Dispose() { DetachServer(); }

        public static T Create(T target)
        {
            if (target == null) throw new ArgumentNullException("target");
            return (T)(new CustomProxy<T>(target).GetTransparentProxy());
        }

        /// <summary>
        /// ʵ��ִ�е����أ�������װ�����Խ��ж��ƴ���
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public override IMessage Invoke(IMessage msg)
        {
            MethodCallMessageWrapper caller =
                new MethodCallMessageWrapper((IMethodCallMessage)msg);
            // ��ȡʵ����������
            MethodInfo method = (MethodInfo)caller.MethodBase;
            T target = (T)GetUnwrappedServer();
            if (target == null) return msg;

            DecoratorAttributeBase[] attributes = (DecoratorAttributeBase[])
                method.GetCustomAttributes(typeof(DecoratorAttributeBase), true);
            if (attributes.Length > 0)
                foreach (DecoratorAttributeBase attribute in attributes)
                    attribute.Intercept(caller);
            object ret = method.Invoke(target, caller.Args);
            // ���ش���󣬼����ص���������ĵ��ù���
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

        [ArgumentTypeRestriction(typeof(string))]   // �ṩ�������
        [ArgumentNotEmpty()]                        // �ṩ�������
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
            user.SetUserInfo("joe", "manager"); // �ɹ�
            try
            {
                user.SetUserInfo(20, "manager");
            }
            catch (Exception exception)
            {
                // ���һ�����������쳣�����غ��׳��쳣
                Assert.AreEqual<string>("0", exception.Message);
            }
            try
            {
                user.SetUserInfo("", "manager"); 
            }
            catch (Exception exception)
            {
                // ��nameΪ�ձ����غ��׳��쳣
                Assert.AreEqual<string>("string is null or empty", exception.Message);
            }
        }
    }
}
