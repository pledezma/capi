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
        [HttpGet("InteractiveReadByEndpoint/{key}")]
        public ActionResult<string> InteractiveReadByEndpoint(string key)
        {
            string ans = "400";
            queue q = new queue();
            try
            {
                ans = BackgroundJob.Enqueue(() => q.InteractiveReadByEndpoint(key));
            }
            catch (Exception)
            {

               
            }
            return ans;
        }
        [HttpGet("GetInteractiveReadByEndpointResult/{token}")]
        public ActionResult<string> GetInteractiveReadByEndpointResult(string token)
        {
            string ans = "400";
            queue q = new queue();
            try
            {
                ans = BackgroundJob.Enqueue(() => q.GetInteractiveReadByEndpointResult(token));
            }
            catch (Exception)
            {

               
            }
            return ans;
        }
        [HttpGet("GetInteractiveReadByEndpointResultMasive")]
        public ActionResult<string> GetInteractiveReadByEndpointResultMasive()
        {
            string ans = "400";
            queue q = new queue();

            try
            {
                ans = BackgroundJob.Enqueue(() => q.GetInteractiveReadByEndpointResultMasive());
                //RecurringJob.AddOrUpdate(() => q.InteractiveReadByEndpointResultMasive(), Cron.Minutely);
            }
            catch (Exception)
            {


            } 

            return ans;
        }
        [HttpGet("InteractiveReadByEndpointMasive")]
        public ActionResult<string> InteractiveReadByEndpointMasive()
        {
            string ans = "400";
            queue q = new queue();
            try
            {
                ans = BackgroundJob.Enqueue(() => q.InteractiveReadByEndpointMasive());
            }
            catch (Exception)
            {
            }
            return ans;
        }
        [HttpGet("ContingencyReadByEndpoints/{key}")]
        public ActionResult<string> ContingencyReadByEndpoints(string key)
        {
            string ans = "400";
            queue q = new queue();
            try
            {
                ans = BackgroundJob.Enqueue(() => q.ContingencyReadByEndpoints(key));
            }
            catch (Exception)
            {
            }
            return ans;
        }
        [HttpGet("ContingencyReadByEndpointsMasive")]
        public ActionResult<string> ContingencyReadByEndpointsMasive()
        {
            string ans = "400";
            queue q = new queue();
            try
            {
                ans = BackgroundJob.Enqueue(() => q.ContingencyReadByEndpointsMasive()); 
            }
            catch (Exception)
            {
            }
            return ans;
        }
        [HttpGet("InterrogateByEndpoints/{key}")]
        public ActionResult<string> InterrogateByEndpoints(string key)
        {
            string ans = "400";
            queue q = new queue();
            try
            {
                ans = BackgroundJob.Enqueue(() => q.InterrogateByEndpoints(key));
            }
            catch (Exception)
            {
            }
            return ans;
        }
        [HttpGet("InterrogateByEndpointsMasive")]
        public ActionResult<string> InterrogateByEndpointsMasive()
        {
            string ans = "400";
            queue q = new queue();
            try
            {
                ans = BackgroundJob.Enqueue(() => q.InterrogateByEndpointsMasive());
            }
            catch (Exception)
            {
            }
            return ans;
        } 
    }
}