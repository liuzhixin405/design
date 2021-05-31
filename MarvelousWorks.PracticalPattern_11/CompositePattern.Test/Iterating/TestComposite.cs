using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.CompositePattern.Iterating;
namespace MarvellousWorks.PracticalPattern.CompositePattern.Test.Iterating
{
    [TestClass]
    public class TestComposite
    {
        class LeafMatchRule : IMatchRule
        {
            public bool IsMatch(Component target)
            {
                if (target == null) return false;
                return (target.GetType().IsAssignableFrom(typeof(Leaf))) ? true : false;
            }
        }

        [TestMethod]
        public void Test()
        {
            ComponentFactory factory = new ComponentFactory();
            Component corporate = factory.Create<Composite>("corporate");       // 1 
            factory.Create<Leaf>(corporate, "president");                       // 2 (1)
            factory.Create<Leaf>(corporate, "vice president");                  // 3 (2)
            Component sales = factory.Create<Composite>(corporate, "sales");    // 4
            Component market = factory.Create<Composite>(corporate, "market");  // 5
            factory.Create<Leaf>(sales, "joe");                                 // 6 (3)
            factory.Create<Leaf>(sales, "bob");                                 // 7 (4)
            factory.Create<Leaf>(market, "judi");                               // 8 (5)
            Component branch = factory.Create<Composite>(corporate, "branch");  // 9
            factory.Create<Leaf>(branch, "manager");                            // 10(6)
            factory.Create<Leaf>(branch, "peter");                              // 11(7)

            IEnumerable<Component> matchSet = corporate.Enumerate(new LeafMatchRule());
            IList<Component> leaves = new List<Component>(matchSet);
            Assert.AreEqual<int>(7, leaves.Count);
            IList<Component> another = new List<Component>(corporate.Enumerate());
            Assert.AreEqual<int>(11, another.Count);
        }
    }
}
