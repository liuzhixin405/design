using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.StrategyPattern.Delegating;
namespace MarvellousWorks.PracticalPattern.StrategyPattern.Test.Delegating
{
    public delegate int CompareHandler<T>(T x, T y);

    [TestClass]
    public class TestStrategy
    {
        [TestMethod]
        public void Test()
        {
            DbType[] types = new DbType[2];
            types[0] = DbType.Int32;
            types[1] = DbType.String;

            Type[] target = Array.ConvertAll<DbType, Type>(types, new Converter<DbType, Type>(
                // 委托方式实现的Strategy
                delegate(DbType type)   
                {
                    switch (type)
                    {
                        case DbType.Int32: return Type.GetType("System.Int32");
                        case DbType.String: return Type.GetType("System.String");
                        default: throw new NotSupportedException(type.ToString());
                    }
                }));
            Assert.AreEqual<int>(2, target.Length);
            Assert.AreEqual<Type>(Type.GetType("System.Int32"), target[0]);
            Assert.AreEqual<Type>(Type.GetType("System.String"), target[1]);
        }
    }
}
