using System;
using MarvellousWorks.PracticalPattern.Concept.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MarvellousWorks.PracticalPattern.Concept.DependencyInjection.Test.Attributer
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true)]
    sealed class DecoratorAttribute : Attribute
    {
        /// <summary>
        /// ʵ�ֿͻ�����ʵ����Ҫ�ĳ������͵�ʵ������ʵ��������ע�뵽�ͻ����͵�����
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
        /// �ͻ�������Ҫ�ĳ����������
        /// </summary>
        public Type Type { get { return this.type; } }
    }

    /// <summary>
    /// �û������ͻ����ͺͿͻ������ȡ��Attribute��������Ҫ�ĳ�������ʵ��
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
            // ��������ʽע�벻ͬ���ǣ�����ʹ�õ�ITimeProvider�����Լ���Attribute
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
