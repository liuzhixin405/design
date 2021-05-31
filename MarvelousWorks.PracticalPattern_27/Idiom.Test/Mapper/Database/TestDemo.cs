using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Idiom.Mapper.Database;
namespace MarvellousWorks.PracticalPattern.Idiom.Test.Mapper.Database
{
    [TestClass]
    public class TestDemo
    {
        /// <summary>
        /// <map source="id" target="CustomerID"/>
        /// <map source="CompanyName" target="Company"/>
        /// <map source="phone" target="Phone"/>
        /// </summary>
        class Customer : IBusinessObject
        {
            #region 定义了映射关系的属性

            private string customerID;
            public string CustomerID
            {
                get{return customerID;}
                set{customerID = value;}
            }

            private string company;
            public string Company
            {
                get{return company;}
                set{company = value;}
            }

            private string phone;
            public string Phone
            {
                get{return phone;}
                set{phone = value;}
            }
            #endregion

            #region 没有定义映射关系的属性
            private string note;
            public string Note
            {
                get{return note;}
                set{note = value;}
            }
            #endregion
        }

        private DataRow CreateTestData()
        {
            DataTable table = new DataTable();
            table.Columns.Add("id");
            table.Columns.Add("companyName");
            table.Columns.Add("phone");

            DataRow row = table.NewRow();
            row["id"] = "A";
            row["companyName"] = "B";
            //row["phone"] = DBNull.Value;

            return row;
        }

        [TestMethod]
        public void TestMapper()
        {
            DataMapper<Customer> mapper = new DataMapper<Customer>("customer");
            DataRow row = CreateTestData();
            Customer customer = new Customer();

            // 通过DataMapper 完成关系数据向数据实体的映射
            mapper.SetPropertyValues(customer, row);

            // 配置了映射关系的属性
            Assert.AreEqual<string>("A", customer.CustomerID);
            Assert.AreEqual<string>("B", customer.Company);
            Assert.IsTrue(string.IsNullOrEmpty(customer.Phone));

            // 没有配置映射关系的属性
            Assert.IsTrue(string.IsNullOrEmpty(customer.Note));
        }
    }
}
