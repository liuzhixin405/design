using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Common;
namespace MarvellousWorks.PracticalPattern.PrototypePattern.Test.Common
{
    [TestClass]
    public class TestSerializationHelper
    {
        /// <summary>
        /// �����õĿ����л�����
        /// </summary>
        [Serializable]
        class UserInfo
        {
            public string Name;
            public IList<string> Education = new List<string>(); /// ��������

            public UserInfo GetShallowCopy() { return (UserInfo)this.MemberwiseClone(); }
            public UserInfo GetDeepCopy()
            {
                string graph = SerializationHelper.SerializeObjectToString(this);
                return SerializationHelper.DeserializeStringToObject<UserInfo>(graph);
            }
        }

        /// <summary>
        /// ��֤�Կ����л����ͽ���ǳ����
        /// </summary>
        [TestMethod]
        public void ShallowCopyTest()
        {
            UserInfo user1 = new UserInfo();
            user1.Name = "joe";
            user1.Education.Add("A");
            UserInfo user2 = user1.GetShallowCopy();
            // ��֤�������ĳ�̶ֳȵĸ���
            Assert.AreEqual<string>(user1.Name, user2.Name);
            Assert.AreEqual<string>(user1.Education[0], user2.Education[0]);
            // ��֤Shallow Copy��ʽ�£�û�ж�����������������
            user2.Education[0] = "B";
            Assert.AreNotEqual<string>("A", user1.Education[0]);
        }

        /// <summary>
        /// ��֤�Կ����л����ͽ�����㸴��
        /// </summary>
        [TestMethod]
        public void DeepCopyTest()
        {
            UserInfo user1 = new UserInfo();
            user1.Name = "joe";
            user1.Education.Add("A");
            UserInfo user2 = user1.GetDeepCopy();
            // ��֤�������ĳ�̶ֳȵĸ���
            Assert.AreEqual<string>(user1.Name, user2.Name);
            Assert.AreEqual<string>(user1.Education[0], user2.Education[0]);
            // ��֤Deep Copy��ʽ�£����Զ�����������������
            user2.Education[0] = "B";
            Assert.AreEqual<string>("A", user1.Education[0]);
        }
    }

    //class Inner { }
    //class Middle { private Inner sub = new Inner();}
    //class Outer { private Middle sub = new Middle();}

    //[Serializable]
    //[TestClass]
    //public class CannotPass
    //{
    //    private Outer sub = new Outer();

    //    [TestMethod]
    //    public void Test()
    //    {
    //        ///ִ�г�������ʾOuter����û�б����� [Serializable]
    //        string graph = SerializationHelper.SerializeObjectToString(this);
    //    }
    //}
}
