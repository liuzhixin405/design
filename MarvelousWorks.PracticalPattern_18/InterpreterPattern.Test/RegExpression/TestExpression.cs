using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.InterpreterPattern.RegExpression;
namespace MarvellousWorks.PracticalPattern.InterpreterPattern.Test.RegExpression
{
    [TestClass]
    public class TestExpression
    {
        [TestMethod]
        public void TestEmailExpression()
        {
            Context context = new Context();
            context.Content = "zhao@hotmail.com, liu@gmail.com, test";
            context.Operator = 'M'; // 查找匹配信息
            IRegExpression expression = new EmailRegExpression();
            expression.Evaluate(context);
            // 确认是否发现其中包括两个Email信息
            Assert.AreEqual<int>(2, context.Matches.Count);
            Assert.AreEqual<string>("zhao@hotmail.com", context.Matches[0]);
            Assert.AreEqual<string>("liu@gmail.com", context.Matches[1]);
        }

        [TestMethod]
        public void TestChineseExpression()
        {
            Context context = new Context();
            context.Content = "测试";
            context.Operator = 'M'; // 查找匹配信息
            IRegExpression expression = new ChineseRegExpression();
            expression.Evaluate(context);
            Assert.AreEqual<int>(1, context.Matches.Count);
            context.Content = "测试test";
            expression.Evaluate(context);
            Assert.AreEqual<int>(0, context.Matches.Count);
        }

        [TestMethod]
        public void TestReplacement()
        {
            Context context = new Context();
            context.Content = "a   b   c   d";
            context.Operator = 'R'; // 查找匹配信息
            context.Replacement = ",";
            IRegExpression expression = new StringRegExpression(@"\s+");
            expression.Evaluate(context);
            Assert.AreEqual<string>("a,b,c,d", context.Content);
        }
    }
}
