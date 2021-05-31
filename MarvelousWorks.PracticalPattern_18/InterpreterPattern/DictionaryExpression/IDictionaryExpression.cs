using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.InterpreterPattern.DictionaryExpression
{
    /// <summary>
    /// �����ֵ���Ϣ�洢���ʶ���
    /// </summary>
    public interface IDictionaryStore
    {
        /// <summary>
        /// ���ڻ������á����ݿ����Ϣ��Store�������ͨ��
        /// �÷������¼�����Ӧ�Ļ�����Ϣ
        /// </summary>
        void Refersh();
        /// <summary>
        /// ����Context�����Key/Value�Լ����ʷ�����ȡ��Ϣ
        /// </summary>
        /// <param name="context"></param>
        void Find(Context context);
    }

    /// <summary>
    /// �����ֵ���Ϣ�ı��ʽ����ӿ�
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
