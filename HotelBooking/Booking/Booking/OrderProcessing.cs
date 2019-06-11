using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Booking.Program;
/**OrderProcessing is a class or a method in a class on the supplier’s side.Whenever an order needs to be
processed, a new thread is instantiated from this class (or method) to process the order.It will check the
validity of the credit card number.You can define your credit card format, for example, the credit card
number from the travel agencies must be a number registered to the HotelSupplier, or a number between
two given numbers (e.g., between 5000 and 7000). Each OrderProcessing thread will calculate the total
amount of charge, e.g., unitPrice* NoOfRooms + Tax + LocationCharge.
**/
namespace Booking
{
    class OrderProcessing
    {
        //Event for sending a confirmation to the travel agency and prints the order // 
        public static event OrderConfirmedEvent orderConfirmed;

        //Used to calculate total cost
        private static double Tax = 10;
        private static double location = 20;
      

        //procsses order by checking validation of credit card, and sends travel agency a confirmation.
        public static void process(OrderClass order1, double price)
        { 

            if(order1 != null)
            {
                

                // Check for a valid credit card number
                if (ValidateCredit(order1.CardNo)==true)
                {
                    
                    double totalcost = ((order1.Rooms * price) + Tax + location);

                    //USED FOR TESTING 
                    /*Console.WriteLine("PROCESSED: {0} Travel Agency Order {1}\n\tTOTAL PRICE: {2}",
                    Thread.CurrentThread.Name, order2.ToString(),totalcost);*/

                    //Order confirmed 
                    orderConfirmed(totalcost, order1.Rooms, order1.SenderId, order1.CardNo);

                }
                else
                {
                    Console.WriteLine("Not a valid credit card: ({0}) ", Thread.CurrentThread.Name);
                    return;
                }

                
            }
            else
            {
                Console.WriteLine("No Order Recieved");
            }
        }


        private static bool ValidateCredit(int credit)
        {
            if (credit >= 1000 && credit <= 5000)
            {
                return true;
            }
            else
               return false;
        }

        /*public double UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }*/


    }
}
