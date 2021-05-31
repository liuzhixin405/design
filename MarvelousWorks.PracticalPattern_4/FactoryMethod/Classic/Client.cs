using System;
using System.Diagnostics;
namespace MarvellousWorks.PracticalPattern.FactoryMethod.Classic
{
    class Client
    {
        public void SomeMethod()
        {
            IFactory factory = new FactoryA();   // ����˳���Factory��ͬʱ����FactoryA����������
            IProduct product = factory.Create(); // �������������������IFactory��IProduct���
            // ...
        }

        private IFactory factory;

        public Client(IFactory factory)     // ��IFactoryͨ��Setter��ʽע��
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
