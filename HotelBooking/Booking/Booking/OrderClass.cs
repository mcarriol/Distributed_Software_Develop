using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**OrderClass is a class that contains at least the following private data members:
 senderId: the identity of the sender, you can use thread name or thread id;
 cardNo: an integer that represents a credit card number;
 receiverID: the identity of the receiver, you can use thread name or a unique name that defined for
a hotel supplier; If you are doing an individual project, you do not need this field.
 amount: an integer that represents the number of room to order;
You must use public methods to set and get the private data members.
 **/ 
namespace Booking
{

   

    public class OrderClass
    {
        private int senderId;
        private int cardNo;
        private int amount;//amount of rooms for order 

        //Accessor & Mutator method for sender ID (travel agency id)
        public int SenderId//travelagency 
        {
            get { return senderId; }
            set { senderId = value; }
        }

        //Accessor & Mutator method for Credit Card Number 
        public int CardNo
        {
            get { return cardNo; }
            set { cardNo = value; }
        }

        //Accessor & Mutator method for amount of Rooms
        public int Rooms
        {
            get { return amount; }
            set { amount= value; }
        }

        //Displays contents of order, used for testing 
        public override string ToString()
        {
            return "ORDER\n\t{Sender ID: " + SenderId
                + "}\n\t{Credit Card: " + CardNo
                + "}\n\t{Amount of Rooms: " + Rooms
              + "}";
        }

    }
}
