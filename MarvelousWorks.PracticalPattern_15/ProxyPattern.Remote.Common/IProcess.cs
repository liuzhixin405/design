using System;
using System.Collections.Generic;
using MarvellousWorks.PracticalPattern.Common;
namespace MarvellousWorks.PracticalPattern.ProxyPattern.Remote.Common
{
    /// <summary>
    /// 定义实现具体每个PreProcess/PostProcess类型的抽象特征
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public interface IProcess<TData>
    {
        TData PreProcess(TData data);
        TData PostProcess(TData data);
    }

    /// <summary>
    /// 定义代理类型需要执行的处理步骤地委托定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <returns></returns>
    public delegate T ProcessHandler<T>(T message);

    /// <summary>
    /// 各个实现双向处理的特征的类型
    /// 实际处理中有可能PreProcess和PostProcess的数量不对称，这时需要另外定义委托关系
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
