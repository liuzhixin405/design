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
        // ���� reflection ��̬�� delegate ��Ŀ�귽��
        public int Invoke(Type type, params object[] data)
        {
            // ͨ������Delegete �̶����� 'Invoke' ��Ϣ
            MethodInfo m = type.GetMethod("Invoke");
            Delegate handler = Delegate.CreateDelegate(type, new Entity(), m);
            return (int)handler.DynamicInvoke(data);
        }
    }
}
