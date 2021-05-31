using System;
namespace MarvellousWorks.PracticalPattern.BridgePattern.Classic
{
    public interface IImpl
    {
        void OperationImpl();
    }

    public interface IAbstraction
    {
        IImpl Implementor { get; set;}
        void Operation();
    }

    public class ConcreteImplementatorA : IImpl { public void OperationImpl() { } }
    public class ConcreteImplementatorB : IImpl { public void OperationImpl() { } }

    public class RefinedAbstraction : IAbstraction
    {
        private IImpl implementor;
        public IImpl Implementor   // setter��ʽ����ע��
        {
            get { return this.implementor; }
            set { this.implementor = value; }
        }

        public void Operation()
        {
            // ��������
            implementor.OperationImpl();
        }
    }
}
