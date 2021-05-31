using System;
using System.Collections.Generic;
using MarvellousWorks.PracticalPattern.CommandPattern.Federate;
namespace MarvellousWorks.PracticalPattern.CommandPattern.Federate.Facade
{
    /// <summary>
    /// Facade方式组织的复合Command接口
    /// </summary>
    public interface IFederateCommand : ICommand
    {
        /// <summary>
        /// 复合Command对象以外观模式对外组织的新增方法
        /// </summary>
        void A();
        void B();
        void C();
    }

    public class FederateCommand : IFederateCommand
    {
        protected ICommand commandA;
        protected ICommand commandB;
        protected ICommand commandC;

        public FederateCommand(ICommand commandA, 
            ICommand commandB, ICommand commandC)
        {
            this.commandA = commandA;
            this.commandB = commandB;
            this.commandC = commandC;
        }

        /// <summary>
        /// Facade方法
        /// </summary>
        public virtual void A() { commandA.Execute(); }
        public virtual void B() { commandB.Execute(); }
        public virtual void C() { commandC.Execute(); }

        /// <summary>
        /// 作为一个标准Command对象需要执行的内容
        /// </summary>
        public virtual void Execute()
        {
            commandA.Execute();
            commandB.Execute();
            commandC.Execute();
        }
    }
}
