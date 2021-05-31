using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.CommandPattern.Delegating;
namespace MarvellousWorks.PracticalPattern.CommandPattern.Test.Delegating
{
    [TestClass]
    public class TestCommand
    {
        [TestMethod]
        public void Test()
        {
            Invoker invoker = new Invoker();
            invoker.AddHandler((new Receiver1()).A);
            invoker.AddHandler((new Receiver2()).B);
            invoker.AddHandler(Receiver3.C);
            invoker.Run();
        }
    }
}

//.class public auto ansi sealed VoidHandler
//    extends [mscorlib]System.MulticastDelegate
//{
//    .method public hidebysig specialname rtspecialname
//    instance void .ctor(object 'object', native int 'method') runtime managed{}

//    .method public hidebysig newslot virtual instance class [mscorlib]System.IAsyncResult 
//    BeginInvoke(class [mscorlib]System.AsyncCallback 
//    callback, object 'object') runtime managed{}

//    .method public hidebysig newslot virtual instance void 
//    EndInvoke(class [mscorlib]System.IAsyncResult result) runtime managed{}

//    .method public hidebysig newslot virtual instance 
//    void Invoke() runtime managed{}
//}

 

 
