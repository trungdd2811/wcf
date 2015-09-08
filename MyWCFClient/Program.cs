using System;
using MyWCFClient.demoMathsService;
using System.ServiceModel;
using Autofac;
using DemoAutofac;
namespace MyWCFClient
{
    class Program
    {
        private static IContainer Container { get; set; }

        private static void WriteDate()
        {
            // Create the scope, resolve your IDateWriter,
            // use it, then dispose of the scope.
            using (var scope = Container.BeginLifetimeScope())
            {
               var todayWriter = scope.Resolve<IDateWriter>();
               var writer = scope.Resolve<SpecificDayWriter>(
                    new TypedParameter(typeof(DateTime),DateTime.Now.AddDays(1))
                    );
                todayWriter.WriteDate();
                writer.WriteDate();
            }
        }

        static void Main(string[] args)
        {

            #region dynamic endpoid
            //dynamic endpoint, url
            //MathsServiceClient obj = new MathsServiceClient("dynamic_url", "http://localhost:54168/Service.svc");
            //MyWCFClient.demoMathsService.Math num = new MyWCFClient.demoMathsService.Math();
            //num.Number1 = 1; num.Number2 = 2;
            //Console.WriteLine(obj.Add(num).ToString());
            //Console.ReadLine();
            #endregion

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
            //InstanceContext instance = new InstanceContext(new CallBackHandler());

            //var factory = new DuplexChannelFactory<MyWCF.Contract.IDuplexMEPService>(instance, "wsDualBinding");
            //var wcfClientChannel = factory.CreateChannel();
            //Console.WriteLine("call process wcf");      
            //wcfClientChannel.CallProcess();
            //Console.WriteLine(wcfClientChannel.HelloProcess("fdsf"));
            //Console.ReadLine();
            #endregion

            #region autofac example
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleOutput>().As<IOutput>();
            builder.RegisterType<TodayWriter>().As<IDateWriter>();
            builder.RegisterType<SpecificDayWriter>();
            Container = builder.Build();

            // The WriteDate method is where we'll make use
            // of our dependency injection. We'll define that
            // in a bit.
            WriteDate();

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
