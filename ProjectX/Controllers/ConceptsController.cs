using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectX.Helpers;
using Serilog.Core;
using System;
using System.Collections;
using System.Diagnostics.Eventing.Reader;
using System.Threading;

namespace ProjectX.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConceptsController : ControllerBase
    {
        private ILogger<ConceptsController> _logger;

        public ConceptsController(ILogger<ConceptsController> logger) 
        { 
            _logger = logger;
        }

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



        [HttpGet("serilogTest")]
        public ActionResult SerilogTest()
        {
            //Basic Logging
            _logger.LogInformation("This is a log inside serilog test endpoint");

            //Structured Logging
            var book = "Twinkle";
            var OrderNumber = 76238723;
            _logger.LogInformation("Processing book {@book} , order number ={@OrderNumber}", book, OrderNumber);

            return Ok("Info logged");    
        }

    }
}