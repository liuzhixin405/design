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
        public IImpl Implementor   // setter方式依赖注入
        {
            get { return this.implementor; }
            set { this.implementor = value; }
        }

        public void Operation()
        {
            // 其他处理
            implementor.OperationImpl();
        }
    }
}
