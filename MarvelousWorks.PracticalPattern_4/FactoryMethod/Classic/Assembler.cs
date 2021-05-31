using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections.Specialized;
namespace MarvellousWorks.PracticalPattern.FactoryMethod.Classic
{
    public class Assembler
    {
        /// <summary>
        /// 配置节名称
        /// </summary>
        private const string SectionName =
            "marvellousWorks.practicalPattern.factoryMethod.customFactories";

        /// <summary>
        /// IFactory的QualifiedName名称
        /// </summary>
        private const string FactoryTypeName = "IFactory";

        /// <summary>
        /// 保存“抽象类型/实体类型”对应关系的字典
        /// </summary>
        private static Dictionary<Type, Type> dictionary = new Dictionary<Type, Type>();

        static Assembler()
        {
            // 通过配置文件加载相关“抽象产品类型”/ “实体产品类型”映射关系
            NameValueCollection collection =
                (NameValueCollection)ConfigurationSettings.GetConfig(SectionName);
            for (int i = 0; i < collection.Count; i++)
            {
                string target = collection.GetKey(i);
                string source = collection[i];
                dictionary.Add(Type.GetType(target), Type.GetType(source));
            }
        }

        /// <summary>
        /// 根据客户程序需要的抽象类型选择相应的实体类型，并返回类型实例
        /// </summary>
        /// <typeparam name="T">抽象类型（抽象类/接口/或者某种基类）</typeparam>
        /// <returns>实体类型实例</returns>
        public object Create(Type type)     // 主要用于非泛型方式调用
        {
            if ((type == null) || !dictionary.ContainsKey(type)) throw new NullReferenceException();
            Type targetType = dictionary[type];
            return Activator.CreateInstance(targetType);
        }

        /// <typeparam name="T">抽象类型（抽象类/接口/或者某种基类）</typeparam>
        public T Create<T>()    // 主要用于泛型方式调用
        {
            return (T)Create(typeof(T));
        }
    }
}
