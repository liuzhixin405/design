using System;
using System.Diagnostics;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.VisitorPattern.Delegating
{
    /// <summary>
    /// visitor 需要影响的 Element
    /// </summary>
    public interface IEmployee
    {
        /// <summary>
        /// 相关属性
        /// </summary>
        string Name { get; set;}
        double Income { get; set;}
        int VacationDays { get; set;}

        void Accept(IVisitor visitor);
    }

    /// <summary>
    /// 抽象Visitor接口
    /// </summary>
    public interface IVisitor
    {
        void Visit(IEmployee employee);
    }

    /// <summary>
    /// 一个具体的Element， Visitable
    /// </summary>
    public class Employee : IEmployee
    {
        private string name;
        private double income;
        private int vacationDays;

        public Employee(string name, double income, int vacationDays)
        {
            this.name = name;
            this.income = income;
            this.vacationDays = vacationDays;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Income
        {
            get { return income; }
            set { income = value; }
        }
        public int VacationDays
        {
            get { return vacationDays; }
            set { vacationDays = value; }
        }

        /// <summary>
        /// 引入Visitor对自身的操作
        /// </summary>
        /// <param name="visitor"></param>
        public virtual void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// 另一个具体的Element
    /// </summary>
    public class Manager : Employee
    {
        private string department;
        public string Department { get { return department; } }

        public Manager(string name, double income, int vacationDays, string department)
            : base(name, income, vacationDays)
        {
            this.department = department;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// 为了便于对HR系统的对象进行批量处理增加的集合类型
    /// </summary>
    public class EmployeeCollection : List<IEmployee>
    {
        /// <summary>
        /// 组合起来的批量Accept操作
        /// </summary>
        /// <param name="visitor"></param>
        public virtual void Accept(IVisitor visitor)
        {
            foreach (IEmployee employee in this)
                employee.Accept(visitor);
        }
    }
}
