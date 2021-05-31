using System;
using System.Diagnostics;
namespace MarvellousWorks.PracticalPattern.FactoryMethod.Classic
{
    class Client
    {
        public void SomeMethod()
        {
            IFactory factory = new FactoryA();   // 获得了抽象Factory的同时，与FactoryA产生依赖；
            IProduct product = factory.Create(); // 后续操作仅以来抽象的IFactory和IProduct完成
            // ...
        }

        private IFactory factory;

        public Client(IFactory factory)     // 将IFactory通过Setter方式注入
        {
            if (factory == null) throw new ArgumentNullException("factory");
            this.factory = factory;
        }

        public void AnotherMethod()
        {
            IProduct product = factory.Create();
            // ... ...
        }
    }


}
