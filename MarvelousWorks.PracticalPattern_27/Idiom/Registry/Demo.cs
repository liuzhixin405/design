using System;
using System.Data;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.Idiom.Registry
{
    /// <summary>
    /// 帮助保存存储过程每个参数类型的注册表类型
    /// </summary>
    public sealed class DbParameterRegistry
    {
        /// <summary>
        /// 保存每个DbParamter对应的数据类型的字典
        /// </summary>
        private IDictionary<string, DbType> types;

        /// <summary>
        /// 标识根据不同的CommandText区分相应的注册表的
        /// </summary>
        private string spName;
        public string StoredProcedureName { get { return spName; } }

        public DbParameterRegistry(string spName)
        {
            this.spName = spName;
            types = new Dictionary<string, DbType>();
        }

        /// <summary>
        /// 注册表对外提供的读写注册信息项的属性
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public DbType this[string parameterName]
        {
            get { return types[parameterName]; }
            set { types[parameterName] = value; }
        }

        /// <summary>
        /// 判断是否某个参数已经进行了缓存
        /// </summary>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public bool ContainsKey(string parameterName)
        {
            return types.ContainsKey(parameterName);
        }

        /// <summary>
        /// 参数类型列表
        /// </summary>
        public IEnumerable<DbType> Types
        {
            get { return types.Values; }
        }
    }
}
