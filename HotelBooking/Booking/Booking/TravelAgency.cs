using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Booking.Program;

/** each travel agency is a thread instantiated from the same
class (or the same method) in a class. The travel agency’s actions are event-driven. Each travel agency
contains a call-back method (event handler) for the HotelSuppliers to call when a price-cut event occurs.
The travel agency will calculate the number of rooms to order, for example, based on the need and the
difference between the previous price and the current price. The thread will terminate after the
HotelSupplier thread has terminated. Each order is an OrderClass object. The object is sent to the Encoder
for encoding. The encoded string is sent back to the travel agency. Then, the travel agency will send the
order in String format to the MultiCellBuffer. Before sending the order to the MultiCellBuffer, a time
stamp must be saved. When the confirmation of order completion is received, the time of the order will be
calculated and saved (or printed). You can set N = 5 in your implementation. 
 */
namespace Booking
{
    class TravelAgency
    {



        // Array of Credit Cards for Testing
        private static int[] creditsample =
        {
            3333,
            4000,
            1000,
            3000,
            2000

        };

       
        private static bool hotelsActive = true;
        private static Random random = new Random(); // Random number generator
        private bool roomsNeeded = true;
        private bool bulkOrder = false; 
        private double unitPrice;
        private int agencyID;
        private DateTime start; 
        
       
        public TravelAgency()
        {

        }

  
        //Execution thread for the TravelAgency class. Creates a order continuously until HotelSupplier threads are no longer active.
       
        public void Run()
        {
            // Continue Travel Agency thread until Hotels thread is no longer active
            while (hotelsActive)
            {
              
                // Check if an order needs to be created
                if (roomsNeeded)
                {
                    if (bulkOrder)
                    {
                       int  num = random.Next(100,300);
                        CreateOrder(num);
                    }
                    else
                    {
                        int num = random.Next(20, 60);
                        CreateOrder(num);
                    }
                }
                else
                {
                    // No orders, allow thread to sleep
                     //Console.WriteLine("Waiting: Travel Agency Thread ({0})", Thread.CurrentThread.Name);
                    Thread.Sleep(1000);
                    roomsNeeded = true;
                }
                
            }

            Console.WriteLine("CLOSING: Travel Agency Thread ({0})", Thread.CurrentThread.Name);
        }


       
        /// Called once the TravelAgency thread has come back from sleeping. To create an order by encoding the order object and adding to buffer. 
        private void CreateOrder(int rooms)
        {

            // Tell system no order is needed
            roomsNeeded = false;
            //Create order object
            OrderClass order = new OrderClass();
            order.Rooms = rooms;
            int travelId = Convert.ToInt32(Thread.CurrentThread.Name);
            agencyID = travelId;
            order.SenderId = travelId;
            order.CardNo = creditsample[travelId - 1];
            start = DateTime.Now;
            Program.buffer.setOneCell(Encoder.Encode(order));


        }

     //start threads for confirmation of order 
        public void confirmation(double price, int rooms, int agencyid, int cardno)
        {
            Thread confirmations = new Thread(() => output(price, rooms, agencyid,cardno ));
            confirmations.Start();
        }
        //displays the order contents due to confirmation 
        public void output(double price, int rooms, int agencyid, int cardno )
        {
            if (agencyID == agencyid)
            {

                Console.WriteLine("Time for completion is start: {0} end:{1} Purchased {2} rooms for ${3} for Travel Agency {4} Using card number: {5}.", start.ToString("hh:mm:ss"), DateTime.Now.ToString("hh:mm:ss"), rooms, price, agencyid,cardno);
            }
        }

        //Method sets bulk order for travel agency to buy more rooms due to pricecut event
        public void PriceCutOrder(double price, double prev)
        {
            
            bulkOrder = true;
            unitPrice = price;
          
        
        }
        
        //Accessor/Mutator for HotelSupplier to notify TravelAgency Thread if alive or not
       
        public static bool HotelsActive
        {
            get { return TravelAgency.hotelsActive; }
            set { TravelAgency.hotelsActive = value; }
        }
    }


}

