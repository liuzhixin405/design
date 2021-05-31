//using System;
//using System.Collections.Generic;
//using System.ServiceModel;
//using System.Runtime.Serialization;
//namespace Common
//{
//    /// 数据结构的定义
//    [DataContract]
//    public class Contact
//    {
//        [DataMember]
//        public int Id;
//        [DataMember]
//        public string Title;
//        [DataMember]
//        public int Age;

//        public Contact(int id, string title, int age)
//        {
//            this.Id = id;
//            this.Title = title;
//            this.Age = age;
//        }
//    }


//    ///服务接口的定义
//    [ServiceContract]
//    public interface IContact
//    {
//        #region 细颗粒度的属性访问
//        [OperationContract]
//        string GetTitle(int id);

//        [OperationContract]
//        void SetTitle(int id, string title);

//        [OperationContract]
//        int GetAge(int id);

//        [OperationContract]
//        void SetAge(int id, int age);
//        #endregion
//    }

//}
