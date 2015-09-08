using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyWCFService
{
    [DataContract]
    public class Maths
    {
        [DataMember]
        public int Number1 { get; set; }
        [DataMember]
        public int Number2 { get; set; }
    }

    [ServiceContract]
    public interface IMaths
    {
        [OperationContract]
        int Add(Maths obj);
        [OperationContract]
        int Sub(Maths obj);
        [OperationContract]
        int Mul(Maths obj);
        [OperationContract]
        int Div(Maths obj);
    }
}
