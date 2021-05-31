using System;
using System.Collections.Generic;
using System.Reflection;
namespace MarvellousWorks.PracticalPattern.Common
{
    /// <summary>
    /// 通过反射访问属性（Attribute）信息的工具类
    /// </summary>
    public static class AttributeHelper
    {
        /// <summary>
        /// 获取某个类型包括指定属性的集合
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
        /// 获得某各类型包括指定属性的所有方法
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
        /// 获取某个方法指定类型属性的集合
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
        /// 获取某个方法指定类型的属性
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
