using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.CompositePattern.Classic
{
    public abstract class Component
    {
        /// <summary>
        /// 保存子节点
        /// </summary>
        protected IList<Component> children;

        /// <summary>
        /// Leaf和Composite的共同特征. setter方式注入名称
        /// </summary>
        protected string name;
        public virtual string Name 
        { 
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// 其实只有Composite类型才需要真正实现的功能
        /// </summary>
        /// <param name="child"></param>
        public virtual void Add(Component child){children.Add(child);}
        public virtual void Remove(Component child) { children.Remove(child); }
        public virtual Component this[int index] { get { return children[index]; } }
        
        /// <summary>
        /// 演示用的补充方法：实现迭代器，并且对容器对象实现隐性递归
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
        /// 明确声明不支持此类操作
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
