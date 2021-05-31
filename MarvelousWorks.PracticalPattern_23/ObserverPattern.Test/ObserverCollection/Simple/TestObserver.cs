using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.ObserverPattern.ObserverCollection.Simple;
namespace MarvellousWorks.PracticalPattern.ObserverPattern.Test.ObserverCollection.Simple
{
    [TestClass]
    public class TestObserver
    {
        string key = "hello";
        string value = "world";

        public void Validate(object sender, DictionaryEventArgs<string, string> args)
        {
            Assert.IsNotNull(sender);
            Type expectedType = typeof(ObserverableDictionary<string, string>);
            Assert.AreEqual<Type>(expectedType, sender.GetType());
            Assert.IsNotNull(args);
            expectedType = typeof(DictionaryEventArgs<string, string>);
            Assert.AreEqual<Type>(expectedType, args.GetType());
            Assert.AreEqual<string>(key, args.Key);
            Assert.AreEqual<string>(value, args.Value);
            Trace.WriteLine(args.Key + "  " + args.Value);
        }

        [TestMethod]
        public void Test()
        {
            IObserverableDictionary<string, string> dictionary =
                new ObserverableDictionary<string, string>();
            dictionary.NewItemAdded += this.Validate;
            dictionary.Add(key, value);
        }
    }
}
