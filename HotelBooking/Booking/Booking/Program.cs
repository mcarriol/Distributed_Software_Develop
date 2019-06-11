using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


//WORK OF MARIA ARRIOLA 
namespace Booking
{
    class Program
    {
        //Instantiate events and threads

        //Events used to alert Travel Agency of price cuts and confirmations to the travel agencies to print the order
        public delegate void priceCutEvent(double price, double prev);
        public delegate void OrderConfirmedEvent(double price, int rooms, int agencyid, int cardno);
      
        private static Thread[] hotels = new Thread[2];
        private static Thread[] agencies = new Thread[5];
        private static List<HotelSupplier> listHotels = new List<HotelSupplier>();
        private static List<TravelAgency> listAgents = new List<TravelAgency>();
        public static MultiCellBuffer buffer = new MultiCellBuffer();
     
        static void Main(string[] args)
        {
            //Creating Hotel Threads for each Hotel supplier  
            HotelSupplier supplier1 = new HotelSupplier();
            HotelSupplier supplier2 = new HotelSupplier();

            hotels[0] = new Thread(new ThreadStart(() => supplier1.run()));
            hotels[1] = new Thread(new ThreadStart(() => supplier2.run()));
            hotels[0].Name = "1";
            hotels[1].Name = "2";


            hotels[0].Start();
            hotels[1].Start();

            //Creating multiple threads in this example 5 for Travel Agents
            //OrderProcessing.orderConfirmed += new OrderConfirmedEvent(agency.confirmation);
            for (int i = 0; i < 5; i++)
            {
                TravelAgency agency = new TravelAgency();
                //Subscribing events
                HotelSupplier.priceCut += new priceCutEvent(agency.PriceCutOrder);
                OrderProcessing.orderConfirmed += new OrderConfirmedEvent(agency.confirmation);
                listAgents.Add(agency);
                agencies[i] = new Thread(new ThreadStart(agency.Run));
                agencies[i].Name = (i + 1).ToString();
                agencies[i].Start();

            }

          
          
            for (int i = 0; i < 2; ++i)
             {
                 while (hotels[i].IsAlive);
             }
            for (int i = 0; i < 5; i++)
            {
                //while (agencies[i].IsAlive) ;
                agencies[i].Join();
            }

       

            Thread.Sleep(5000);
            Console.WriteLine("\n\nPROGRAM HAS ENDED .....all threads have terminated");

            // Wait for user to hit a button
            Console.WriteLine("Press ENTER to QUIT");
            Console.ReadLine();


        }

    }
}
