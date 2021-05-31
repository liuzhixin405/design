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
            /// 对对象功能的装饰采用“横切”而非传统的继承方式获得，
            /// 中间代理对象的构造是隐式，而且是由DecoratorInjector包装的，
            /// 从外部角度看，对象的扩展是在Meta信息部分扩展，而且有关的约
            /// 束定义在接口而非实体类层次。
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
