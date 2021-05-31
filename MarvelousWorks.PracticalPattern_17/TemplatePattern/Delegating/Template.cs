using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.TemplatePattern.Delegating
{
    /// <summary>
    /// �¼������൱�ڳ����㷨�����ݽṹԼ��
    /// </summary>
    public class CounterEventArgs : EventArgs
    {
        private int value;
        public CounterEventArgs(int value){this.value = value;}
        public int Value{get{return this.value;}}
    }

    /// <summary>
    /// �����¼��൱�ڳ����������ڹ�񣬶������㷨Ϊ.NET���¼���Ӧ����
    /// </summary>
    public class Counter
    {
        private int value = 0;
        public event EventHandler<CounterEventArgs> Changed;
        public void Add()
        {
            value++;
            Changed(this, new CounterEventArgs(value));
        }
    }
}
