using System;
using System.Collections.Generic;
using System.ServiceModel;
namespace Common
{
    /// <summary>
    /// ҵ�����ӿ�
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
