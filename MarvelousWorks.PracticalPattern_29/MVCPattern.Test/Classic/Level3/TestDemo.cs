using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarvellousWorks.PracticalPattern.MVCPattern.Classic.Level3;
namespace MarvellousWorks.PracticalPattern.MVCPattern.Test.Classic.Level3
{
    [TestClass]
    public class TestDemo
    {
        /// <summary>
        /// Model����
        /// </summary>
        class Model : IModel
        {
            public event EventHandler<ModelEventArgs> DataChanged;

            public int this[int index]
            {
                get { return data[index]; }
                set
                {
                    this.data[index] = value;
                    if (DataChanged != null)
                        DataChanged(this, new ModelEventArgs(data));
                }
            }

            private int[] data;
            public Model()
            {
                Random rnd = new Random();
                data = new int[10];
                for (int i = 0; i < data.Length; i++)
                    data[i] = rnd.Next() % 1023;
            }
        }

        abstract class ViewBase : IView
        {
            public abstract void Print(string data);

            /// <summary>
            /// View����֪Model���ݱ仯�����´�ӡ���µ�����
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="args"></param>
            public virtual void OnDataChanged(object sender, ModelEventArgs args)
            {
                Print(args.Context);
            }

            public virtual EventHandler<ModelEventArgs> Handler
            {
                get { return this.OnDataChanged; }
            }
        }
        
        class TraceView : ViewBase
        {
            public override void Print(string data)
            {
                Trace.WriteLine(data);
            }
        }

        class EventLogView : ViewBase
        {
            public override void Print(string data)
            {
                EventLog.WriteEntry("Demo", data);
            }
        }

        [TestMethod]
        public void Test()
        {
            // ��װ
            Controler control = new Controler();
            IModel model = new Model();
            control.Model = model;
            control += new TraceView();
            control += new EventLogView();

            // ����Model�޸�ʱ��������Controller�����Ǿ��ɹ۲������View�ı仯
            model[1] = 2000;    // ��һ���޸ģ��޸ĵ����ݰ���֮ǰ����������㲻����֣�
            model[3] = -100;    // �ڶ����޸ģ��޸ĵ����ݰ���֮ǰ����������㲻����֣�
        }
    }
}
