using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Idiom.Mapper;
namespace MarvellousWorks.PracticalPattern.Idiom.Mapper
{
    [TestClass]
    public class TestMapper
    {
        [TestMethod]
        public void Test()
        {
            Mapper mapper = new Mapper();
            mapper.Method1("h");    // A->B
            mapper.Method2(10);     // B->A
            mapper.Method3(3);      // A<->B
        }
    }
}
