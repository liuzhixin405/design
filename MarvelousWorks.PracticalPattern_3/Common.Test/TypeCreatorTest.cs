using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Common;
namespace MarvellousWorks.PracticalPattern.Common.Test
{
    [TestClass()]
    public class TypeCreatorTest
    {
        interface ITestType 
        {
            string Data { get;}
        }

        class TestType : ITestType
        {
            private string data;
            public TestType() { }
            public TestType(string data) { this.data = data; }
            public virtual string Data { get { return data; } }
        }

        [TestMethod]
        public void TestNoneParameterConstructor()
        {
            IObjectBuilder creator = new TypeCreator();
            Assert.IsInstanceOfType(creator.BuildUp<TestType>(), typeof(TestType));
        }

        [TestMethod]
        public void TestParameterizedConstructor()
        {
            IObjectBuilder creator = new TypeCreator();
            TestType actual = creator.BuildUp<TestType>(new object[] { "hello" });
            Assert.IsInstanceOfType(actual, typeof(TestType));
            Assert.AreEqual<string>("hello", actual.Data);
        }

        [TestMethod]
        public void TestNonParameterConstructorByTypeName()
        {
            IObjectBuilder creator = new TypeCreator();
            ITestType actual = creator.BuildUp<ITestType>(typeof(TestType).AssemblyQualifiedName);
            Assert.IsInstanceOfType(actual, typeof(ITestType));
        }

        [TestMethod]
        public void TestParameterizedConstructorByTypeName()
        {
            IObjectBuilder creator = new TypeCreator();
            string quanlifedName = typeof(TestType).AssemblyQualifiedName;
            ITestType actual = creator.BuildUp<ITestType>(quanlifedName, new object[] { "hello" });
            Assert.IsInstanceOfType(actual, typeof(ITestType));
            Assert.AreEqual<string>("hello", actual.Data);

        }
    }
}
