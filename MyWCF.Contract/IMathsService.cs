using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MyWCF.Domain;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
namespace MyWCF.Contract
{
    [ServiceContract]
    public interface IMathsService
    {
        [OperationContract]
        int Add(MyWCF.Domain.Math obj);
        [OperationContract]
        int Sub(MyWCF.Domain.Math obj);
    }

}