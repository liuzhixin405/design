using System;
using System.Data;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.Idiom.Registry
{
    /// <summary>
    /// ��������洢����ÿ���������͵�ע�������
    /// </summary>
    public sealed class DbParameterRegistry
    {
        /// <summary>
        /// ����ÿ��DbParamter��Ӧ���������͵��ֵ�
        /// </summary>
        private IDictionary<string, DbType> types;

        /// <summary>
        /// ��ʶ���ݲ�ͬ��CommandText������Ӧ��ע����
        /// </summary>
        private string spName;
        public string StoredProcedureName { get { return spName; } }

        public DbParameterRegistry(string spName)
        {
            this.spName = spName;
            types = new Dictionary<string, DbType>();
        }

        /// <summary>
        /// ע�������ṩ�Ķ�дע����Ϣ�������
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public DbType this[string parameterName]
        {
            get { return types[parameterName]; }
            set { types[parameterName] = value; }
        }

        /// <summary>
        /// �ж��Ƿ�ĳ�������Ѿ������˻���
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public bool ContainsKey(string parameterName)
        {
            return types.ContainsKey(parameterName);
        }

        /// <summary>
        /// ���������б�
        /// </summary>
        public IEnumerable<DbType> Types
        {
            get { return types.Values; }
        }
    }
}
