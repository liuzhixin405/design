using System;
using System.Collections.Generic;
using MarvellousWorks.PracticalPattern.CommandPattern.Federate;
namespace MarvellousWorks.PracticalPattern.CommandPattern.Federate.Facade
{
    /// <summary>
    /// Facade��ʽ��֯�ĸ���Command�ӿ�
    /// </summary>
    public interface IFederateCommand : ICommand
    {
        /// <summary>
        /// ����Command���������ģʽ������֯����������
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
        /// Facade����
        /// </summary>
        public virtual void A() { commandA.Execute(); }
        public virtual void B() { commandB.Execute(); }
        public virtual void C() { commandC.Execute(); }

        /// <summary>
        /// ��Ϊһ����׼Command������Ҫִ�е�����
        /// </summary>
        public virtual void Execute()
        {
            commandA.Execute();
            commandB.Execute();
            commandC.Execute();
        }
    }
}
