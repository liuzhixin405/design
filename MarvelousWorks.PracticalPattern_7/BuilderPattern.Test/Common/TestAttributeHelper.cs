using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Common;
using System.Reflection;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Test.Common
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple=true)]
    class CustomAttribute : Attribute { }

    [Custom]
    class ClassWithAttribute
    {
        [Custom]
        public void Method1() { }

        [Custom]
        [Custom]
        public void Method2() { }
    }

    [TestClass]
    public class TestAttributeHelper
    {
        private Type classType = typeof(ClassWithAttribute);
        private IList<MethodInfo> methods =
            AttributeHelper.GetMethodsWithCustomAttribute<CustomAttribute>(typeof(ClassWithAttribute));

        [TestMethod]
        public void TestGetCustomAttributes()
        {
            IList<CustomAttribute> attributes =
                AttributeHelper.GetCustomAttributes<CustomAttribute>(classType);
            Assert.IsTrue(attributes.Count > 0);
        }

        [TestMethod]
        public void TestGetMethodsWithCustomAttribute()
        {
            Assert.AreEqual<int>(2, methods.Count);
        }

        [TestMethod]
        public void TestGetMethodCustomAttribute()
        {
            CustomAttribute attribute =
                AttributeHelper.GetMethodCustomAttribute<CustomAttribute>(methods[0]);
            Assert.IsNotNull(attribute);
        }

        [TestMethod]
        public void TestGetMethodCustomAttributes()
        {
            IList<CustomAttribute> attributes =
                AttributeHelper.GetMethodCustomAttributes<CustomAttribute>(methods[1]);
            Assert.AreEqual<int>(2, attributes.Count);
        }
    }
}
