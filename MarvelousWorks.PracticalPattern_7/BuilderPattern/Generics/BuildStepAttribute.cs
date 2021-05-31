using System;
using System.Collections.Generic;
using System.Reflection;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Generics
{
    /// <summary>
    /// ָ��ÿ����������BuildPart����Ŀ�귽����ִ�����������
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class BuildStepAttribute : Attribute, IComparable
    {
        private int sequence;
        private int times;
        private MethodInfo handler;

        public BuildStepAttribute(int sequence, int times)
        {
            this.sequence = sequence;
            this.times = times;
        }
        public BuildStepAttribute(int sequence) : this(sequence, 1) { }

        /// <summary>
        /// �� Attribute ��Ҫִ�е�Ŀ�귽��
        /// </summary>
        public MethodInfo Handler
        {
            get { return handler; }
            set { this.handler = value; }
        }

        /// <summary>
        /// ��עΪ���Attribute�ķ�������ִ�й����еĴ���
        /// </summary>
        public int Sequence { get { return this.sequence; } }

        /// <summary>
        /// ��עΪ���Attribute�ķ�������ִ�й�����ִ�еĴ���
        /// </summary>
        public int Times { get { return this.times; } }

        /// <summary>
        /// ȷ��ÿ��BuildStepAttribute���Ը���sequence�Ƚ�ִ�д���
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public int CompareTo(object target)
        {
            if ((target == null) || (target.GetType() != typeof(BuildStepAttribute)))
                throw new ArgumentException("target");
            return this.sequence - ((BuildStepAttribute)target).sequence;
        }
    }
}
