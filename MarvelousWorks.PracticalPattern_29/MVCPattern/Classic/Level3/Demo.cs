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
    /// 抽象的Model
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// 提供给View借助事件方式预定Model变化的入口
        /// </summary>
        event EventHandler<ModelEventArgs> DataChanged;

        /// <summary>
        /// Model对信息自身操作的封装
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        int this[int index] { get; set;}
    }

    /// <summary>
    /// 抽象的View
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// 用于接收对Model信息变更情况的预定
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
        /// 为了便于操作重载的运算符
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
        /// 为了便于操作重载的运算符
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
