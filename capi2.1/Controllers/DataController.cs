using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hangfire;

namespace capi2_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("InteractiveReadByEndpointRequest/{key}")]
        public ActionResult<string> InteractiveReadByEndpointRequest(string key)
        {
            string ans = "400";
            queue q = new queue();
            try
            {
                ans = BackgroundJob.Enqueue(() => q.InteractiveReadByEndpointRequest(key));
            }
            catch (Exception)
            {

               
            }
            return ans;
        }
        [HttpGet("InteractiveReadByEndpointResult/{token}")]
        public ActionResult<string> InteractiveReadByEndpointResult(string token)
        {
            string ans = "400";
            queue q = new queue();
            try
            {
                ans = BackgroundJob.Enqueue(() => q.InteractiveReadByEndpointResult(token));
            }
            catch (Exception)
            {

               
            }
            return ans;
        }
        [HttpGet("InteractiveReadByEndpointResultMasive")]
        public ActionResult<string> InteractiveReadByEndpointResultMasive()
        {
            string ans = "400";
            queue q = new queue();

            try
            {
                //ans = BackgroundJob.Enqueue(() => q.InteractiveReadByEndpointResultMasive());
                RecurringJob.AddOrUpdate(() => q.InteractiveReadByEndpointResultMasive(), Cron.Minutely);
            }
            catch (Exception)
            {


            } 

            return ans;
        }
        [HttpGet("InteractiveReadByEndpointRequestMasive")]
        public ActionResult<string> InteractiveReadByEndpointRequestMasive()
        {
            string ans = "400";
            queue q = new queue();

            try
            {
                ans = BackgroundJob.Enqueue(() => q.InteractiveReadByEndpointRequestMasive());
            }
            catch (Exception)
            {


            }

            return ans;
        }
    }
}