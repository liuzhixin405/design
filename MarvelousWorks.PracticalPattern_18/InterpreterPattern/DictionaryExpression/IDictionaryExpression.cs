using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.InterpreterPattern.DictionaryExpression
{
    /// <summary>
    /// 抽象字典信息存储访问对象
    /// </summary>
    public interface IDictionaryStore
    {
        /// <summary>
        /// 对于基于配置、数据库等信息的Store对象可以通过
        /// 该方法重新加载相应的缓冲信息
        /// </summary>
        void Refersh();
        /// <summary>
        /// 根据Context定义的Key/Value以及访问方向提取信息
        /// </summary>
        /// <param name="context"></param>
        void Find(Context context);
    }

    /// <summary>
    /// 具有字典信息的表达式对象接口
    /// </summary>
    public interface IDictionaryExpression : IExpression
    {
        IDictionaryStore Store { get; set;}
    }

    public class SimpleDictionaryExpression : IDictionaryExpression
    {
        protected IDictionaryStore store;
        public virtual IDictionaryStore Store
        {
            get { return store; }
            set { store = value; }
        }
        
        public virtual void Evaluate(Context context)
        {
            store.Find(context);
        }
    }
}
