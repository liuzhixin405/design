using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.FlyweightPattern.Classic
{
    public abstract class FoodBase
    {
        /// <summary>
        /// 食物可能兼有几种口味 : Acid,Sweet,Bitter,Hot, Salty,None
        /// 同时也是相对比较占空间的部分。
        /// </summary>
        private IList<string> tastes = new List<string>();
        private string name;
        public FoodBase(string name) { this.name = name; }

        /// <summary>
        /// 连贯接口
        /// </summary>
        /// <param name="taste"></param>
        /// <returns></returns>
        public FoodBase AddTaste(string taste)
        {
            tastes.Add(taste);
            return this;
        }

        /// <summary>
        /// 食物的名称
        /// </summary>
        public virtual string Name { get { return this.name; } }
    }

    public class Capsicum : FoodBase
    {
        public Capsicum() : base("Capsicum") { base.AddTaste("Hot"); }

        /// <summary>
        /// 使用最普遍的菜系
        /// </summary>
        public string MostPopularInCuisine { get { return "川菜"; } }
    }

    public class Cheese : FoodBase
    {
        public Cheese() : base("Cheese") { base.AddTaste("Salty").AddTaste("Sweet"); }

        /// <summary>
        /// 比较高熔点的奶酪
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
