using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.AdapterPattern.Grouping
{
    public sealed class DatabaseAdapterFactory
    {
        /// <summary>
        /// 专门登记“驱动名称/实际类型”的对象
        /// </summary>
        class DatabaseAdapterMapper
        {
            private static IDictionary<string, Type> dictionary =
                new Dictionary<string, Type>();

            /// <summary>
            /// 初始化过程，一般这个过程可以设计为静态的，而且
            /// 其中的内容可以从配置文件提取
            /// </summary>
            static DatabaseAdapterMapper()
            {
                dictionary.Clear();
                dictionary.Add("oracle", typeof(OracleAdapter));
                dictionary.Add("sqlserver", typeof(SqlServerAdapter));
            }

            /// <summary>
            /// 根据数据库类型，获得指定的Adapter类型名称
            /// </summary>
            /// <param name="typeName"></param>
            /// <returns></returns>
            public Type this[string name]
            {
                get
                {
                    if (!dictionary.ContainsKey(name))
                        throw new NotSupportedException(name);
                    return dictionary[name];
                }
            }
        }

        private DatabaseAdapterMapper mapper = new DatabaseAdapterMapper();

        /// <summary>
        /// 根据数据库类型返回DatabaseAdapter
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IDatabaseAdapter Create(string name)
        {
            return (IDatabaseAdapter)(Activator.CreateInstance(mapper[name]));
        }
    }
}
