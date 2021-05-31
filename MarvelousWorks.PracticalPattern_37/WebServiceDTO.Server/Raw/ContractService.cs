//using System;
//using System.Collections.Generic;
//using Common;
//namespace Server
//{
//    /// <summary>
//    /// 用来模拟的联系人信息库
//    /// </summary>
//    internal class ContactStore : Dictionary<int, Contact>
//    {
//        public ContactStore()
//        {
//            Add(7, new Contact(7, "manager", 25));
//            Add(1, new Contact(1, "president", 34));
//            Add(23, new Contact(23, "sales", 22));
//        }
//    }

//    /// <summary>
//    /// 没有DTO的服务端对象设计
//    /// </summary>
//    public class ContractService : IContact
//    {
//        private ContactStore store = new ContactStore();

//        #region IContact Members
//        public string GetTitle(int id)
//        {
//            return store[id].Title;
//        }

//        public void SetTitle(int id, string title)
//        {
//            store[id].Title = title;
//        }

//        public int GetAge(int id)
//        {
//            return store[id].Age;
//        }

//        public void SetAge(int id, int age)
//        {
//            store[id].Age = age;
//        }
//        #endregion
//    }
//}
