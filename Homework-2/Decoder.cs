using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2
{
    class Decoder
    {
        public OrderClass decode(String order)
        {
            
            OrderClass orderObject = new OrderClass();
            if (order != null)
            {
                String[] orderArray = order.Split(',');
                orderObject.SenderId = orderArray[0];
                orderObject.ReceiverId = orderArray[1];
                orderObject.CardNo = orderArray[2];
                orderObject.Amount = Convert.ToInt32(orderArray[3]);
            }


            return orderObject;
        }
    }
}
