using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.TemplatePattern.Classic
{
    /// <summary>
    /// �����ģ��ӿ�
    /// </summary>
    public interface IAbstract
    {
        int Quantity { get;}
        double Total { get;}
        double Average { get;}
    }

    /// <summary>
    /// �������㷨���ŵĳ�������
    /// </summary>
    public abstract class AbstractBase : IAbstract
    {
        public abstract int Quantity { get;}
        public abstract double Total { get;}

        /// <summary>
        /// �㷨����
        /// </summary>
        public virtual double Average { get { return Total / Quantity; } }
    }

    /// <summary>
    /// ��������
    /// </summary>
    public class ArrayData : AbstractBase
    {
        protected double[] data = new double[3] { 1.1, 2.2, 3.3 };
        public override int Quantity { get { return data.Length; } }
        public override double Total{get{
                double count = 0;
                for (int i = 0; i < data.Length; i++) count += data[i];
                return count;
            }
        }
    }

    /// <summary>
    /// ��������
    /// </summary>
    public class ListData : AbstractBase
    {
        protected IList<double> data = new List<double>();
        public ListData() { data.Add(1.1); data.Add(2.2); data.Add(3.3); }
        public override int Quantity { get { return data.Count; } }
        public override double Total{get{
                double count = 0;
                foreach (double item in data) count += item;
                return count;
            }
        }
    }
}
