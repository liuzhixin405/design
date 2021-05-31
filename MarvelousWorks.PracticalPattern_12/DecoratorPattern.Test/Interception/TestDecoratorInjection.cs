using System;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.DecoratorPattern.Interception;
namespace MarvellousWorks.PracticalPattern.DecoratorPattern.Test.Interception
{
    public class LogAttribute : BeforeDecoratorAttribute
    {
        public override void Process(object target, MethodBase method, object[] parameters)
        {
            Trace.WriteLine(method.Name);
        }
    }

    public class ParameterCountAttribute : BeforeDecoratorAttribute
    {
        public override void Process(object target, MethodBase method, object[] parameters)
        {
            Trace.WriteLine(target.GetType().Name);
        }
    }


    [TestClass]
    public class TestBizObject
    {
        public interface IBizObject
        {
            /// <summary>
            /// �Զ����ܵ�װ�β��á����С����Ǵ�ͳ�ļ̳з�ʽ��ã�
            /// �м�������Ĺ�������ʽ����������DecoratorInjector��װ�ģ�
            /// ���ⲿ�Ƕȿ����������չ����Meta��Ϣ������չ�������йص�Լ
            /// �������ڽӿڶ���ʵ�����Ρ�
            /// </summary>
            /// <returns></returns>
            [Log]
            [ParameterCount]
            int GetValue();
        }

        public class BizObject : IBizObject
        {
            public int GetValue() { return 0; }
        }

        [TestMethod]
        public void Test()
        {
            IBizObject obj = (IBizObject)DecoratorInjector.Create(new BizObject(), typeof(IBizObject));
            int val = obj.GetValue();
            Assert.AreEqual<int>(0, val);
        }
    }
}
