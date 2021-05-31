using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using MarvellousWorks.PracticalPattern.Concept.Iterating;
using System.Collections;
namespace MarvellousWorks.PracticalPattern.Concept.Test
{
    [TestClass()]
    public class CompositeIteratorTest
    {
        [TestMethod]
        public void Test()
        {
            #region 准备测试数据
            // stack<T>
            Stack<ObjectWithName> stack = new Stack<ObjectWithName>();
            stack.Push(new ObjectWithName("2"));
            stack.Push(new ObjectWithName("1"));

            // Queue<T>
            Queue<ObjectWithName> queue = new Queue<ObjectWithName>();
            queue.Enqueue(new ObjectWithName("3"));
            queue.Enqueue(new ObjectWithName("4"));

            // T[]
            ObjectWithName[] array = new ObjectWithName[3];
            array[0] = new ObjectWithName("5");
            array[1] = new ObjectWithName("6");
            array[2] = new ObjectWithName("7");

            // BinaryTree
            BinaryTreeNode root = new BinaryTreeNode("8");
            root.Left = new BinaryTreeNode("9");
            root.Right = new BinaryTreeNode("10");
            root.Right.Left = new BinaryTreeNode("11");
            root.Right.Left.Left = new BinaryTreeNode("12");
            root.Right.Left.Right = new BinaryTreeNode("13");
            root.Right.Right = new BinaryTreeNode("14");
            root.Right.Right.Right = new BinaryTreeNode("15");
            root.Right.Right.Right.Right = new BinaryTreeNode("16");

            // 合并所有 IEnumerator 对象
            CompositeIterator iterator = new CompositeIterator();
            iterator.Add(stack);
            iterator.Add(queue);
            iterator.Add(array);
            iterator.Add(root);
            #endregion

            int count = 0;
            foreach (ObjectWithName obj in iterator)
                Assert.AreEqual<string>((++count).ToString(), obj.ToString());
            System.Diagnostics.Trace.WriteLine(count);
        }
    }
}
