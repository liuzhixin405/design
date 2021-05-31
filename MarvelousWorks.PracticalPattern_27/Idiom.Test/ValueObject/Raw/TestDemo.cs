using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Idiom.ValueObject.Raw;
namespace MarvellousWorks.PracticalPattern.Idiom.Test.ValueObject.Raw
{
    [TestClass]
    public class TestValueObject
    {
        [TestMethod]
        public void Test()
        {
            Money m1 = new Money();
            m1.Amount = 20;
            m1.Currency = Currency.RMB;

            // 赋值过程的自动克隆
            Money m2 = m1;
            Assert.AreEqual<decimal>(m1.Amount, m2.Amount);
            Assert.AreEqual<Currency>(m1.Currency, m2.Currency);

            // 说明是两个独立的实体在运行
            m2.Currency = Currency.Dollar;
            m2.Amount = 10;
            Assert.AreNotEqual<Currency>(m1.Currency, m2.Currency);
            Assert.AreNotEqual<decimal>(m1.Amount, m2.Amount);
        }
    }
}
