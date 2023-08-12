using Microsoft.AspNetCore.Mvc;
using ProjectX.Helper;
using System;
using System.Collections;
using System.Threading;

namespace ProjectX.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConceptsController : ControllerBase
    {
        [HttpGet("multithread")]
        public ActionResult Test()
        {
            var x = new Multi();
            Thread thread1 = new Thread(() => x.usingLock("Thread1"));
            Thread thread2 = new Thread(() => x.usingLock("Thread2"));

            thread1.Start();
            thread2.Start();
            x.usingLock("Main Thread");


            return Ok();
        }


        [HttpGet("customEnumerable")]
        public ActionResult CustomEnumerable()
        {

            string[] abc = { "hello", "kilo" };
            CustomEnumerable<string> sampleEnum = new CustomEnumerable<string>(abc);


            IEnumerator e = sampleEnum.GetEnumerator();
            while (e.MoveNext())
            {
                Console.WriteLine(e.Current);
            }

            foreach (var x in abc)
            {
                Console.WriteLine(x);
            }

            return Ok(sampleEnum);
        }


        [HttpGet("disposeDemo")]
        public  ActionResult runDispose()
        {
            var obj1 = new DisposeDemo();
            //Check instance before dispose
            obj1.checkInstance();
            //Dispose needs to be called explicitly here
            obj1.Dispose();
            Console.WriteLine("Explicitly need to call dispose method for above");
            try
            {
                obj1.checkInstance();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception== "+ex.Message);
            }

            obj1 = null;
            GC.Collect(); // Forcing garbage collection

           Thread.Sleep(5000);


            using (var obj2 = new DisposeDemo())
            {
                Console.WriteLine("Dispose should be called after this block");
            }
            Console.WriteLine("Dispose should have been called before this outer statement");


            return Ok();

        }

    }
}