using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.CompositePattern.Classic;
namespace MarvellousWorks.PracticalPattern.CompositePattern.Test.Classic
{
    [TestClass]
    public class TestComposite
    {
        [TestMethod]
        public void Test()
        {
            ComponentFactory factory = new ComponentFactory();
            Component corporate = factory.Create<Composite>("corporate");       // 1
            factory.Create<Leaf>(corporate, "president");                       // 2
            factory.Create<Leaf>(corporate, "vice president");                  // 3
            Component sales = factory.Create<Composite>(corporate, "sales");    // 4
            Component market = factory.Create<Composite>(corporate, "market");  // 5
            factory.Create<Leaf>(sales, "joe");                                 // 6
            factory.Create<Leaf>(sales, "bob");                                 // 7
            factory.Create<Leaf>(market, "judi");                               // 8
            Component branch = factory.Create<Composite>(corporate, "branch");  // 9
            factory.Create<Leaf>(branch, "manager");                            // 10
            factory.Create<Leaf>(branch, "peter");                              // 11
            IList<string> names = new List<string>(corporate.GetNameList());
            // 验证确实可以把所有节点的名称（含子孙节点）遍历出来
            Assert.AreEqual<int>(11, names.Count);
            foreach (string item in corporate.GetNameList())
                Trace.WriteLine(item);
        }
    }
}
