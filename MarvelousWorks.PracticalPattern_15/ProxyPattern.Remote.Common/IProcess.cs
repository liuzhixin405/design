using System;
using System.Collections.Generic;
using MarvellousWorks.PracticalPattern.Common;
namespace MarvellousWorks.PracticalPattern.ProxyPattern.Remote.Common
{
    /// <summary>
    /// ����ʵ�־���ÿ��PreProcess/PostProcess���͵ĳ�������
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public interface IProcess<TData>
    {
        TData PreProcess(TData data);
        TData PostProcess(TData data);
    }

    /// <summary>
    /// �������������Ҫִ�еĴ������ί�ж���
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <returns></returns>
    public delegate T ProcessHandler<T>(T message);

    /// <summary>
    /// ����ʵ��˫���������������
    /// ʵ�ʴ������п���PreProcess��PostProcess���������Գƣ���ʱ��Ҫ���ⶨ��ί�й�ϵ
    /// </summary>
    public class CryptoProcess : IProcess<string>
    {
        public string PreProcess(string data) { return CryptoHelper.Encrypt(data); }
        public string PostProcess(string data) { return CryptoHelper.Decrypt(data); }
    }

    public class EncodeProcess : IProcess<string>
    {
        public string PreProcess(string data) { return CryptoHelper.Encode(data); }
        public string PostProcess(string data) { return CryptoHelper.Decode(data); }
    }

    public class PrefixProcess : IProcess<string>
    {
        private string Prefix = "MarvellousWorks:";
        public string PreProcess(string data) { return Prefix + data; }
        public string PostProcess(string data)
        {
            if (!data.StartsWith(Prefix)) throw new ArgumentException("Invalidate prefix");
            return data.Substring(Prefix.Length);
        }
    }
}
