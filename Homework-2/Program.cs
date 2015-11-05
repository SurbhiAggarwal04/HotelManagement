using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_2
{
    class Program
    {
        public static MultiCellBuffer[] buffer = new MultiCellBuffer[3];
        public static OrderProcessed  processedOrder = new OrderProcessed();

        static void Main(string[] args)
        {
            //3 hotel suppliers
            HotelSupplier[] h = new HotelSupplier[2];

            //1 travel agency
            TravelAgency travelAgency = new TravelAgency();
            //array of thread agency names
            string[] agenciesName= { "TA1", "TA2", "TA3", "TA4", "TA5" };

            for (int i = 0; i < 3; i++)
            {
                buffer[i] = new MultiCellBuffer();
            }

            //hotel threads started
            for (int i = 0; i < 2; i++)
            {
                h[i] = new HotelSupplier("HS" + (i + 1));
                h[i].priceCut += new priceCutDelegate(travelAgency.getHotelPrice);
                Thread hs = new Thread(new ThreadStart(h[i].run));
                hs.Start();
            }

            //agency threads started
            for (int i = 0; i < 5; i++)
            {
                Thread t = new Thread(new ThreadStart(travelAgency.run));
                t.Name = agenciesName[i];
                t.Start();
            }
            



        }
        }
    }

