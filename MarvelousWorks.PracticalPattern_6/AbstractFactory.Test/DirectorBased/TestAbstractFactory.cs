using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.AbstractFactory.DirectorBased;
namespace AbstractFactory.Test.DirectorBased
{
    class SmallSetLunchDirector : SetLunchDirectorBase
    {
        /// <summary>
        /// С���ײ�2������2�ݲ�
        /// </summary>
        public SmallSetLunchDirector() : base(2, 2) { }
    }

    class LargeSetLunchDiretor : SetLunchDirectorBase
    {
        /// <summary>
        /// ����ײ�2������5�ݲ�
        /// </summary>
        public LargeSetLunchDiretor() : base(2, 5) { }
    }

    /// <summary>
    /// �����Ʒ
    /// </summary>
    class Juice : IDrink { }
    class FriedChicken : IDish { }

    class CommonSetLunchFactory : SetLunchFactoryBase
    {
        public override IDish GetDish() { return new FriedChicken(); }
        public override IDrink GetDrink() { return new Juice(); }
    }

    [TestClass]
    public class TestAbstractFactory
    {
        [TestMethod]
        public void Test()
        {
            SetLunchDirectorBase director = new SmallSetLunchDirector();
            SetLunchFactoryBase factory = new CommonSetLunchFactory();
            factory.Director = director;
            SetLunch setLunch = factory.GetSetLunch();
            Assert.IsNotNull(setLunch);
            Assert.AreEqual<int>(2, setLunch.Drinks.Count);
            Assert.AreEqual<int>(2, setLunch.Dishes.Count);
            Assert.AreEqual<Type>(typeof(Juice), setLunch.Drinks[0].GetType());
            Assert.AreEqual<Type>(typeof(FriedChicken), setLunch.Dishes[0].GetType());
        }
    }
}
