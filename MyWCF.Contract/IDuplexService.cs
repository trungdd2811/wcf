using System.ServiceModel;

namespace MyWCF.Contract
{
    [ServiceContract(CallbackContract = typeof(IDuplexMEPServiceCallback))]
    public interface IDuplexMEPService
    {
        [OperationContract(IsOneWay =true)]
        void CallProcess();
        [OperationContract]
        string HelloProcess(string value);
    }
    [ServiceContract]
    public interface IDuplexMEPServiceCallback {
        [OperationContract(IsOneWay =true)]
        void ProcessDone(string value);
    }
}
