using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.AbstractFactory.ComplexHierarchy;
namespace AbstractFactory.Test.ComplexHierarchy
{
    [TestClass]
    public class TestAbstractFactory
    {
        [TestMethod]
        public void Test()
        {
            IAbstarctFactoryWithTypeMapper factory = new ConcreteFactoryX();
            AssemblyMechanism.Assembly(factory);    // ∞Û∂®TypeMapper
            IProductXB productXB = factory.Create<IProductXB>();
            Assert.IsNotNull(productXB);
            Assert.AreEqual<Type>(typeof(ProductXB1), productXB.GetType());

            // ≤‚ ‘¡Ì“ª∏ˆAbstract Factory
            factory = new ConcreteFactoryY();
            AssemblyMechanism.Assembly(factory);
            IProductYC productYC = factory.Create<IProductYC>();
            Assert.IsNotNull(productYC);
            Assert.AreEqual<Type>(typeof(ProductYC1), productYC.GetType());
        }
    }
}
