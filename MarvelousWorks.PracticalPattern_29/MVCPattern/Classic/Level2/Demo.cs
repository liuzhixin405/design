using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.MVCPattern.Classic.Level2
{
    public interface IView
    {
        void Print(string data);
    }

    public interface IModel
    {
        int[] Data { get;}
    }

    public class Controler
    {
        private IList<IView> views = new List<IView>();

        private IModel model;
        public virtual IModel Model
        {
            get { return model; }
            set { model = value; }
        }

        public void Process()
        {
            if (views.Count == 0) return;
            string result = string.Join(",", Array.ConvertAll<int, string>(model.Data,
                delegate(int n) { return Convert.ToString(n); }));
            foreach (IView view in views)
                view.Print(result);
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
            control.views.Add(view);
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
            control.views.Add(view);
            return control;
        }
    }
}
