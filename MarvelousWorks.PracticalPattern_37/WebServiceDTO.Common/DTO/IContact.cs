using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
namespace Common
{
    /// <summary>
    /// ���ݽṹ�Ķ���
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
    /// ����DTO�ķ���ӿڵĶ���
    /// Ϊ�˼򻯣����ﲢû���г�ԭ����ϸ�����Ȳ�������
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