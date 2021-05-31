using System;
using System.Collections.Generic;
//using Common;
using System.ServiceModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.WebServiceDTO.Client.ContactService;
namespace WebServiceDTO.Client
{

    class Program
    {
        static void Main(string[] args)
        {
            using (ContactClient client = new ContactClient())
            {
                //Add(7, new Contact(7, "manager", 25));
                Console.WriteLine("Press any key when service started ...");
                Console.ReadLine();

                // 提取一个对象的相关属性只需要1次调用
                Contact contact = client.CreateDTO(7);
                Assert.AreEqual<string>("manager", contact.Title);
                Assert.AreEqual<int>(25, contact.Age);
                Console.WriteLine("7\t" + contact.Title + "\t" + contact.Age);

                // 修改一个对象只需1次调用
                contact.Title = "vice president";
                contact.Age = 30;
                Assert.AreEqual<string>("vice president", contact.Title);
                Assert.AreEqual<int>(30, contact.Age);
                Console.WriteLine("7\t" + contact.Title + "\t" + contact.Age);

                Console.ReadLine();
            }
        }
    }
}



