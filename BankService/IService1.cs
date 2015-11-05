using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BankService
{
    
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        int getCard();

        [OperationContract]
        string validateCard(string encryptedCardNo);

        // TODO: Add your service operations here
    }
}
