using System;
using System.Collections.Generic;
namespace MarvellousWorks.PracticalPattern.TemplatePattern.Multiple
{
    public interface ITransform
    {
        string Transform(string data);
        bool Parse(string data);
        string Replace(string data);
    }

    public abstract class TransformBase : ITransform
    {
        /// <summary>
        /// �����㷨
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public virtual string Transform(string data)
        {
            if (Parse(data))
                data = Replace(data);
            return data;
        }

        public abstract bool Parse(string data);
        public abstract string Replace(string data);
    }

    public interface ISetter
    {
        string Append(string data);
        bool CheckHeader(string data);
        bool CheckTailer(string data);
    }

    public abstract class SetterBase : ISetter
    {
        /// <summary>
        /// �����㷨
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public virtual string Append(string data)
        {
            if (!CheckHeader(data)) data = "H:" + data;
            if (!CheckTailer(data)) data = data + ":T";
            return data;
        }

        public abstract bool CheckHeader(string data);
        public abstract bool CheckTailer(string data);
    }


    /// <summary>
    /// ͬʱʵ�ֶ��Template�ľ�������
    /// </summary>
    public class DataBroker : ITransform, ISetter
    {
        /// <summary>
        /// ���ڶ���Ƚϸ��ӵ�Template���ͣ�����ͨ���ڲ���
        /// �������ⲿ�������������͵�ʵ�ָ���
        /// </summary>
        class InternalTransform : TransformBase
        {
            public override bool Parse(string data) { return data.Contains("X"); }
            public override string Replace(string data) { return data.Replace("X", "Y"); }
        }

        class InternalSetter : SetterBase
        {
            public override bool CheckHeader(string data) { return data.StartsWith("H:"); }
            public override bool CheckTailer(string data) { return data.EndsWith(":T"); }
        }

        #region ITransform Members
        private ITransform tranform = new InternalTransform();
        public string Transform(string data) { return tranform.Transform(data); }
        public bool Parse(string data) { return tranform.Parse(data); }
        public string Replace(string data) { return tranform.Replace(data); }
        #endregion

        #region ISetter Members
        private ISetter setter = new InternalSetter();
        public string Append(string data){return setter.Append(data);}
        public bool CheckHeader(string data){return setter.CheckHeader(data);}
        public bool CheckTailer(string data) { return setter.CheckTailer(data); }
        #endregion
    }

}
