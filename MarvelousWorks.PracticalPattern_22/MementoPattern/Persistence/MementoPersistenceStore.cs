using System;
using System.Collections.Generic;
using MarvellousWorks.PracticalPattern.Common;
namespace MarvellousWorks.PracticalPattern.MementoPattern.Persistence
{

    /// <summary>
    /// һ������ģ��ľ���־ö���
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MementoPersistenceStore<T>
        : IPersistenceStore<T>
        where T : IState
    {
        /// <summary>
        /// ģ��һ������ԭ�������͹���ĳ־û���
        /// </summary>
        private static IDictionary<KeyValuePair<string, int>, string>
            store = new Dictionary<KeyValuePair<string, int>, string>();

        /// <summary>
        /// �ѱ�����Ϣ������ģ��ĳ־ò������
        /// </summary>
        /// <param name="originatorID"></param>
        /// <param name="version"></param>
        /// <param name="target"></param>
        public void Store(string originatorID, int version, T target)
        {
            if (target == null) throw new ArgumentNullException("target");
            KeyValuePair<string, int> key =
                new KeyValuePair<string, int>(originatorID, version);
            string value = SerializationHelper.SerializeObjectToString(target);
            if (store.ContainsKey(key))
                store[key] = value;     // ���¼��а汾��������
            else
                store.Add(key, value);  // ����һ���°汾�ı�������
        }

        /// <summary>
        /// �ӳ־ö����ñ�����Ϣ
        /// </summary>
        /// <param name="originatorID"></param>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public T Find(string originatorID, int version)
        {
            KeyValuePair<string, int> key =
                new KeyValuePair<string, int>(originatorID, version);
            string value;
            if (!store.TryGetValue(key, out value))
                throw new NullReferenceException();
            return SerializationHelper.DeserializeStringToObject<T>(value);
        }
    }

}
