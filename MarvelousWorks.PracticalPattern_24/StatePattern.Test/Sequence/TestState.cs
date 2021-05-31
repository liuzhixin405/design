using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.StatePattern.Sequence;
namespace MarvellousWorks.PracticalPattern.StatePattern.Test.Sequence
{
    [TestClass]
    public class TestState
    {
        /// <summary>
        /// 具体的State类型
        /// </summary>
        class OpenState : IState
        {
            public void Open(ContextBase context) { throw new NotSupportedException(); }
            public void Close(ContextBase context) { context.State = new CloseState(); }
            public void Query(ContextBase context) { } // pass
        }
        class CloseState : IState
        {
            public void Open(ContextBase context) { context.State = new OpenState(); }
            public void Close(ContextBase context) { throw new NotSupportedException(); }
            public void Query(ContextBase context) { throw new NotSupportedException(); }
        }

        /// <summary>
        /// 具体Context类型
        /// </summary>
        class Connection : ContextBase
        {
            public Connection() { State = new CloseState(); }
        }

        [TestMethod]
        public void Test()
        {
            //  验证连续的自动状态转换
            try
            {
                Connection connection = new Connection();
                connection.Open().Query().Query().Query().Close();
            }
            catch 
            {
                Assert.IsTrue(false);
            }
        }
    }

}
