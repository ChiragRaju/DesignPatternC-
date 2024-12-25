using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    
    // we use sealed class because the nested class can create an intance pf object
    public sealed class Singleton
    {
        private static int counter = 0;
        private static Singleton instance = null;
        private static readonly Object obj=new object();
        private Singleton() {
            counter++;

            Console.WriteLine("Counter value" + counter.ToString());
        }

        //THIS IS NOT EFFICINET FOR MULTITHREADED so we use Lock //refer double checked locking
        public static Singleton GetInstance
        {
            get
            {
                if(instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                        { 
                           instance = new Singleton(); 
                        }
                    }

                }
                
                return instance;
            }
        }



        public static void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }
    }
}
