using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading;
using MarvellousWorks.PracticalPattern.Common;
namespace Common.Test.Windows
{
    [TestClass()]
    public class GenericContextTest
    {
        class WorkItem
        {
            private GenericContext context;
            private const string Key = "id";
            private static IList<string> works = new List<string>();
            public string Id { get { return (string)context[Key]; } }
            
            public void Start()
            {
                context = new GenericContext();
                context[Key] = Guid.NewGuid().ToString();
                works.Add(Id); 
            }

            public static IList<string> Works { get { return works; } }
        }

        [TestMethod]
        public void Test()
        { 
            Thread[] threads = new Thread[3];
            for(int i=0; i<threads.Length; i++)
            {
                threads[i] = new Thread(new ThreadStart(new WorkItem().Start));
                threads[i].Start();
            }
            Thread.Sleep(1000);
            Assert.AreNotEqual<string>(WorkItem.Works[0], WorkItem.Works[1]);
            Assert.AreNotEqual<string>(WorkItem.Works[1], WorkItem.Works[2]);
            Assert.AreNotEqual<string>(WorkItem.Works[2], WorkItem.Works[0]);
        }
    }
}
