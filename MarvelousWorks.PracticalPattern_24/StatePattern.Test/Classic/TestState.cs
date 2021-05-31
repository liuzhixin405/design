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
        /// �����State����
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
        /// ����Context����
        /// </summary>
        class Connection : ContextBase { }

        [TestMethod]
        public void Test()
        {
            Connection connection = new Connection();

            // ��֤��״̬ʱ����Ϊ
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
            // ��֤�ر�ʱ��״̬
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
