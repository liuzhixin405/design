using System;
namespace MarvellousWorks.PracticalPattern.Concept.Delegating
{
    public delegate object UglySmartHandler(params object[] data);

    public class UglySmartDelegateInvoker
    {
        private UglySmartHandler handler;
        public UglySmartDelegateInvoker()
        {
            handler = new UglySmartHandler(Add);
        }

        // 抽象调用过程
        public object Invoke(params object[] data) { return handler(data); }

        // 数学计算
        public object Add(params object[] data)
        {
            if (data.Length == 2)
                return Add((int)data[0], (int)data[1]);
            else if (data.Length == 3)
                return Add((int)data[0], (int)data[1], (int)data[2]);
            else
                throw new NotSupportedException();
        }
        public int Add(int x, int y) { return x + y; }              
        public int Add(int x, int y, int z) { return x + y + z; }
    }
}
