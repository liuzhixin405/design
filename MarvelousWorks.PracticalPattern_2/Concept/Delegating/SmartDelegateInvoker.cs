using System;
using System.Reflection;
namespace MarvellousWorks.PracticalPattern.Concept.Delegating
{
    public class Entity
    {
        public int Add(int x, int y) { return x + y; }
        public int Add(int x, int y, int z) { return x + y + z; }
    }

    public class SmartDelegateInvoker
    {
        // 基于 reflection 动态绑定 delegate 的目标方法
        public int Invoke(Type type, params object[] data)
        {
            // 通过调用Delegete 固定方法 'Invoke' 信息
            MethodInfo m = type.GetMethod("Invoke");
            Delegate handler = Delegate.CreateDelegate(type, new Entity(), m);
            return (int)handler.DynamicInvoke(data);
        }
    }
}
