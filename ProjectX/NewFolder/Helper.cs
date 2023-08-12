using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ProjectX.Helper
{

    public class Multi
    {
        int val1 = 0;
        int val2 = 0;
        int val3 = 0;
        public void usingLock(string threadName)
        {
           lock (this)  //This part will be executed one by one using thread
            for (int i = 0; i < 200000; i++)
            {
                {

                    val1 = 1;
                    val2 = 1;
                    Console.WriteLine($"val1 is {val1}, val2 is {val2}, i is {i} Threadname is {threadName}");
                    val3 = val1 / val2;
                    val1 = 0;
                    val2 = 0;

                }

            }
            

        }


        public void usingMonitor(string threadName)
        {
            Monitor.Enter(this);  // Same effect as lock, old way of locking 
                for (int i = 0; i < 200000; i++)
                {
                    {

                        val1 = 1;
                        val2 = 1;
                        Console.WriteLine($"val1 is {val1}, val2 is {val2}, i is {i} Threadname is {threadName}");
                        val3 = val1 / val2;
                        val1 = 0;
                        val2 = 0;

                    }

                }
            Monitor.Exit(this);


        }
    }

    public class CustomEnumerable<T> : IEnumerable
    {
        public IEnumerable<T> values;

        public CustomEnumerable(IEnumerable<T> items) 
        {
            values = items;
        }
        public IEnumerator GetEnumerator()
        {
            return values.GetEnumerator();
            
        }

        public int Count()
        {
            return values.Count();
        }


    }


    public class DisposeDemo : IDisposable
    {
        //Set to true once dipose method is called;
        private bool _disposed = false;
        //Destrcutor
        public DisposeDemo()
        {
            Console.WriteLine("Demo constructor ran");
        }
        ~DisposeDemo()
        {
            Console.WriteLine("Destructor is called");
           // Desctructor calls finalize method
        }

        public void checkInstance()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
            {
                
            }
            Console.WriteLine("Instance is active");
        }

        /*You might have to call this method when you want to 
         * dispose the resource help by the instance.
         */
        public void Dispose()
        {
            Console.WriteLine("Running dispose");
            Dispose(true);
            /*this will prevent finalize from running which is
            invoked from destrcutor*/
            //GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    //dipose all the resources

                    //set dipose flag to true 
                    _disposed = true;
                }
            }
        }

        /*Use profiler to identify memory issue
        Dotnet object allocation tracking*/
    }
}
