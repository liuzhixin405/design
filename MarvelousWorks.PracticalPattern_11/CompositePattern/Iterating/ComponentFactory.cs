using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.CompositePattern.Iterating
{
    /// <summary>
    /// 由于组合形式对象的特殊性，这个工厂同时具有工厂方法模式和抽象工厂模式的特点：
    /// T : Component, new() 体现出工厂方法的特点；但Create<T>其实相当于CreateComposite()、
    /// CreateLeaf()...的作用，体现抽象工厂特点。
    /// </summary>
    public class ComponentFactory
    {
        public Component Create<T>(string name) where T : Component, new()
        {
            T instance = new T();
            instance.Name = name;   // setter方式注入名称
            return instance;
        }

        /// <summary>
        /// 连贯性方法（Fluent Method）: 直接向某个节点下增加新的节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Component Create<T>(Component parent, string name)
            where T : Component, new()
        {
            if ((parent == null) || (!parent.GetType().IsAssignableFrom(typeof(Composite))))
                throw new ArgumentException("parent");
            Component instance = Create<T>(name);
            parent.Add(instance);
            return instance;
        }
    }
}
