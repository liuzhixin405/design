//using System;
//using System.Collections.Generic;
//using System.ServiceModel;
//using System.Runtime.Serialization;
//namespace Common
//{
//    /// ���ݽṹ�Ķ���
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


//    ///����ӿڵĶ���
//    [ServiceContract]
//    public interface IContact
//    {
//        #region ϸ�����ȵ����Է���
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
