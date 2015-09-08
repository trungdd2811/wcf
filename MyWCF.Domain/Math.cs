﻿using System;
using System.Runtime.Serialization;

namespace MyWCF.Domain
{
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Math
    {
        [DataMember]
        public int Number1 { get; set; }
        [DataMember]
        public int Number2 { get; set; }
    }

}
