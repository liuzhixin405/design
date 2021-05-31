using System;
using System.Collections.Generic;
using System.Text;

namespace MarvellousWorks.PracticalPattern.DecoratorPattern.WithBuilder
{
    public class DecoratorAssembly
    {
        /// <summary>
        /// 登记装饰不同类型需要使用的一组Concrete Decorator类型
        /// </summary>
        private static IDictionary<Type, IList<Type>> dictionary =
            new Dictionary<Type, IList<Type>>();

        /// <summary>
        /// 项目中这个加载过程可以借助配置完成
        /// </summary>
        static DecoratorAssembly()
        {
            IList<Type> types = new List<Type>();
            types.Add(typeof(BoldDecorator));
            types.Add(typeof(ColorDecorator));
            dictionary.Add(typeof(TextObject), types);
        }

        /// <summary>
        /// 按照需要构造的客户类型选择相应的Decorator列表
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IList<Type> this[Type type]
        {
            get
            {
                if (type == null) throw new ArgumentNullException("type");
                IList<Type> result;
                return dictionary.TryGetValue(type, out result) ? result : null;
            }
        }
    }
}
