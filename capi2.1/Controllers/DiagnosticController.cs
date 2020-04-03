using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace capi2_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosticController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("PingByEndpoints/{key}")]
        public ActionResult<string> PingByEndpoints(string key)
        {
            string ans = "400";
            queue q = new queue();
            /*string[] meters = null;
            meters = new string[1];
            meters[0] = key;*/
            ans = BackgroundJob.Enqueue(() => q.PingByEndpoints(key));//meters
            //RecurringJob.AddOrUpdate(() => q.PingByEndpoints(), Cron.Minutely);

            return ans;
        }
        [HttpGet("GetPingByEndpointsResult/{token}")]
        public ActionResult<string> GetPingByEndpointsResult(string token)
        {
            string ans = "400";
            queue q = new queue();
            ans = BackgroundJob.Enqueue(() => q.GetPingByEndpointsResult(token));
            //RecurringJob.AddOrUpdate(() => q.GetPingByEndpointsResult(), Cron.Minutely);

            return ans;
        }
        [HttpGet("GetPingByEndpointsResultMasive")]
        public ActionResult<string> GetPingByEndpointsResultMasive( )
        {
            string ans = "400";
            queue q = new queue();
            ans = BackgroundJob.Enqueue(() => q.GetPingByEndpointsResultMasive());
            //RecurringJob.AddOrUpdate(() => q.GetPingByEndpointsResultMasive(), Cron.Minutely);

            return ans;
        }
        [HttpGet("PingByEndpointsMasive")]
        public ActionResult<string> PingByEndpointsMasive()
        {
            string ans = "400";
            queue q = new queue();
            
            ans = BackgroundJob.Enqueue(() => q.PingByEndpointsMasive());
            //RecurringJob.AddOrUpdate(() => q.PingByEndpointsMasive(), Cron.Minutely);

            return ans;
        }
        [HttpGet("GetReadDisconnectStateByMetersResult/{token}")]
        public ActionResult<string> GetReadDisconnectStateByMetersResult(string token)
        {
            string ans = "400";
            queue q = new queue();
            ans = BackgroundJob.Enqueue(() => q.GetReadDisconnectStateByMetersResult(token));
            //RecurringJob.AddOrUpdate(() => q.GetReadDisconnectStateByMetersResult(), Cron.Minutely);

            return ans;
        }
        [HttpGet("ReadDisconnectStateByMeters/{key}")]
        public ActionResult<string> ReadDisconnectStateByMeters(string key)
        {
            string ans = "400";
            queue q = new queue();
            /*string[] meters = null;
            meters = new string[1];
            meters[0] = key;*/
            ans = BackgroundJob.Enqueue(() => q.ReadDisconnectStateByMeters(key));//meters
            //RecurringJob.AddOrUpdate(() => q.ReadDisconnectStateByMeters(), Cron.Minutely);

            return ans;
        }
        [HttpGet("ReadDisconnectStateByMetersMasive")]
        public ActionResult<string> ReadDisconnectStateByMetersMasive()
        {
            string ans = "400";
            queue q = new queue();
            
            ans = BackgroundJob.Enqueue(() => q.ReadDisconnectStateByMetersMasive());
            //RecurringJob.AddOrUpdate(() => q.ReadDisconnectStateByMetersMasive(), Cron.Minutely);

            return ans;
        }
        [HttpGet("GetReadDisconnectStateByMetersResultMasive")]
        public ActionResult<string> GetReadDisconnectStateByMetersResultMasive()
        {
            string ans = "400";
            queue q = new queue();
            
            ans = BackgroundJob.Enqueue(() => q.GetReadDisconnectStateByMetersResultMasive());
            //RecurringJob.AddOrUpdate(() => q.GetReadDisconnectStateByMetersResultMasive(), Cron.Minutely);

            return ans;
        }


    }
}