using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.TemplatePattern.Multiple;
namespace MarvellousWorks.PracticalPattern.TemplatePattern.Test.Multiple
{
    [TestClass]
    public class TestTemplate
    {
        [TestMethod]
        public void Test()
        {
            string data;

            // ��ITransform �ĽǶȿ�
            ITransform transform = new DataBroker();
            data = "1X2X";
            Assert.AreEqual<string>("1Y2Y", transform.Transform(data));

            // ��ISetter �ĽǶȿ�
            ISetter setter = new DataBroker();
            data = "H:123";
            Assert.AreEqual<string>("H:123:T", setter.Append(data));
        }
    }
}
