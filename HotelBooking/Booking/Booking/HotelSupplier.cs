using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Booking.Program;

namespace Booking
{
    //uses pricing model to determine room prices, defines price cut event which calls event handlers in travelagencys
    class HotelSupplier
    {

        private const int p = 10;
        private int pCounter = 0;
        private double price = 0;
        private static Random random = new Random();
        private ArrayList processingThreads = new ArrayList(); //threads used to process orders
        public static event priceCutEvent priceCut;
    

       public HotelSupplier()
        {
            //intitally price of room is 40 dollars
            price = 40;
          
        }

        //used to test to see how many pricecuts occured
        public int getP()
        {
            return pCounter;
        } 

        //retrieves current price
       public double getPrice()
        {
            return price;
        }


        //Method used to change price 
        public void changePrice(double p2)
        {
          // if the new room price is less than the last room price emit a price cut event 
            if (p2 <price)
            {

                if (priceCut != null)
                {

                    String threadid = Thread.CurrentThread.Name;
                    int id = Convert.ToInt32(threadid);
                    priceCut(p2,price);
                    pCounter++;
                }



            }
            price = p2;

        }

        
        public void run()
        {
            //Hotel Supplier thread will terminate after 10 price cuts
            while (pCounter < p)
            {
               Thread.Sleep(500);
             
              //set price 
               double p2 = priceModel();
               changePrice(p2);

              //Process orders from MultiCellBuffer
               decodeprocess();
               


            }

            foreach (Thread process_th in processingThreads)
            {
                while (process_th.IsAlive) ;
            }

            //hotel thread made 10 max cuts alert Travel Agency
            TravelAgency.HotelsActive = false;



            
            Console.WriteLine("CLOSING: Hotel Supplier Thread ({0})", Thread.CurrentThread.Name);
         

        }

        //Generates a random Room price between 50$ and 70$ 
        private Double priceModel()
        {
           
            double rand = (random.Next(50, 600) + ((pCounter % 7) * random.Next(1, 3)));
         
            return rand;
           
        }



        //Processes the order by retrieving the decoded object, creates a new thread to process order
    
        public void decodeprocess()
        {
            string order = Program.buffer.getOneCell();
            OrderClass order2 = Decoder.Decode(order);
            Thread thread = new Thread(() => OrderProcessing.process(order2, getPrice()));
            processingThreads.Add(thread);
            thread.Start();

            //USED FOR TESTING 
            // Console.WriteLine("ADDED TO BUFFER" + order2.ToString());
            //Console.WriteLine(getPrice() + "    WHAT IS SENT TO PROCESS");


        }




    }
}
