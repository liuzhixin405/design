using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.Concept.Delegating
{
    public delegate void MemoHandler(int x, int y, IDictionary<string, int> data);

    // �Ծ������صĶ��Ŀ�귽�� Delegate
    public class OverloadableDelegateInvoker
    {
        private MemoHandler handler;

        public OverloadableDelegateInvoker()
        {
            Type type = typeof(MemoHandler);
            Delegate d = Delegate.CreateDelegate(type, new C1(), "A");
            d = Delegate.Combine(d, Delegate.CreateDelegate(type, new C2(), "S"));
            d = Delegate.Combine(d, Delegate.CreateDelegate(type, new C3(), "M"));
            handler = (MemoHandler)d;
        }

        public void Memo(int x, int y, IDictionary<string, int> data) 
        {
            handler(x, y, data); 
        }
    }
}

#region Sample ��
namespace MarvellousWorks.PracticalPattern.Concept.Delegating
{
    #region ʾ������
    // ���� +
    public sealed class C1
    {
        void A(int x, IDictionary<string, int> data) { data["A"] = x; }
        void A(int x, int y, IDictionary<string, int> data) { data["A"] = x + y; }
    }

    // ���� -
    public sealed class C2
    {
        void S(int x, IDictionary<string, int> data) { data["S"] = x; }
        void S(int x, int y, IDictionary<string, int> data) { data["S"] = x - y; }
    }

    // *
    public sealed class C3
    {
        void M(int x, int y, IDictionary<string, int> data) { data["M"] = x * y; }
    }
    #endregion
}
#endregion