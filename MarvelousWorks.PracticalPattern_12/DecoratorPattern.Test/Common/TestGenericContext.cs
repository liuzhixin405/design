using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Common;
namespace MarvellousWorks.PracticalPattern.DecoratorPattern.Test.Common
{
    class A
    {
        public IList<string> Method()
        {
            return new GenericContext().GetStackObjects();
        }
    }

    class B
    {
        public IList<string> Method(){return new A().Method();}
    }

    class C
    {
        public IList<string> Method(){return new B().Method();}    
    }


    public class Client
    {
        public IList<string> Method() { return new C().Method(); }    
    }

    [TestClass]
    public class TestGenericContext
    {
        [TestMethod]
        public void Test()
        {
            IList<string> types = new Client().Method();
            foreach (string typeName in types)
                Trace.WriteLine(typeName);
        }
    }
}
