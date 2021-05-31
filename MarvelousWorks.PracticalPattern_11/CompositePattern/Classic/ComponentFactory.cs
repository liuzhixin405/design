using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.CompositePattern.Classic
{
    /// <summary>
    /// ���������ʽ����������ԣ��������ͬʱ���й�������ģʽ�ͳ��󹤳�ģʽ���ص㣺
    /// T : Component, new() ���ֳ������������ص�
    /// ��Create<T>��ʵ�൱��CreateComposite()��CreateLeaf()...�����ã����ֳ��󹤳��ص㡣
    /// </summary>
    public class ComponentFactory
    {
        public Component Create<T>(string name) where T : Component, new()
        {
            T instance = new T();
            instance.Name = name;   // setter��ʽע������
            return instance;
        }

        /// <summary>
        /// �����Է�����Fluent Method��: ֱ����ĳ���ڵ��������µĽڵ�
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Component Create<T>(Component parent, string name)
            where T : Component, new()
        {
            if(parent == null) throw new ArgumentNullException("parent");
            if (!(parent is Composite)) throw new Exception("non-somposite type");
            Component instance = Create<T>(name);
            parent.Add(instance);
            return instance;
        }
    }
}
