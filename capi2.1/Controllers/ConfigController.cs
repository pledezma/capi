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
    public class ConfigController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("CronJob/{key}/{value}")]
        public IActionResult CronJob(string key = null, string value = null)
        {
            string ans = "400";
            queue q = new queue();
            try
            {
                switch (key)
                {
                    case "stop":
                            switch (value)
                            {
                            case "0":
                               
                                break;
                            case "1":
                               
                                break;
                            case "2":
                                 
                                break;
                            case "3":
                                 
                                break;
                            case "4":
                                RecurringJob.RemoveIfExists("queue.GetDisconnectMeterResultMasive");
                                break;
                            case "5":
                                RecurringJob.RemoveIfExists("queue.GetReconnectMeterResultMasive");
                                break;
                            case "6":
                                
                                break;
                            case "7":
                                
                                break;
                            case "8":
                                
                                break;
                            case "9":
                                 
                                break;
                            case "10":
                                RecurringJob.RemoveIfExists("queue.GetInteractiveReadByEndpointResultMasive");
                                break;
                            case "11":
                               
                                break;
                            case "12":

                                break;
                            case "13":

                                break;
                            case "14":

                                break;
                            case "15":

                                break;
                            case "16":

                                break;
                            case "17":

                                break;
                            case "18":

                                break;
                            case "19":

                                break;
                            case "all":
                                foreach (var item in q.queuesIds)
                                {
                                    RecurringJob.RemoveIfExists("queue." + item);
                                }
                                break;
                            default:
                                
                                break;
                        }
                        break;
                    case "load":
                        switch (value)
                        {
                            case "0":
                                
                                break;
                            case "1":
                                
                                break;
                            case "2":
                                
                                break;
                            case "3":
                                
                                break;
                            case "4":
                                RecurringJob.AddOrUpdate(() => q.GetDisconnectMeterResultMasive(), Cron.Minutely);
                                break;
                            case "5":
                                RecurringJob.AddOrUpdate(() => q.GetReconnectMeterResultMasive(), Cron.Minutely);  
                                break;
                            case "6":
                                 
                                break;
                            case "7":
                                
                                break;
                            case "8":
                                
                                break;
                            case "9":
                                 
                                break;
                            case "10":
                                RecurringJob.AddOrUpdate(() => q.GetInteractiveReadByEndpointResultMasive(), Cron.Minutely);
                                break;
                            case "11":

                                break;
                            case "12":

                                break;
                            case "13":

                                break;
                            case "14":

                                break;
                            case "15":

                                break;
                            case "16":

                                break;
                            case "17":

                                break;
                            case "18":

                                break;
                            case "19":

                                break;
                            case "all":
                                RecurringJob.AddOrUpdate(() => q.GetInteractiveReadByEndpointResultMasive(), Cron.Minutely);
                                RecurringJob.AddOrUpdate(() => q.GetReconnectMeterResultMasive(), Cron.Minutely);
                                RecurringJob.AddOrUpdate(() => q.GetDisconnectMeterResultMasive(), Cron.Minutely);
                                break;
                            default: 
                                
                                break;
                        }
                        break;
                     
                }
                
               
                ans = "200";
            }
            catch (Exception)
            {


            }
            ViewBag.list = q.queuesIds;
            return View();
        }
    }
}