using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Concept.Generics;
namespace MarvellousWorks.PracticalPattern.Concept.Test
{
    [TestClass()]
    public class RawGenericFactoryTest
    {
        interface IProduct { }
        class ConcreteProduct : IProduct { }

        [TestMethod]
        public void Test()
        {
            string typeName = typeof(ConcreteProduct).AssemblyQualifiedName;
            //IProduct product = RawGenericFactory.Create<IProduct>(typeName);
            //Assert.IsNotNull(product);
            //Assert.AreEqual<string>(typeName, product.GetType().AssemblyQualifiedName);

            IProduct product = new RawGenericFactory<IProduct>().Create(typeName);
            Assert.IsNotNull(product);
            Assert.AreEqual<string>(typeName, product.GetType().AssemblyQualifiedName);
        }
    }
}
