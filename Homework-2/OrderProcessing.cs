using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2
{
    class OrderProcessing
    {

        private EncryptionService.ServiceClient encryptionServiceClient;
        private BankService.Service1Client bankServiceClient;
        static int counter = 1;
        
        HotelSupplier hotel;
        private OrderClass order;
        private string supplierName;

        public OrderProcessing(HotelSupplier hotel, OrderClass order, string supplierName)
        {
            this.hotel = hotel;
            this.order = order;
            this.supplierName = supplierName;
        }

        public void processOrder()
        {
            encryptionServiceClient = new EncryptionService.ServiceClient();
            bankServiceClient = new BankService.Service1Client();

            
            String validatedCardDetails;


            if ((hotel.NoOfRoom - order.Amount) >= 0)
            {
                
               String encryptedCardNo = encryptionServiceClient.Encrypt(order.CardNo);
                try
                {
                    validatedCardDetails = bankServiceClient.validateCard(encryptedCardNo);
                }
                catch (Exception exp)
                {
                    validatedCardDetails = "Card number not verified";
                    Console.WriteLine("Card number not verified");
                }

                if (validatedCardDetails.Equals("valid"))
                {
                    hotel.NoOfRoom = hotel.NoOfRoom - order.Amount;
                    order.OrderPrice = hotel.getPrice() * order.Amount + hotel.getTaxPercentage() * hotel.getPrice() * order.Amount + hotel.getLocationCharge();
                    Console.WriteLine("Order Processed:" + counter + " || Ordering Parties: " + order.SenderId + "-> " + order.ReceiverId + " || No of rooms requested:" + order.Amount + "|| Price charged:" + order.OrderPrice + " || Rooms remaining:" + hotel.NoOfRoom);
                    counter++;

                }
                else
                {
                    Console.WriteLine("Order Rejected:" + counter +  " || Ordering Parties: " + order.SenderId + "-> " + order.ReceiverId + "|| No of rooms requested:" + order.Amount + "|| Reason: Rooms not available");
                    counter++;
                }
            }
            else
            {
                Console.WriteLine("Order Rejected:" + counter + " || Ordering Parties: " + order.SenderId + "-> " + order.ReceiverId + "|| No of rooms requested:" + order.Amount + "|| Reason: Rooms not available");
                counter++;
            }


            Boolean b = true;
            while (b)
            {
                
                if (Program.processedOrder.getBuffer(order.SenderId) == null)
                {
                    lock (Program.processedOrder)
                    {
                        Program.processedOrder.setBuffer(order.SenderId + "and" + order.ReceiverId);
                        b = false;
                        
                    }
                }
            }


        }
    }
}
