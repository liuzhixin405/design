using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.ObserverPattern.Concept1
{
    /// <summary>
    /// A\B\C Ϊϣ�����X֪ͨ������ 
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
    /// X ���Լ����Ը��µ�ʱ����Ҫͬʱ֪ͨ�������
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
