using System;
using System.Collections.Generic;
using System.ServiceModel;
namespace MarvellousWorks.PracticalPattern.Idiom.Test.PartialClass.DiffAspect
{

    [ServiceContract]
    interface IMyContract
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.NotAllowed)]
        void MyMethod();
    }
}
