using System;
using System.Collections.Generic;
using System.ServiceModel;
namespace Common
{
    /// <summary>
    /// 业务服务接口
    /// </summary>
    [ServiceContract]
    public interface  IMessage
    {
        [OperationContract]
        string GetID();

        [OperationContract]
        string GetTitle();
    }
}
