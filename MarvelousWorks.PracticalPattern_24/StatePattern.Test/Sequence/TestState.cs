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
        /// �����State����
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
        /// ����Context����
        /// </summary>
        class Connection : ContextBase
        {
            public Connection() { State = new CloseState(); }
        }

        [TestMethod]
        public void Test()
        {
            //  ��֤�������Զ�״̬ת��
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
