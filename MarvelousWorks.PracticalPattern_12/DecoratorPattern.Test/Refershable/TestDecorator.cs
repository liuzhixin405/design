using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using MarvellousWorks.PracticalPattern.DecoratorPattern.Refershable;
namespace MarvellousWorks.PracticalPattern.DecoratorPattern.Test.Refershable
{
    [TestClass]
    public class TestDecorator
    {
        [TestMethod]
        public void Test()
        {
            // �������󣬲������������װ�Ρ� bold = false, color= black
            IText text = new TextObject();
            text = new BoldDecorator(text);
            text = new ColorDecorator(text);
            Assert.AreEqual<string>("<Black>hello</Black>", text.Content);

            // ��̬�ҵ���Ҫ���µ�Decorator���޸���Ӧ����
            // bold = false, color = red
            ColorState newColorState = new ColorState();
            newColorState.Color = Color.Red;
            IDecorator root = (IDecorator)text;
            root.Refresh<ColorDecorator>(newColorState);
            Assert.AreEqual<string>("<Red>hello</Red>", text.Content);

            // ��̬�ҵ���Ҫ���µ�Decorator���޸���Ӧ����
            // bold = true, color = red
            BoldState newBoldState = new BoldState();
            newBoldState.IsBold = true;
            root.Refresh<BoldDecorator>(newBoldState);
            Assert.AreEqual<string>("<Red><b>hello</b></Red>", text.Content);
        }
    }
}
