using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.StrategyPattern.Classic;
namespace MarvellousWorks.PracticalPattern.StrategyPattern.Test.Classic
{
    [TestClass]
    public class TestStrategy
    {
        /// <summary>
        /// 具体策略类型
        /// </summary>
        class DescentSortStrategy : IStrategy
        {
            public int PickUp(int[] data)
            {
                Array.Sort<int>(data);
                return data[data.Length - 1];
            }
        }
        class FirstDataStrategy : IStrategy
        {
            public int PickUp(int[] data)
            {
                return data[0];
            }
        }
        class AscentStrategy : IStrategy
        {
            public int PickUp(int[] data)
            {
                Array.Sort<int>(data);
                return data[0];
            }
        }

        /// <summary>
        /// 需要采用可替换策略执行的对象
        /// </summary>
        public class Context : IContext
        {
            protected IStrategy strategy;
            public IStrategy Strategy
            {
                get { return this.strategy; }
                set { this.strategy = value; }
            }

            /// <summary>
            /// 执行对象依赖于策略对象的操作方法
            /// </summary>
            /// <param name="data"></param>
            /// <returns></returns>
            public int GetData(int[] data)
            {
                if (strategy == null) throw new NullReferenceException("strategy");
                if (data == null) throw new ArgumentNullException("data");
                return strategy.PickUp(data);
            }
    }


        [TestMethod]
        public void Test()
        {
            int[] data = new int[] { 3, 5, 7, 9, 1 };
            IContext context = new Context();
            context.Strategy = new DescentSortStrategy();
            Assert.AreEqual<int>(context.GetData(data), 9);

            // 切换算法
            data = new int[] { 3, 5, 7, 9, 1 };
            context.Strategy = new FirstDataStrategy();
            Assert.AreEqual<int>(context.GetData(data), 3);

            data = new int[] { 3, 5, 7, 9, 1 };
            context.Strategy = new AscentStrategy();
            Assert.AreEqual<int>(context.GetData(data), 1);
        }
    }
}
