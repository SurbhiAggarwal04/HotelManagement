using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2
{
    class Encoder
    {
        public String encode(OrderClass orderClassObject)
        {
            String orderString = "";
            orderString += orderClassObject.SenderId + ",";
            orderString += orderClassObject.ReceiverId + ",";
            orderString += orderClassObject.CardNo + ",";
            orderString += orderClassObject.Amount;
            return orderString;
        }
    }
}
