using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.CommandPattern.Async;
namespace MarvellousWorks.PracticalPattern.CommandPattern.Test.Async
{
    [TestClass]
    public class TestCommand
    {
        class DemoCommand : CommandBase
        {
            public DemoCommand()
            {
                Completed += this.OnCompleted;
                AsyncCompleted += new AsyncCallback(this.OnAsyncCompleted);
            }

            public void OnCompleted(object sender, EventArgs args)
            {
                Log.Add("OnCompleted");
            }

            public void OnAsyncCompleted(IAsyncResult result)
            {
                Log.Add("OnAsyncCompleted");
            }

            /// <summary>
            /// 记录操作情况
            /// </summary>
            public List<string> Log = new List<string>();
        }

        [TestMethod]
        public void SyncTest()
        {
            DemoCommand command = new DemoCommand();
            command.Execute();
            // 说明同步调用的情况下，只触发一次同步事件
            Assert.AreEqual<int>(1, command.Log.Count);
            Assert.AreEqual<string>("OnCompleted", command.Log[0]);
        }

        [TestMethod]
        public void AsyncTest()
        {
            DemoCommand command = new DemoCommand();
            command.AsyncExecute();
            Thread.Sleep(200); // 给异步调用留出可以触发的时间
            // 说明异步调用的情况下，同时触发同步和异步事件
            Assert.AreEqual<int>(2, command.Log.Count);
            Assert.AreEqual<string>("OnCompleted", command.Log[0]);
            Assert.AreEqual<string>("OnAsyncCompleted", command.Log[1]);
        }
    }
}
