using System;
using System.Data;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.StrategyPattern.Delegating
{
    /// <summary>
    /// Context∂‘œÛ
    /// </summary>
    public class DbTypeConverter
    {
        public Type[] FromDbType(DbType[] types)
        {
            if ((types == null) || (types.Length == 0)) return null;
            return Array.ConvertAll<DbType, Type>(types, new Converter<DbType, Type>(DbTypeToType));
        }

        private Type DbTypeToType(DbType type)
        {
            switch (type)
            {
                case DbType.Int32: return Type.GetType("System.Int32"); 
                case DbType.String: return Type.GetType("System.String"); 
                default: throw new NotSupportedException(type.ToString());
            }
        }
    }
}
