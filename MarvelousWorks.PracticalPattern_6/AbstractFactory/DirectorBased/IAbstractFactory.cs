using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.AbstractFactory.DirectorBased
{
    /// <summary>
    /// �����Ʒ����
    /// </summary>
    public interface IDrink { }
    public interface IDish { }

    /// <summary>
    /// ������Ϲ�ϵ�ĳ����Ʒ����
    /// </summary>
    public class SetLunch  
    {
        public IList<IDrink> Drinks = new List<IDrink>();
        public IList<IDish> Dishes = new List<IDish>();
    }

    /// <summary>
    /// �����Director����
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDirector<T>
    {
        /// <summary>
        /// ���󷽷�������FactoryӦ����������ָ��������Ϲ�ϵ������
        /// </summary>
        /// <returns></returns>
        T Direct();
    }

    public interface ISetLunchFactory
    {
        SetLunch GetSetLunch();    // ���������Ϲ�ϵ�Ķ���
        IDrink GetDrink();          // �����������
        IDish GetDish();            // �����������

        SetLunchDirectorBase Director { get; set;}   // Setter��ʽע��Director�����
    }

    /// <summary>
    /// �����ȡ��Ʒ�ķ���ί��
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public delegate T GetFoodHandler<T>();

    public abstract class SetLunchDirectorBase : IDirector<SetLunch>
    {
        /// <summary>
        /// ���첻ͬ������Ʒ�ļ���        
        /// </summary>
        protected int drinkQuantity;
        protected int dishQuantity;

        /// <summary>
        /// ���첻ͬ������Ʒ��Ҫ���õ��¼�ί��
        /// </summary>
        public GetFoodHandler<IDrink> CreateDrink;
        public GetFoodHandler<IDish> CreateDish;

        /// <summary>
        /// ����֮����û��ֱ��Ҫ��ֱ�Ӵ���һ��ISetLunchFactory����Ҫ��Ϊ�˱���
        /// ISetFactory��SetLunchDirectorBase֮�����˫����������ϵ����û�н��ܵ�
        /// ��Ϊ��ģʽǰ�������������Ƹ���������ϵ�Ĳ�����
        /// </summary>
        /// <param name="drinkQuantity"></param>
        /// <param name="dishQuantity"></param>
        public SetLunchDirectorBase(int drinkQuantity, int dishQuantity)
        {
            this.drinkQuantity = drinkQuantity;
            this.dishQuantity = dishQuantity;
        }

        /// <summary>
        /// ���ɾ�����Ϲ�ϵ�Ĳ�Ʒ
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
                // ��ί�з���
                director.CreateDish = GetDish;
                director.CreateDrink = GetDrink;
            }
        }

        /// <summary>
        /// ������ϲ�Ʒ�ķ�����ͨ��DirectorЭ������
        /// </summary>
        /// <returns></returns>
        public virtual SetLunch GetSetLunch()
        {
            if (director == null) throw new ArgumentNullException("director");
            return director.Direct();
        }
    }
}
