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
            // ׼������
            IDictionaryExpression expression = new SimpleDictionaryExpression();
            IDictionaryStore store = new EnumDictionaryStore<Color>();
            expression.Store = store;
            Context context = new Context();

            // ����Enum��Key��Value�Ľ�������
            context.Key = Color.Red;
            context.Operator = 'F'; // from key to value
            expression.Evaluate(context);
            Assert.AreEqual<string>("Red", context.Value as string);

            // ����Enum��Value��Key�Ľ�������
            context.Value = "Blue";
            context.Operator = 'T';
            expression.Evaluate(context);
            Assert.AreEqual<Color>(Color.Blue, (Color)(context.Key));

            // ��������һ��DictionaryStore��ܵĽ�������
            StringDictionaryStore another = new StringDictionaryStore();
            PreProcess();
            another.Data = data;
            expression.Store = another;
            expression.Evaluate(context);
            Assert.AreEqual<string>("B", context.Key as string);
        }
    }
}
