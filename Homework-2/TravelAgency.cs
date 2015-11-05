using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Homework_2
{
    class TravelAgency
    {
        private String name = "";
        private String supplierName = "";
       
        private BankService.Service1Client bankServiceClient;
        public ManualResetEvent manualReset = new ManualResetEvent(false);
        private static Random random = new Random();
        private static int totalRuns = 0;
        private int maxRuns = 30;
        private static int agencyCount = 0;
        private Int32 previousPrice;
        private Int32 newPrice;

        public TravelAgency()
        {

        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }


        public void run()
        {

            
            while (true)
            {
                
                Thread.Sleep(500);
                //Aborting Threads after the hotel supplier thread has stopped running
              if (totalRuns == maxRuns)
                {
                    
                    manualReset.Set();
                    agencyCount++;
                    Thread.CurrentThread.Abort();
                    
                }

              manualReset.WaitOne();
               

                if (totalRuns == maxRuns)
                {
                    
                    agencyCount++;
                    if (agencyCount == 4)
                    {
                        try
                        {
                            Console.WriteLine("Program ran successfully");
                            Console.ReadLine();
                        }
                        catch
                        {

                        }
                    }
                    Thread.CurrentThread.Abort();
                }

                
                bankServiceClient = new BankService.Service1Client();
                OrderClass order = new OrderClass();
                order.ReceiverId = supplierName;
                order.SenderId = Thread.CurrentThread.Name;

                // order amount based on the previos price and the new price
                if(previousPrice<newPrice)
                {
                    order.Amount = random.Next(1, 10);
                }

                else
                {
                    order.Amount = random.Next(10, 15);
                }
                

                
                while ( order.CardNo == null || "".Equals(order.CardNo))
                {
                    order.CardNo = Convert.ToString(bankServiceClient.getCard());
                    if(order.CardNo.Equals('0'))
                    {
                        Console.WriteLine("Card will be issued after checking the available card numbers");
                    }
                }
                
                //placing order in the buffer after encoding
                Boolean b = true;
                DateTime time = DateTime.Now;
                while (b)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (Program.buffer[i].getBuffer("temp") == null)
                        {
                            lock (Program.buffer[i])
                            {
                                time = DateTime.Now;
                                Program.buffer[i].setBuffer(new Encoder().encode(order));
                                b = false;
                            }
                            
                            break;
                        }

                    }
                }


                //checking the processed order;
                b = true;
                Thread.Sleep(500);
                string orderString = order.SenderId + "and" + order.ReceiverId;
                
                while (b)
                {
                    if (Program.processedOrder.getBuffer(orderString) != null)
                    {
                        Console.WriteLine("Time taken to process the order is :" + (DateTime.Now - time).TotalSeconds + " seconds");
                        b = false;
                        
                    }
                    else
                        Thread.Sleep(500);
                }

                

                manualReset.Reset();
                
                totalRuns++;
                
            }
            
        }

        //price cut event method
        public void getHotelPrice(String name, Int32 previousPrice,Int32 newPrice)
        {
            supplierName = name;
            this.previousPrice=previousPrice;
            this.newPrice=newPrice;
            manualReset.Set();
        }

    }
}
