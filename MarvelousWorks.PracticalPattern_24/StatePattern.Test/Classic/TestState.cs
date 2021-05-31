using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.StatePattern.Classic;
namespace MarvellousWorks.PracticalPattern.StatePattern.Test.Classic
{
    [TestClass]
    public class TestState
    {
        /// <summary>
        /// 具体的State类型
        /// </summary>
        class OpenState : IState
        {
            public void Open() { throw new NotSupportedException(); }
            public void Close() { } // pass
            public void Query() { } // pass
        }

        class CloseState : IState
        {
            public void Open() { }
            public void Close() { throw new NotSupportedException(); }
            public void Query() { throw new NotSupportedException(); }
        }

        /// <summary>
        /// 具体Context类型
        /// </summary>
        class Connection : ContextBase { }

        [TestMethod]
        public void Test()
        {
            Connection connection = new Connection();

            // 验证打开状态时的行为
            connection.State = new OpenState();
            try
            {
                connection.Open();
                Assert.IsTrue(false);
            }
            catch { }
            try
            {
                connection.Close();
            }
            catch 
            {
                Assert.IsTrue(false); 
            }

            connection.State = new CloseState();
            // 验证关闭时的状态
            try
            {
                connection.Query();
                Assert.IsTrue(false);
            }
            catch { }
            try
            {
                connection.Open();
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
    }
}
