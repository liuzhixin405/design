using System;
using System.Collections.Generic;
using System.Text;

namespace MarvellousWorks.PracticalPattern.DecoratorPattern.WithBuilder
{
    public class DecoratorAssembly
    {
        /// <summary>
        /// �Ǽ�װ�β�ͬ������Ҫʹ�õ�һ��Concrete Decorator����
        /// </summary>
        private static IDictionary<Type, IList<Type>> dictionary =
            new Dictionary<Type, IList<Type>>();

        /// <summary>
        /// ��Ŀ��������ع��̿��Խ����������
        /// </summary>
        static DecoratorAssembly()
        {
            IList<Type> types = new List<Type>();
            types.Add(typeof(BoldDecorator));
            types.Add(typeof(ColorDecorator));
            dictionary.Add(typeof(TextObject), types);
        }

        /// <summary>
        /// ������Ҫ����Ŀͻ�����ѡ����Ӧ��Decorator�б�
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
