using System;
using System.Collections.Generic;
using System.Threading;
namespace MarvellousWorks.PracticalPattern.Common
{
    /// <summary>
    /// �̰߳�ȫ�������������ṩ�˴�һ�����һ��ֵ��ӳ�䡣
    /// </summary>
    /// <typeparam name="TKey">�ֵ��еļ�������</typeparam>
    /// <typeparam name="TValue">�ֵ��е�ֵ������</typeparam>
    public class GenericCache<TKey, TValue>
    {
        #region Fields
        /// <summary>
        /// �ڲ��� Dictionary ����
        /// </summary>
        private Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
        /// <summary>
        /// ���ڲ���ͬ�����ʵ� RW ������
        /// </summary>
        private ReaderWriterLock rwLock = new ReaderWriterLock();
        /// <summary>
        /// һ�� TimeSpan������ָ����ʱʱ�䡣 
        /// </summary>
        private readonly TimeSpan lockTimeOut = TimeSpan.FromMilliseconds(100);
        #endregion

        #region Methods
        /// <summary>
        /// ��ָ���ļ���ֵ��ӵ��ֵ��С�
        /// Exceptions��
        ///     ArgumentException - Dictionary ���Ѵ��ھ�����ͬ����Ԫ�ء�
        /// </summary>
        /// <param name="key">Ҫ��ӵ�Ԫ�صļ���</param>
        /// <param name="value">��ӵ�Ԫ�ص�ֵ�������������ͣ���ֵ����Ϊ ������</param>
        public void Add(TKey key, TValue value)
        {
            bool isExisting = false;
            rwLock.AcquireWriterLock(lockTimeOut);
            try
            {
                if (!dictionary.ContainsKey(key))
                    dictionary.Add(key, value);
                else
                    isExisting = true;
            }
            finally { rwLock.ReleaseWriterLock(); }
            if (isExisting) throw new ArgumentException();
        }

        /// <summary>
        /// ��ȡ��ָ���ļ��������ֵ�� 
        /// Exceptions��
        ///     ArgumentException - Dictionary ���Ѵ��ھ�����ͬ����Ԫ�ء�
        /// </summary>
        /// <param name="key">Ҫ��ӵ�Ԫ�صļ���</param>
        /// <param name="value">���˷�������ֵʱ������ҵ��ü�����᷵����ָ���ļ��������ֵ��
        /// ������᷵�� value ����������Ĭ��ֵ���ò���δ����ʼ����������</param>
        /// <returns>��� Dictionary ��������ָ������Ԫ�أ���Ϊ true������Ϊ false</returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            rwLock.AcquireReaderLock(lockTimeOut);
            bool result;
            try
            {
                result = dictionary.TryGetValue(key, out value);
            }
            finally { rwLock.ReleaseReaderLock(); }
            return result;
        }

        /// <summary>
        /// �� Dictionary ���Ƴ����еļ���ֵ��
        /// </summary>
        public void Clear()
        {
            if (dictionary.Count > 0)
            {
                rwLock.AcquireWriterLock(lockTimeOut);
                try
                {
                    dictionary.Clear();
                }
                finally { rwLock.ReleaseWriterLock(); }
            }
        }

        /// <summary>
        /// ȷ�� Dictionary �Ƿ����ָ���ļ��� 
        /// </summary>
        /// <param name="key">Ҫ�� Dictionary �ж�λ�ļ���</param>
        /// <returns>��� Dictionary ��������ָ������Ԫ�أ���Ϊ true������Ϊ false��</returns>
        public bool ContainsKey(TKey key)
        {
            if (dictionary.Count <= 0) return false;
            bool result;
            rwLock.AcquireReaderLock(lockTimeOut);
            try
            {
                result = dictionary.ContainsKey(key); 
            }
            finally { rwLock.ReleaseReaderLock(); }
            return result;
        }
        #endregion

        #region Properties
        /// <summary>
        /// ��ȡ������ Dictionary �еļ�/ֵ�Ե���Ŀ��
        /// </summary>
        public int Count
        {
            get { return dictionary.Count; }
        }
        #endregion
    }
}
