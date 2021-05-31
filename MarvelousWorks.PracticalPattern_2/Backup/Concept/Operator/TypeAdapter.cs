using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.Concept.Operator
{
    public class Adaptee
    {
        // 不兼容的接口方法
        public int Code { get { return new Random().Next(); } }
    }

    public class Target 
    {
        private int data;
        public Target(int data){this.data = data;}

        // 目标接口方法
        public int Data { get{return data;}}

        // 隐式类型转换进行适配
        public static implicit operator Target(Adaptee adaptee)
        {
            return new Target(adaptee.Code);
        }
    }
}
