using System;
using System.Diagnostics;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.VisitorPattern.Delegating
{
    /// <summary>
    /// visitor ��ҪӰ��� Element
    /// </summary>
    public interface IEmployee
    {
        /// <summary>
        /// �������
        /// </summary>
        string Name { get; set;}
        double Income { get; set;}
        int VacationDays { get; set;}

        void Accept(IVisitor visitor);
    }

    /// <summary>
    /// ����Visitor�ӿ�
    /// </summary>
    public interface IVisitor
    {
        void Visit(IEmployee employee);
    }

    /// <summary>
    /// һ�������Element�� Visitable
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
        /// ����Visitor������Ĳ���
        /// </summary>
        /// <param name="visitor"></param>
        public virtual void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// ��һ�������Element
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
    /// Ϊ�˱��ڶ�HRϵͳ�Ķ�����������������ӵļ�������
    /// </summary>
    public class EmployeeCollection : List<IEmployee>
    {
        /// <summary>
        /// �������������Accept����
        /// </summary>
        /// <param name="visitor"></param>
        public virtual void Accept(IVisitor visitor)
        {
            foreach (IEmployee employee in this)
                employee.Accept(visitor);
        }
    }
}
