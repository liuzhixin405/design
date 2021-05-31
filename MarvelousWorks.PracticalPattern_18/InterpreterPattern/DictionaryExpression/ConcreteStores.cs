using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.InterpreterPattern.DictionaryExpression
{
    /// <summary>
    /// ����ö�����DictionaryStore
    /// </summary>
    public class EnumDictionaryStore<T> : IDictionaryStore
    {
        public void Refersh(){} // ����ö��������ʱ�ò���

        /// <summary>
        /// �����ֵ������������ַ���(value)/ö��ֵ(key)�ķ��빤��
        /// </summary>
        /// <param name="context"></param>
        public void Find(Context context)
        {
            switch (context.Operator)
            {
                case 'F':   // 'F'(from) ����Key���Value
                    context.Value = ((T)(context.Key)).ToString();
                    break;
                case 'T':   // 'T'(to) ����Value���Key
                    context.Key = Enum.Parse(typeof(T), (string)context.Value);
                    break;
                default:
                    throw new ArgumentException();
            }
        }
    }

    /// <summary>
    /// ����Dictionary<string, string>��DictionaryStore
    /// </summary>
    public class StringDictionaryStore : IDictionaryStore
    {
        public void Refersh() { } // ����Dictionary<string, string>������ʱ�ò���

        /// <summary>
        /// ������������
        /// </summary>
        protected IDictionary<string, string> data;
        public virtual IDictionary<string, string> Data
        {
            get { return data; }
            set { data = value; }
        }

        /// <summary>
        /// �����ֵ������������ַ���(value)/ö��ֵ(key)�ķ��빤��
        /// ������ڲ�ͬ��Key��Ӧͬһ��Value�������Ҳֻ�����ҵ��ĵ�һ��Key
        /// </summary>
        /// <param name="context"></param>
        public void Find(Context context)
        {
            if(Data == null) throw new NullReferenceException("Data");
            string value;
            switch (context.Operator)
            {
                case 'F':   // 'F'(from) ����Key���Value
                    if (!Data.TryGetValue((string)context.Key, out value))
                        context.Value = string.Empty;
                    else
                        context.Value = value;
                    break;
                case 'T':   // 'T'(to) ����Value���Key
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
