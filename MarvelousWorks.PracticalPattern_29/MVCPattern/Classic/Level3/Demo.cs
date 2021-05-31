using System;
using System.Collections.Generic;
using System.Data;
namespace MarvellousWorks.PracticalPattern.MVCPattern.Classic.Level3
{
    public class ModelEventArgs : EventArgs
    {
        private string content;
        public string Context { get { return this.content; } }
        public ModelEventArgs(int[] data)
        {
            content = string.Join(",", Array.ConvertAll<int, string>(
                data, delegate(int n) { return Convert.ToString(n); }));
        }
    }

    /// <summary>
    /// �����Model
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// �ṩ��View�����¼���ʽԤ��Model�仯�����
        /// </summary>
        event EventHandler<ModelEventArgs> DataChanged;

        /// <summary>
        /// Model����Ϣ��������ķ�װ
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        int this[int index] { get; set;}
    }

    /// <summary>
    /// �����View
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// ���ڽ��ն�Model��Ϣ��������Ԥ��
        /// </summary>
        EventHandler<ModelEventArgs> Handler { get;}

        void Print(string data);
    }


    public class Controler
    {
        private IModel model;
        public virtual IModel Model
        {
            get { return model; }
            set { model = value; }
        }

        /// <summary>
        /// Ϊ�˱��ڲ������ص������
        /// </summary>
        /// <param name="control"></param>
        /// <param name="view"></param>
        /// <returns></returns>
        public static Controler operator +(Controler control, IView view)
        {
            if (view == null) throw new ArgumentNullException("view");
            control.Model.DataChanged += view.Handler;
            return control;
        }

        /// <summary>
        /// Ϊ�˱��ڲ������ص������
        /// </summary>
        /// <param name="control"></param>
        /// <param name="view"></param>
        /// <returns></returns>
        public static Controler operator -(Controler control, IView view)
        {
            if (view == null) throw new ArgumentNullException("view");
            control.Model.DataChanged -= view.Handler;
            return control;
        }
    }

}
