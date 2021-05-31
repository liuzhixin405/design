using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using MarvellousWorks.PracticalPattern.ProxyPattern.Remote.Common;
/// <summary>
/// 客户端将远程调用具体化之后的远程代理接口类型
/// </summary>
[ServiceContractAttribute(
    Namespace="http://marvellousWorks.practicalPattern/proxyPattern/remote", 
    ConfigurationName="IUser")]
public interface IUser
{
    [OperationContractAttribute(Action = 
        "http://marvellousWorks.practicalPattern/proxyPattern/remote/IUser/Greeting",ReplyAction = 
        "http://marvellousWorks.practicalPattern/proxyPattern/remote/IUser/GreetingResponse")]
    string Greeting(string userName);
}

/// <summary>
/// SvcUtil.exe生成的客户端代理类型
/// </summary>
public partial class UserClient : ClientBase<IUser>, IUser
{
    #region 提供给WCF框架使用的各种构造方法
    public UserClient() { }
    public UserClient(string endpointConfigurationName) : base(endpointConfigurationName) { }
    public UserClient(string endpointConfigurationName, string remoteAddress)
        : base(endpointConfigurationName, remoteAddress) { }
    public UserClient(string endpointConfigurationName, EndpointAddress remoteAddress)
        : base(endpointConfigurationName, remoteAddress) { }
    public UserClient(Binding binding, EndpointAddress remoteAddress)
        : base(binding, remoteAddress) { }
    #endregion

    public string Greeting(string userName)
    {
        RemoteConfigurationSection<string> config = new RemoteConfigurationSection<string>();
        foreach (ProcessHandler<string> process in config.PreProcess)
            userName = process(userName);
        string result = base.Channel.Greeting(userName);
        foreach (ProcessHandler<string> process in config.PostProcess)
            result = process(result);
        return result;
    }
}
