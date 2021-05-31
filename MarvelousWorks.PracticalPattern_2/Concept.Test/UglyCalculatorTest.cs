using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Concept.Operator;
namespace MarvellousWorks.PracticalPattern.Concept.Test
{
    [TestClass()]
    public class UglyCalculatorTest
    {
        [TestMethod]
        public void Test()
        {
            double result;
            new UglyCalculator().Calculate(20, 20, 100, out result);
            Assert.AreEqual<double>(20 * 20 - 100, result);
        }
    }
}
