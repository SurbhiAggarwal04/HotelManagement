using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
public delegate void priceCutDelegate(String hotelName, Int32 previousPrice, Int32 newPrice);
namespace Homework_2
{
    
    class HotelSupplier
    {

        private String hotelName;
        private int counter = 0;
        private int pricePerRoom = 20;
        private int noOfRoom;
        private int noOfAvailableRooms;
        private double taxPercentage = 12.5;
        private double locationCharge = 1000;
        
        public static int waitHandler = 0;
        public event priceCutDelegate priceCut;
        static Random random = new Random();
        private OrderClass order;
        
        public static AutoResetEvent autoReset = new AutoResetEvent(false);

        public int NoOfRoom
        {
            get { return noOfRoom; }
            set { noOfRoom = value; }
        }
        public int NoOfAvailableRooms
        {
            get { return noOfAvailableRooms; }
            set { noOfAvailableRooms = value; }
        }
        public double getTaxPercentage()
        {
            return taxPercentage;
        }
        public double getLocationCharge()
        {
            return locationCharge;
        }

        public HotelSupplier(String hotelName)
        {
            this.hotelName = hotelName;
        }
        public HotelSupplier()
        {

        }
        public int getPrice() { return pricePerRoom; }

        
        public void run()
        {
            while (counter < 3)
            {
                
                
                HotelSupplier hotel = new HotelSupplier();

                if (waitHandler > 0)
                {
                    autoReset.WaitOne();
                }
                waitHandler++;
                hotelPricingModel();
               
                String orderString;
                int count = 0;
                hotel.NoOfRoom = 30;
                hotel.NoOfAvailableRooms = 30;
                
                //Processing Order
              while (count < 5)
               {
                    for (int i = 0; i < 3; i++)
                    {
                        orderString = Program.buffer[i].getBuffer(hotelName);
                        if (orderString != null)
                        {
                            //decoding the buffere object
                            order = new Decoder().decode(orderString);
                           count++;
                            OrderProcessing orderProcessing = new OrderProcessing(hotel, order, hotelName);
                            Thread orderProcessingThread = new Thread(new ThreadStart(orderProcessing.processOrder));
                            orderProcessingThread.Start();
                            orderProcessingThread.Join();
                        }
                        else
                        {
                            Thread.Sleep(1000);
                        }
                    }
                    Thread.Sleep(500);
                    
              }
                autoReset.Set();
                Console.WriteLine("");
                Thread.Sleep(500);
                
            }
            
        }

        //Hotel Pricing Model using the time and day of the week
        public void hotelPricingModel()
        {
            Boolean b = true;
            int newPrice = 0;
            switch (counter)
            {
                case 0: newPrice = random.Next(17, 20); break;
                case 1: newPrice = random.Next(15, 17); break;
                case 2: newPrice = random.Next(10, 15); break;
            }
            while (b)
            {
                           
                if (this.pricePerRoom > newPrice)
                {
                    if (priceCut != null)
                    {
                        
                        b = false;


               
              
                
                Int32 day = (Int32)DateTime.Now.Date.DayOfWeek;
                      string priceCutString = DateTime.Now.Date.DayOfWeek + "-" + hotelName + " at " + DateTime.Now.ToString("h:mm:ss tt");


                      Console.WriteLine("Price cut event for : " + priceCutString);
                      Console.WriteLine("");
                      Thread.Sleep(200);
                      priceCut(hotelName,pricePerRoom, newPrice);

                    }
                   
                    counter++;
                }
                pricePerRoom = newPrice;
            }

        }
    }
}
