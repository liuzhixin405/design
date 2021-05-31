using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.AdapterPattern.Grouping
{
    public sealed class DatabaseAdapterFactory
    {
        /// <summary>
        /// ר�ŵǼǡ���������/ʵ�����͡��Ķ���
        /// </summary>
        class DatabaseAdapterMapper
        {
            private static IDictionary<string, Type> dictionary =
                new Dictionary<string, Type>();

            /// <summary>
            /// ��ʼ�����̣�һ��������̿������Ϊ��̬�ģ�����
            /// ���е����ݿ��Դ������ļ���ȡ
            /// </summary>
            static DatabaseAdapterMapper()
            {
                dictionary.Clear();
                dictionary.Add("oracle", typeof(OracleAdapter));
                dictionary.Add("sqlserver", typeof(SqlServerAdapter));
            }

            /// <summary>
            /// �������ݿ����ͣ����ָ����Adapter��������
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
        /// �������ݿ����ͷ���DatabaseAdapter
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IDatabaseAdapter Create(string name)
        {
            return (IDatabaseAdapter)(Activator.CreateInstance(mapper[name]));
        }
    }
}
