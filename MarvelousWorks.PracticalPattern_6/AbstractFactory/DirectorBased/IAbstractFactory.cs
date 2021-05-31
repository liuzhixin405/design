using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.AbstractFactory.DirectorBased
{
    /// <summary>
    /// 抽象产品类型
    /// </summary>
    public interface IDrink { }
    public interface IDish { }

    /// <summary>
    /// 具有组合关系的抽象产品对象
    /// </summary>
    public class SetLunch  
    {
        public IList<IDrink> Drinks = new List<IDrink>();
        public IList<IDish> Dishes = new List<IDish>();
    }

    /// <summary>
    /// 抽象的Director类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDirector<T>
    {
        /// <summary>
        /// 抽象方法，告诉Factory应该怎样生成指定具有组合关系的类型
        /// </summary>
        /// <returns></returns>
        T Direct();
    }

    public interface ISetLunchFactory
    {
        SetLunch GetSetLunch();    // 构造具有组合关系的对象
        IDrink GetDrink();          // 构造独立对象
        IDish GetDish();            // 构造独立对象

        SetLunchDirectorBase Director { get; set;}   // Setter方式注入Director的入口
    }

    /// <summary>
    /// 定义获取产品的方法委托
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public delegate T GetFoodHandler<T>();

    public abstract class SetLunchDirectorBase : IDirector<SetLunch>
    {
        /// <summary>
        /// 构造不同类型商品的件数        
        /// </summary>
        protected int drinkQuantity;
        protected int dishQuantity;

        /// <summary>
        /// 构造不同类型商品需要调用的事件委托
        /// </summary>
        public GetFoodHandler<IDrink> CreateDrink;
        public GetFoodHandler<IDish> CreateDish;

        /// <summary>
        /// 这里之所以没有直接要求直接传入一个ISetLunchFactory，主要是为了避免
        /// ISetFactory与SetLunchDirectorBase之间产生双因素依赖关系，在没有介绍到
        /// 行为型模式前，尽量避免类似复杂依赖关系的产生。
        /// </summary>
        /// <param name="drinkQuantity"></param>
        /// <param name="dishQuantity"></param>
        public SetLunchDirectorBase(int drinkQuantity, int dishQuantity)
        {
            this.drinkQuantity = drinkQuantity;
            this.dishQuantity = dishQuantity;
        }

        /// <summary>
        /// 生成具有组合关系的产品
        /// </summary>
        /// <returns></returns>
        public virtual SetLunch Direct()
        {
            if(drinkQuantity < 0) throw new ArgumentException("drink quantity");
            if(dishQuantity < 0) throw new ArgumentException("dish quantity");
            SetLunch setLunch = new SetLunch();
            for (int i = 0; i < drinkQuantity; i++) setLunch.Drinks.Add(CreateDrink());
            for (int i = 0; i < dishQuantity; i++) setLunch.Dishes.Add(CreateDish());
            return setLunch;
        }

        
    }

    public abstract class SetLunchFactoryBase : ISetLunchFactory
    {
        protected SetLunchDirectorBase director;
        public abstract IDrink GetDrink();
        public abstract IDish GetDish();

        public virtual SetLunchDirectorBase Director
        {
            get { return director; }
            set 
            { 
                director = value;
                // 绑定委托方法
                director.CreateDish = GetDish;
                director.CreateDrink = GetDrink;
            }
        }

        /// <summary>
        /// 对于组合产品的方法，通过Director协助创建
        /// </summary>
        /// <returns></returns>
        public virtual SetLunch GetSetLunch()
        {
            if (director == null) throw new ArgumentNullException("director");
            return director.Direct();
        }
    }
}
