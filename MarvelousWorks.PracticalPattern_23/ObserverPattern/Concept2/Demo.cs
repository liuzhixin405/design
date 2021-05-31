using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.ObserverPattern.Concept2
{
    /// <summary>
    /// ������A/B/C�������Ľӿ�
    /// </summary>
    public interface IUpdatableObject
    {
        int Data { get;}
        void Update(int newData);
    }

    /// <summary>
    /// ����Ĵ���������
    /// </summary>
    public class A : IUpdatableObject
    {
        private int data;
        public int Data{get { return this.data;}}
        public void Update(int newData) { this.data = newData; }
    }
    public class B : IUpdatableObject
    {
        private int count;
        public int Data { get { return this.count; } }
        public void Update(int newData) { this.count = newData; }

    }
    public class C : IUpdatableObject
    {
        private int n;
        public int Data { get { return this.n; } }
        public void Update(int newData) { this.n = newData; }
    }


    public class X
    {
        private IUpdatableObject[] objects = new IUpdatableObject[3];
        public IUpdatableObject this[int index] { set { objects[index] = value; } }

        private int data;
        public void Update(int newData)
        {
            this.data = newData;
            foreach (IUpdatableObject obj in objects)
                obj.Update(newData);
        }
    }
}
