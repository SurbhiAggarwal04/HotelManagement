using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2
{
    class OrderClass
    {

        private String senderId;
        private String receiverId;
        private String cardNo;
        private int amount;
        private double orderPrice = 0;

        public String SenderId
        {
            get { return senderId; }
            set { senderId = value; }
        }
        public String ReceiverId
        {
            get { return receiverId; }
            set { receiverId = value; }
        }
        public String CardNo
        {
            get { return cardNo; }
            set { cardNo = value; }
        }
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public double OrderPrice
        {
            get { return orderPrice; }
            set { orderPrice = value; }
        }
    }
}
