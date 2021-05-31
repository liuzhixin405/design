using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.ShowCase.DataIndependent.OO
{
    public class OracleDatabase : Database
    {
        public OracleDatabase(string name)
            : base(name)
        {
        }

        /// <summary>
        /// 子类实现的差异性部分
        /// </summary>
        protected override string ParameterPrefix 
        {
            get { return ":"; } 
        }
    }

    public class SqlServerDatabase : Database
    {
        public SqlServerDatabase(string name)
            : base(name)
        {
        }

        /// <summary>
        /// 子类实现的差异性部分
        /// </summary>
        protected override string ParameterPrefix 
        {
            get { return "@"; } 
        }
    }
}
