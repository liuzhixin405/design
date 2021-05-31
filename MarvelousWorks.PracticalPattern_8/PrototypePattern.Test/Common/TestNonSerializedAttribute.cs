using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Common;
namespace MarvellousWorks.PracticalPattern.PrototypePattern.Test.Common
{
    [TestClass]
    public class TestNonSerializedAttribute
    {
        [Serializable]
        class UserInfo
        {
            [NonSerialized]
            public string[] Parents;
        }

        [TestMethod]
        public void Test()
        {
            UserInfo user1 = new UserInfo();
            user1.Parents = new string[2];
            Assert.IsNotNull(user1.Parents);    // 克隆前已经非空
            string graph = SerializationHelper.SerializeObjectToString(user1);
            UserInfo user2 = SerializationHelper.DeserializeStringToObject<UserInfo>(graph);
            Assert.IsNull(user2.Parents);   // 但克隆后为空
        }
    }
}
