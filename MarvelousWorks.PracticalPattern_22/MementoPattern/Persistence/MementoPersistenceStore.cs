using System;
using System.Collections.Generic;
using MarvellousWorks.PracticalPattern.Common;
namespace MarvellousWorks.PracticalPattern.MementoPattern.Persistence
{

    /// <summary>
    /// 一个用于模拟的具体持久对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MementoPersistenceStore<T>
        : IPersistenceStore<T>
        where T : IState
    {
        /// <summary>
        /// 模拟一个所有原发器类型共享的持久机制
        /// </summary>
        private static IDictionary<KeyValuePair<string, int>, string>
            store = new Dictionary<KeyValuePair<string, int>, string>();

        /// <summary>
        /// 把备忘信息保存在模拟的持久层对象里
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
                store[key] = value;     // 更新既有版本备忘内容
            else
                store.Add(key, value);  // 增加一个新版本的备忘内容
        }

        /// <summary>
        /// 从持久对象获得备忘信息
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
