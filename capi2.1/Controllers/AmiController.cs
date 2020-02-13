using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hangfire;
using Hangfire.SqlServer;

namespace capi2_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmiController : ControllerBase
    {
        private List<string> lisMeters = new List<string>();
        private List<string> lisToken = new List<string>();

        public void arrayMeter() {
            lisMeters.Add("15367");
            lisMeters.Add("15424");
            lisMeters.Add("14320");
        }
        //lisMeters.Add(15422);
        
        // GET api/ReconnectMeter/15425
        [HttpGet("ReconnectMeter/{key}")]
        public ActionResult<string> ReconnectMeter(string key)
        {
            string ans = "400";
            queue q = new queue();
            ans =  BackgroundJob.Enqueue(() => q.ReconnectMeter(key));
            return ans;
        }
        [HttpGet("DisconnectMeter/{key}")]
        public ActionResult<string> DisconnectMeter(string key)
        {
            string ans = "400";
            queue q = new queue();
             
             ans = BackgroundJob.Enqueue(() => q.DisconnectMeter(key));
            
            return ans;
        }
        [HttpGet("ReconnectMeterMasive")]
        public ActionResult<string> ReconnectMeterMasive()
        {
            string ans = "400";
            queue q = new queue();
            arrayMeter();
            foreach (var item in lisMeters)
            {
                ans = BackgroundJob.Enqueue(() => q.ReconnectMeter(item));
            }
            
            return ans;
        }
        [HttpGet("DisconnectMeterMasive")]
        public ActionResult<string> DisconnectMeterMasive()
        {
            string ans = "400";
            queue q = new queue();
            arrayMeter();
            foreach (var item in lisMeters)
            {
                ans = BackgroundJob.Enqueue(() => q.DisconnectMeter(item));
            } 
            return ans;
        }

    }
}