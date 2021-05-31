using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.InterpreterPattern.DictionaryExpression
{
    /// <summary>
    /// 基于枚举项的DictionaryStore
    /// </summary>
    public class EnumDictionaryStore<T> : IDictionaryStore
    {
        public void Refersh(){} // 对于枚举类型暂时用不到

        /// <summary>
        /// 根据字典操作方向进行字符串(value)/枚举值(key)的翻译工作
        /// </summary>
        /// <param name="context"></param>
        public void Find(Context context)
        {
            switch (context.Operator)
            {
                case 'F':   // 'F'(from) 根据Key获得Value
                    context.Value = ((T)(context.Key)).ToString();
                    break;
                case 'T':   // 'T'(to) 根据Value获得Key
                    context.Key = Enum.Parse(typeof(T), (string)context.Value);
                    break;
                default:
                    throw new ArgumentException();
            }
        }
    }

    /// <summary>
    /// 基于Dictionary<string, string>的DictionaryStore
    /// </summary>
    public class StringDictionaryStore : IDictionaryStore
    {
        public void Refersh() { } // 对于Dictionary<string, string>类型暂时用不到

        /// <summary>
        /// 定义数据内容
        /// </summary>
        protected IDictionary<string, string> data;
        public virtual IDictionary<string, string> Data
        {
            get { return data; }
            set { data = value; }
        }

        /// <summary>
        /// 根据字典操作方向进行字符串(value)/枚举值(key)的翻译工作
        /// 即便存在不同的Key对应同一个Value的情况，也只返回找到的第一个Key
        /// </summary>
        /// <param name="context"></param>
        public void Find(Context context)
        {
            if(Data == null) throw new NullReferenceException("Data");
            string value;
            switch (context.Operator)
            {
                case 'F':   // 'F'(from) 根据Key获得Value
                    if (!Data.TryGetValue((string)context.Key, out value))
                        context.Value = string.Empty;
                    else
                        context.Value = value;
                    break;
                case 'T':   // 'T'(to) 根据Value获得Key
                    value = (string)context.Value;
                    foreach (string key in Data.Keys)
                        if (string.Equals(Data[key], value))
                        {
                            context.Key = key;
                            return;
                        }
                    context.Key = string.Empty;
                    break;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
