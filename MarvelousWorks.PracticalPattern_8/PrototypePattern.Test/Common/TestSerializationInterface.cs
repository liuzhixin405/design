using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.Common;
using System.Runtime.Serialization;
namespace MarvellousWorks.PracticalPattern.PrototypePattern.Test.Common
{
[Serializable]
class UserInfo : ISerializable
{
    public string Name;
    public int Age;
    public IList<string> Education = new List<string>();

    public UserInfo() { }
    protected UserInfo(SerializationInfo info, StreamingContext context) // ��ԭ����
    {
        this.Name = info.GetString("Name");
        this.Education = (IList<string>)info.GetValue("Education", typeof(IList<string>));
    }

    /// <summary>
    /// �������л����̣������л��������ݣ�Name �� Education ��¼��ǰ����
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("Name", this.Name);
        IList<string> education = new List<string>();
        if (this.Education.Count > 0)
            for (int i = 0; i < (Education.Count > 3 ? 3 : Education.Count); i++)
                education.Add(this.Education[i]);   
        info.AddValue("Education", education);
    }
}

[TestClass]
public class TestSerializationInterface
{
    [TestMethod]
    public void Test()
    {
        UserInfo user1 = new UserInfo();
        user1.Name = "joe";
        user1.Age = 20;
        user1.Education.Add("A");
        user1.Education.Add("B");
        user1.Education.Add("C");
        user1.Education.Add("D");

        string graph = SerializationHelper.SerializeObjectToString(user1);
        UserInfo user2 = SerializationHelper.DeserializeStringToObject<UserInfo>(graph);
        Assert.AreEqual<int>(3, user2.Education.Count);     // �����л�ǰ����
        Assert.AreNotEqual<int>(user1.Age, user2.Age);      // ��ΪAgeû�б����л�
        Assert.AreEqual<string>(user1.Name, user2.Name);    // Name�����л���
    }
}
}
