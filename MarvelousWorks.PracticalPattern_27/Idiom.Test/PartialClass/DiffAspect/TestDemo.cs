using System;
using System.Collections.Generic;
using System.ServiceModel;
using MarvellousWorks.PracticalPattern.Idiom.PartialClass.DiffAspect;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MarvellousWorks.PracticalPattern.Idiom.Test.PartialClass.DiffAspect
{
    [TestClass]
    public class TestDemo
    {
        /// <summary>
        /// �ж�ĳ�������Ƿ���б�עΪ�ƶ���attribute
        /// </summary>
        /// <param name="targetType"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        private bool HasAttribute(Type targetType, Type attributeType)
        {
            if ((targetType == null) || (attributeType == null)) 
                throw new ArgumentNullException("type");
            if (!typeof(Attribute).IsAssignableFrom(attributeType)) 
                throw new Exception("not an attribute type");
            object[] attributes = targetType.GetCustomAttributes(attributeType, false);
            return ((attributes == null) || (attributes.Length == 0)) ? false : true;
        }

        /// <summary>
        /// �ֲ�ʵ�ֲ���Ӱ��ͻ������ʹ��
        /// </summary>
        [TestMethod]
        public void Test()
        {
            Assert.IsTrue(HasAttribute(typeof(C), typeof(PerformanceAttribute)));
            Assert.IsTrue(HasAttribute(typeof(C), typeof(PersistenceAttribute)));
            Assert.IsTrue(HasAttribute(typeof(C), typeof(SecurityAttribute)));
        }
    }
}

