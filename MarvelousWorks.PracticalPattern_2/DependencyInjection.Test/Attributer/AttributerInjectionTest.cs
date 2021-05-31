using System;
using MarvellousWorks.PracticalPattern.Concept.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MarvellousWorks.PracticalPattern.Concept.DependencyInjection.Test.Attributer
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true)]
    sealed class DecoratorAttribute : Attribute
    {
        /// <summary>
        /// 实现客户类型实际需要的抽象类型的实体类型实例，即带注入到客户类型的内容
        /// </summary>
        public readonly object Injector;
        private Type type;

        public DecoratorAttribute(Type type) 
        {
            if (type == null) throw new ArgumentNullException("type");
            this.type = type;
            Injector = (new Assembler()).Create(this.type);
        }

        /// <summary>
        /// 客户类型需要的抽象对象类型
        /// </summary>
        public Type Type { get { return this.type; } }
    }

    /// <summary>
    /// 用户帮助客户类型和客户程序获取其Attribute定义中需要的抽象类型实例
    /// </summary>
    static class AttributeHelper
    {
        public static T Injector<T>(object target)
            where T : class
        {
            if (target == null) throw new ArgumentNullException("target");
            Type targetType = target.GetType();
            object[] attributes = targetType.GetCustomAttributes(typeof(DecoratorAttribute), false);
            if ((attributes == null) || (attributes.Length <= 0)) return null ;
            foreach (DecoratorAttribute attribute in (DecoratorAttribute[])attributes)
                if (attribute.Type == typeof(T))
                    return (T)attribute.Injector;
            return null;
        }
    }

    [Decorator(typeof(ITimeProvider))]
    class Client
    {
        public int GetYear()
        {
            // 与其他方式注入不同的是，这里使用的ITimeProvider来自自己的Attribute
            ITimeProvider provider = AttributeHelper.Injector<ITimeProvider>(this);
            return provider.CurrentDate.Year;
        }
    }

    [TestClass]
    public class TestClient
    {
        [TestMethod]
        public void Test()
        {
            Client client = new Client();
            Assert.IsTrue(client.GetYear() > 0);
        }
    }
}
