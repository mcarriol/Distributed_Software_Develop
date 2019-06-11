using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Xml;

namespace Booking
{
    class MultiCellBuffer
    {

        // Size of Buffer
        const int size = 3;

        // Helpers
        int head = 0, tail = 0,nElements = 0;

        //3 Data Cells n = 3
        string[] buffer = new string[size];

        // Semaphores 
        Semaphore write = new Semaphore(3, 3);
        Semaphore read = new Semaphore(2, 2);

       
       //String representation of the Order from the Travel Agency</param>
        public void setOneCell(string order)
        {
            write.WaitOne();
            

            lock (this)
            {
                // Busy Wait until there is a slot available in the Multi-Cell Buffer
                while (nElements == size)
                {
                    
                    Monitor.Wait(this);
                }

                buffer[tail] = order;
                tail = (tail + 1) % size;


                nElements++; // Increment the amount of elements
 
                write.Release();
                Monitor.Pulse(this);
            }
        }


        /// String representation of the Order from the Travel Agency</returns>
        public string getOneCell()
        {
            read.WaitOne();
           // Console.WriteLine("THREAD: " + Thread.CurrentThread.Name + " Entered Read");
            lock (this)
            {
                string element;
              

                // Busy Wait until an Element is in the Multi-Cell Buffer
                while (nElements == 0)
                {
                    
                    Monitor.Wait(this);
                }

                element = buffer[head];

               
                head = (head + 1) % size;
                nElements--;
              
                read.Release();

                Monitor.Pulse(this);
                return element;
            }
        }


    }
}
