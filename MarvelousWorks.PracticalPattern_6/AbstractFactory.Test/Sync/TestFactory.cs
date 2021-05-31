using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.AbstractFactory.Sync;
namespace AbstractFactory.Test.Sync
{
[TestClass]
public class TestFactory
{
    class ConcreteProduct : IProduct{}

    class ConcreteFactory : IFactoryWithNotifier
    {
        /// <summary>
        /// 同步构造过程
        /// </summary>
        /// <returns></returns>
        public IProduct Create() { return new ConcreteProduct(); }

        /// <summary>
        /// 异步构造过程
        /// </summary>
        /// <param name="callback"></param>
        public void Create(ObjectCreateHandler<IProduct> callback)
        {
            IProduct product = Create();
            callback(product);  // 异步的把加工结果返回
        }
    }

    class Subscribe
    {
        private IProduct product;
        public void SetProduct(IProduct product) { this.product = product; }
        public IProduct GetProduct() { return this.product; }
    }

    [TestMethod]
    public void Test()
    {
        IFactoryWithNotifier factory = new ConcreteFactory();
        Subscribe subcriber = new Subscribe();
        ObjectCreateHandler<IProduct> callback =
            new ObjectCreateHandler<IProduct>(subcriber.SetProduct);
        Assert.IsNull(subcriber.GetProduct());
        factory.Create(callback);
        Assert.IsNotNull(subcriber.GetProduct());
    }
}
}
