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
        /// 测试用的可序列化类型
        /// </summary>
        [Serializable]
        class UserInfo
        {
            public string Name;
            public IList<string> Education = new List<string>(); /// 引用类型

            public UserInfo GetShallowCopy() { return (UserInfo)this.MemberwiseClone(); }
            public UserInfo GetDeepCopy()
            {
                string graph = SerializationHelper.SerializeObjectToString(this);
                return SerializationHelper.DeserializeStringToObject<UserInfo>(graph);
            }
        }

        /// <summary>
        /// 验证对可序列化类型进行浅表复制
        /// </summary>
        [TestMethod]
        public void ShallowCopyTest()
        {
            UserInfo user1 = new UserInfo();
            user1.Name = "joe";
            user1.Education.Add("A");
            UserInfo user2 = user1.GetShallowCopy();
            // 验证可以完成某种程度的复制
            Assert.AreEqual<string>(user1.Name, user2.Name);
            Assert.AreEqual<string>(user1.Education[0], user2.Education[0]);
            // 验证Shallow Copy方式下，没有对引用类型作出处理
            user2.Education[0] = "B";
            Assert.AreNotEqual<string>("A", user1.Education[0]);
        }

        /// <summary>
        /// 验证对可序列化类型进行深层复制
        /// </summary>
        [TestMethod]
        public void DeepCopyTest()
        {
            UserInfo user1 = new UserInfo();
            user1.Name = "joe";
            user1.Education.Add("A");
            UserInfo user2 = user1.GetDeepCopy();
            // 验证可以完成某种程度的复制
            Assert.AreEqual<string>(user1.Name, user2.Name);
            Assert.AreEqual<string>(user1.Education[0], user2.Education[0]);
            // 验证Deep Copy方式下，可以对引用类型作出处理
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
    //        ///执行出错，会提示Outer类型没有被标明 [Serializable]
    //        string graph = SerializationHelper.SerializeObjectToString(this);
    //    }
    //}
}
