using System;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.VisitorPattern.Reflection;
namespace MarvellousWorks.PracticalPattern.VisitorPattern.Test.Reflection
{
    [TestClass]
    public class TestVisitor
    {
        public class ReflectionVisitor : IVisitor
        {
            /// <summary>
            /// 通过反射和预订好的方法命名规则动态执行
            /// </summary>
            /// <param name="employee"></param>
            public void Visit(IEmployee employee)
            {
                string typeName = employee.GetType().Name;
                string methodName = "Visit" + typeName;
                MethodInfo method = this.GetType().GetMethod(methodName);
                method.Invoke(this, new object[] { employee });
            }

            public void VisitEmployee(IEmployee employee)
            {
                employee.Income *= 1.1;
                employee.VacationDays += 1;
            }

            public void VisitManager(IEmployee employee)
            {
                Manager manager = (Manager)employee;
                manager.Income *= 1.2;
                manager.VacationDays += 2;
            }
        }

        private EmployeeCollection employees = new EmployeeCollection();

        [TestMethod]
        public void Test()
        {
            employees.Add(new Employee("joe", 25000, 14));
            employees.Add(new Manager("alice", 22000, 14, "sales"));
            employees.Add(new Employee("peter", 15000, 7));

            employees.Accept(new ReflectionVisitor());

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
