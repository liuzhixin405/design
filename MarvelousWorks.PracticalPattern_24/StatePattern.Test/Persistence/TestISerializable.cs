using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Common;
namespace MarvellousWorks.PracticalPattern.StatePattern.Test.Persistence
{
    public class TestISerializable
    {
        /// <summary>
        /// �������л����̵Ķ���
        /// </summary>
        [Serializable]
        public class Target : ISerializable
        {
            public int x;
            public int y;
            public String message;

            public Target() { }

            protected Target(SerializationInfo info, StreamingContext context)
            {
                x = info.GetInt32("x");
                message = info.GetString("message");
            }

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("x", x);
                info.AddValue("message", message);
            }
        }

        /// <summary>
        /// ��֤�������л�
        /// </summary>
        [TestMethod]
        public void Test()
        {
            Target obj = new Target();
            obj.x = 1;
            obj.y = 2;
            obj.message = "hello";
            string graph = SerializationHelper.SerializeObjectToString(obj);
            Target target = SerializationHelper.DeserializeStringToObject<Target>(graph);
            Assert.AreEqual<int>(0, target.y);     // û�б������л��Ĳ���
            Assert.AreEqual<int>(1, target.x);
            Assert.AreEqual<string>("hello", target.message);
        }
    }
}
