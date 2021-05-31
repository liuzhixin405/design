using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.Concept.Operator
{
    public class Adaptee
    {
        // �����ݵĽӿڷ���
        public int Code { get { return new Random().Next(); } }
    }

    public class Target 
    {
        private int data;
        public Target(int data){this.data = data;}

        // Ŀ��ӿڷ���
        public int Data { get{return data;}}

        // ��ʽ����ת����������
        public static implicit operator Target(Adaptee adaptee)
        {
            return new Target(adaptee.Code);
        }
    }
}
