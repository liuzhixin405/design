using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.Idiom.Mapper
{
    public class A
    {
        public int MethodA1(string str) { return 1; }
        public int MethodA2(string str) { return 2; }
        public int MethodA3(string str) { return 3; }
    }

    public class B
    {
        public string MethodB1(int x) { return "1"; }
        public string MethodB2(int y) { return "2"; }
    }

    public class Mapper
    {
        /// <summary>
        /// Source : A, Target : B
        /// </summary>
        public string Method1(string message)
        {
            A a = new A();
            B b = new B();
            int temp = a.MethodA1(message) + a.MethodA3(message);
            return b.MethodB2(temp);
        }

        /// <summary>
        /// Source B, Target A
        /// </summary>
        /// <param name="data"></param>
        public int Method2(int data)
        {
            A a = new A();
            B b = new B();
            string temp = b.MethodB2(200);
            return a.MethodA2(temp);
        }

        /// <summary>
        /// 无确定Source/Target的复杂交互过程
        /// </summary>
        /// <param name="data"></param>
        public void Method3(int data)
        {
            A a = new A();
            B b = new B();
            int x = a.MethodA2("hello");
            string str = b.MethodB2(x);
            string y = a.MethodA1(str) + b.MethodB1(20);
        }
    }
}
