using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.InterpreterPattern.DictionaryExpression;
namespace MarvellousWorks.PracticalPattern.InterpreterPattern.Test.DictionaryExpression
{
    [TestClass]
    public class TestExpression
    {
        enum Color { Red, Green, Blue }

        private IDictionary<string, string> data;
        private void PreProcess()
        {
            data = new Dictionary<string, string>();
            data.Add("R", "Red");
            data.Add("G", "Green");
            data.Add("B", "Blue");
        }

        [TestMethod]
        public void Test()
        {
            // 准备环境
            IDictionaryExpression expression = new SimpleDictionaryExpression();
            IDictionaryStore store = new EnumDictionaryStore<Color>();
            expression.Store = store;
            Context context = new Context();

            // 测试Enum从Key到Value的解析过程
            context.Key = Color.Red;
            context.Operator = 'F'; // from key to value
            expression.Evaluate(context);
            Assert.AreEqual<string>("Red", context.Value as string);

            // 测试Enum从Value到Key的解析过程
            context.Value = "Blue";
            context.Operator = 'T';
            expression.Evaluate(context);
            Assert.AreEqual<Color>(Color.Blue, (Color)(context.Key));

            // 测试用另一个DictionaryStore框架的解析能力
            StringDictionaryStore another = new StringDictionaryStore();
            PreProcess();
            another.Data = data;
            expression.Store = another;
            expression.Evaluate(context);
            Assert.AreEqual<string>("B", context.Key as string);
        }
    }
}
