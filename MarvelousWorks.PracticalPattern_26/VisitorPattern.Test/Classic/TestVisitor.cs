using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.VisitorPattern.Classic;
namespace MarvellousWorks.PracticalPattern.VisitorPattern.Test.Classic
{
    [TestClass]
    public class TestVisitor
    {
        private EmployeeCollection employees = new EmployeeCollection();

        /// <summary>
        /// 具体的Visitor, 增加休假天数
        /// </summary>
        class ExtraVacationVisitor : IVisitor
        {
            public void VisitEmployee(IEmployee employee)
            {
                employee.VacationDays += 1;
            }

            public void VisitManager(Manager manager)
            {
                manager.VacationDays += 2;
            }
        }
        /// <summary>
        /// 具体的Visitor, 加薪
        /// </summary>
        class RaiseSalaryVisitor : IVisitor
        {
            public void VisitEmployee(IEmployee employee)
            {
                employee.Income *= 1.1;
            }

            public void VisitManager(Manager manager)
            {
                manager.Income *= 1.2;
            }
        }

        [TestMethod]
        public void Test()
        {
            employees.Add(new Employee("joe", 25000, 14));
            employees.Add(new Manager("alice", 22000, 14, "sales"));
            employees.Add(new Employee("peter", 15000, 7));

            employees.Accept(new ExtraVacationVisitor());
            employees.Accept(new RaiseSalaryVisitor());

            IEmployee joe = employees[0];
            Assert.AreEqual<double>(25000 * 1.1, joe.Income);
            IEmployee peter = employees[2];
            Assert.AreEqual<int>(7 + 1, peter.VacationDays);

            IEmployee alice = employees[1];
            Assert.AreEqual<int>(14 + 2, alice.VacationDays);
            Assert.AreEqual<double>(22000 * 1.2, alice.Income);
        }
    }
}
