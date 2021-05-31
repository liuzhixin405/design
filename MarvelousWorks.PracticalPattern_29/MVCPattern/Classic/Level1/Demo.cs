using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace MarvellousWorks.PracticalPattern.MVCPattern.Classic.Level1
{
    public class Demo
    {
        private const int Max = 10;

        private int[] Generate()
        {
            Random rnd = new Random();
            int[] data = new int[Max];
            for (int i = 0; i < Max; i++)
                data[i] = rnd.Next() % 1023;
            return data;
        }

        public void PrintData()
        {
            string result = string.Join(",", 
                Array.ConvertAll<int, string>(Generate(),
                delegate(int n){return Convert.ToString(n);}));
            
            // 向Output窗口输出
            Trace.WriteLine(result);
            // 向Event Viewer输出
            EventLog.WriteEntry("Demo", result);
        }
    }
}
