using System;
using MyWCFClient.demoMathsService;
using System.ServiceModel;
namespace MyWCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //dynamic endpoint, url
            //MathsServiceClient obj = new MathsServiceClient("dynamic_url", "http://localhost:54168/Service.svc");
            //MyWCFClient.demoMathsService.Math num = new MyWCFClient.demoMathsService.Math();
            //num.Number1 = 1; num.Number2 = 2;
            //Console.WriteLine(obj.Add(num).ToString());
            //Console.ReadLine();

            #region ChannelFactory example
            //var factory = new ChannelFactory<MyWCF.Contract.IMathsService>("channelFactory");
            //var wcfClientChannel = factory.CreateChannel();
            //MyWCF.Domain.Math num = new MyWCF.Domain.Math();
            //num.Number1 = 1;
            //num.Number2 = 2;
            //Console.WriteLine(wcfClientChannel.Add(num).ToString());
            //Console.ReadLine(); 
            #endregion

            #region 2-ways binding, MEP stands for Message Exchange Pattern
            InstanceContext instance = new InstanceContext(new CallBackHandler());
            
            var factory = new DuplexChannelFactory<MyWCF.Contract.IDuplexMEPService>(instance, "wsDualBinding");
            var wcfClientChannel = factory.CreateChannel();
            Console.WriteLine("call process wcf");      
            wcfClientChannel.CallProcess();
            Console.WriteLine(wcfClientChannel.HelloProcess("fdsf"));
            Console.ReadLine();
            #endregion
        }
    }
    public class CallBackHandler : MyWCF.Contract.IDuplexMEPServiceCallback
    {
        public void ProcessDone(string value)
        {
            Console.WriteLine(value);            
        }
    }
}
