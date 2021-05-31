using System;
using System.Collections.Generic;
using System.Reflection;
namespace MarvellousWorks.PracticalPattern.Common
{
    /// <summary>
    /// ͨ������������ԣ�Attribute����Ϣ�Ĺ�����
    /// </summary>
    public static class AttributeHelper
    {
        /// <summary>
        /// ��ȡĳ�����Ͱ���ָ�����Եļ���
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IList<T> GetCustomAttributes<T>(Type type) where T : Attribute
        {
            if (type == null) throw new ArgumentNullException("type");
            T[] attributes = (T[])(type.GetCustomAttributes(typeof(T), false));
            return (attributes.Length == 0) ? null : new List<T>(attributes);
        }

        /// <summary>
        /// ���ĳ�����Ͱ���ָ�����Ե����з���
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IList<MethodInfo> GetMethodsWithCustomAttribute<T>(Type type) where T : Attribute
        {
            if (type == null) throw new ArgumentNullException("type");
            MethodInfo[] methods = type.GetMethods();
            if ((methods == null) || (methods.Length == 0)) return null;
            IList<MethodInfo> result = new List<MethodInfo>();
            foreach (MethodInfo method in methods)
                if(method.IsDefined(typeof(T), false))
                    result.Add(method);
            return result.Count == 0 ? null : result;
        }

        /// <summary>
        /// ��ȡĳ������ָ���������Եļ���
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method"></param>
        /// <returns></returns>
        public static IList<T> GetMethodCustomAttributes<T>(MethodInfo method) where T : Attribute
        {
            if (method == null) throw new ArgumentNullException("method");
            T[] attributes = (T[])(method.GetCustomAttributes(typeof(T), false));
            return (attributes.Length == 0) ? null: new List<T>(attributes);
        }

        /// <summary>
        /// ��ȡĳ������ָ�����͵�����
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method"></param>
        /// <returns></returns>
        public static T GetMethodCustomAttribute<T>(MethodInfo method) where T : Attribute
        {
            IList<T> attributes = GetMethodCustomAttributes<T>(method);
            return (attributes == null) ? null : attributes[0];
        }
    }
}
