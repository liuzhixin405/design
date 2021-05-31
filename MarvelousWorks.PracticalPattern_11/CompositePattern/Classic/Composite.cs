using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.CompositePattern.Classic
{
    public abstract class Component
    {
        /// <summary>
        /// �����ӽڵ�
        /// </summary>
        protected IList<Component> children;

        /// <summary>
        /// Leaf��Composite�Ĺ�ͬ����. setter��ʽע������
        /// </summary>
        protected string name;
        public virtual string Name 
        { 
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// ��ʵֻ��Composite���Ͳ���Ҫ����ʵ�ֵĹ���
        /// </summary>
        /// <param name="child"></param>
        public virtual void Add(Component child){children.Add(child);}
        public virtual void Remove(Component child) { children.Remove(child); }
        public virtual Component this[int index] { get { return children[index]; } }
        
        /// <summary>
        /// ��ʾ�õĲ��䷽����ʵ�ֵ����������Ҷ���������ʵ�����Եݹ�
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> GetNameList()  
        {
            yield return name;
            if ((children != null) && (children.Count > 0))
                foreach (Component child in children)
                    foreach (string item in child.GetNameList())
                        yield return item;
        }
    }

    public class Leaf : Component
    {
        /// <summary>
        /// ��ȷ������֧�ִ������
        /// </summary>
        /// <param name="child"></param>
        public override void Add(Component child) { throw new NotSupportedException(); }
        public override void Remove(Component child) { throw new NotSupportedException(); }
        public override Component this[int index] { get { throw new NotSupportedException(); } }
    }

    public class Composite : Component
    {
        public Composite() { base.children = new List<Component>(); }
    }
}
