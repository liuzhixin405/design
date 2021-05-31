using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.FlyweightPattern.Classic
{
    public abstract class FoodBase
    {
        /// <summary>
        /// ʳ����ܼ��м��ֿ�ζ : Acid,Sweet,Bitter,Hot, Salty,None
        /// ͬʱҲ����ԱȽ�ռ�ռ�Ĳ��֡�
        /// </summary>
        private IList<string> tastes = new List<string>();
        private string name;
        public FoodBase(string name) { this.name = name; }

        /// <summary>
        /// ����ӿ�
        /// </summary>
        /// <param name="taste"></param>
        /// <returns></returns>
        public FoodBase AddTaste(string taste)
        {
            tastes.Add(taste);
            return this;
        }

        /// <summary>
        /// ʳ�������
        /// </summary>
        public virtual string Name { get { return this.name; } }
    }

    public class Capsicum : FoodBase
    {
        public Capsicum() : base("Capsicum") { base.AddTaste("Hot"); }

        /// <summary>
        /// ʹ�����ձ�Ĳ�ϵ
        /// </summary>
        public string MostPopularInCuisine { get { return "����"; } }
    }

    public class Cheese : FoodBase
    {
        public Cheese() : base("Cheese") { base.AddTaste("Salty").AddTaste("Sweet"); }

        /// <summary>
        /// �Ƚϸ��۵������
        /// </summary>
        public int MeltingPoint { get { return 280; } }
    }

    public class FoodFactory
    {
        private IDictionary<string, FoodBase> dictionary = new Dictionary<string, FoodBase>();

        public FoodBase Create(string name)
        {
            FoodBase result;
            if (dictionary.TryGetValue(name, out result))
                return result;
            switch (name)
            {
                case "Capsicum": result = new Capsicum(); break;
                case "Cheese": result = new Cheese(); break;
                default: throw new NotSupportedException();
            }
            dictionary.Add(result.Name, result);
            return result;
        }
    }
}
