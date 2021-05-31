using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.CommandPattern.Federate;
using MarvellousWorks.PracticalPattern.CommandPattern.Federate.Facade;
namespace MarvellousWorks.PracticalPattern.CommandPattern.Test.Federate.Facade
{
    [TestClass]
    public class TestCommand
    {
        class CommandA : ICommand { public void Execute() { Trace.WriteLine("A"); } }
        class CommandB : ICommand { public void Execute() { Trace.WriteLine("B"); } }
        class CommandC : ICommand { public void Execute() { Trace.WriteLine("C"); } }

        [TestMethod]
        public void Test()
        {
            FederateCommand command = new FederateCommand(
                new CommandA(), new CommandB(), new CommandC());
            command.A();
            command.B();
            command.C();
            ((ICommand)command).Execute();
        }
    }
}
