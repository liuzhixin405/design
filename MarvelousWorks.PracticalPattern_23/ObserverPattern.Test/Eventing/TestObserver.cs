using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.ObserverPattern.Eventing;
namespace MarvellousWorks.PracticalPattern.ObserverPattern.Test.Eventing
{
    [TestClass]
    public class TestObserver
    {
        private void OnNameChanged(object send, UserEventArgs args)
        {
            Assert.AreEqual<string>("joe", args.Name);
        }

        [TestMethod]
        public void Test()
        {
            User user = new User();
            user.NameChanged += this.OnNameChanged;
            user.Name = "joe";
        }
    }
}
