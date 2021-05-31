using System;
using System.Collections.Generic;
using System.Reflection;
namespace MarvellousWorks.PracticalPattern.BuilderPattern.Generics
{
    /// <summary>
    /// 指导每个具体类型BuildPart过程目标方法和执行情况的属性
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
        /// 该 Attribute 需要执行的目标方法
        /// </summary>
        public MethodInfo Handler
        {
            get { return handler; }
            set { this.handler = value; }
        }

        /// <summary>
        /// 标注为这个Attribute的方法，在执行过程中的次序
        /// </summary>
        public int Sequence { get { return this.sequence; } }

        /// <summary>
        /// 标注为这个Attribute的方法，在执行过程中执行的次数
        /// </summary>
        public int Times { get { return this.times; } }

        /// <summary>
        /// 确保每个BuildStepAttribute可以根据sequence比较执行次序
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
