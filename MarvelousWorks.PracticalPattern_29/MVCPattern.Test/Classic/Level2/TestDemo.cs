using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.MVCPattern.Classic.Level2;
namespace MarvellousWorks.PracticalPattern.MVCPattern.Test.Classic.Level2
{
    [TestClass]
    public class TestDemo
    {
        class Randomizer : IModel
        {
            #region IModel Members
            public int[] Data
            {
                get
                {
                    Random rnd = new Random();
                    int[] result = new int[10];
                    for (int i = 0; i < result.Length; i++)
                        result[i] = rnd.Next() % 1023;
                    return result;
                }
            }
            #endregion
        }

        public class TraceView : IView
        {
            #region IView Members
            public void Print(string data)
            {
                Trace.WriteLine(data);
            }
            #endregion
        }

        public class EventLogView : IView
        {
            #region IView Members
            public void Print(string data)
            {
                EventLog.WriteEntry("Demo", data);
            }
            #endregion
        }

        [TestMethod]
        public void Test()
        {
            // ×é×°
            Controler control = new Controler();
            control.Model = new Randomizer();
            control += new TraceView();
            control += new EventLogView();
            control.Process();
        }
    }
}
