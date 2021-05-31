using System;
using System.Collections;
namespace MarvellousWorks.PracticalPattern.Concept.Iterating
{
    public class ObjectWithName
    {
        private string name;
        public ObjectWithName(string name) { this.name = name; }
        public override string ToString() { return name; }
    }

    public class BinaryTreeNode : ObjectWithName
    {
        private string name;
        public BinaryTreeNode(string name) : base(name) { }

        public BinaryTreeNode Left = null;
        public BinaryTreeNode Right = null;
        public IEnumerator GetEnumerator()
        {
            yield return this;
            if (Left != null)
                foreach (ObjectWithName item in Left)
                    yield return item;
            if (Right != null)
                foreach (ObjectWithName item in Right)
                    yield return item;
        }
    }
}
