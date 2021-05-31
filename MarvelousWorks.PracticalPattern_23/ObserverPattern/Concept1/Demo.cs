using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.ObserverPattern.Concept1
{
    /// <summary>
    /// A\B\C 为希望获得X通知的类型 
    /// </summary>
    public class A
    {
        public int Data;
        public void Update(int data) { this.Data = data; }
    }
    public class B
    {
        public int Count;
        public void NotifyCount(int data) { this.Count = data; }
    }
    public class C
    {
        public int N;
        public void Set(int data) { this.N = data; }
    }

    /// <summary>
    /// X 在自己属性更新的时候需要同时通知多个对象
    /// </summary>
    public class X
    {
        private int data;

        public A instanceA;
        public B instanceB;
        public C instanceC;

        public void SetData(int data)
        {
            this.data = data;
            instanceA.Update(data);
            instanceB.NotifyCount(data);
            instanceC.Set(data);
        }
    }
}
