using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
namespace Common
{
    /// <summary>
    /// 数据结构的定义
    /// </summary>
    [DataContract]
    public class Contact
    {
        [DataMember]
        public int Id;

        [DataMember]
        public string Title;

        [DataMember]
        public int Age;

        public Contact(int id, string title, int age)
        {
            this.Id = id;
            this.Title = title;
            this.Age = age;
        }
    }

    /// <summary>
    /// 具有DTO的服务接口的定义
    /// 为了简化，这里并没有列出原来的细颗粒度操作方法
    /// </summary>
    [ServiceContract]
    public interface IContact
    {
        [OperationContract]
        Contact CreateDTO(int id);

        [OperationContract]
        void SaveDTO(Contact dto);
    }
}