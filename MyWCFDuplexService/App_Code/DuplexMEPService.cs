using System;
using System.ServiceModel;

/// <summary>
/// Summary description for DuplexMEPService
/// </summary>
namespace MyWCFDuplexService
{
    public class DuplexMEPService : MyWCF.Contract.IDuplexMEPService
    {
        public void CallProcess()
        {
            MyWCF.Contract.IDuplexMEPServiceCallback callback =
                OperationContext.Current.GetCallbackChannel<MyWCF.Contract.IDuplexMEPServiceCallback>();
            callback.ProcessDone("process is done");
        }
    }
}