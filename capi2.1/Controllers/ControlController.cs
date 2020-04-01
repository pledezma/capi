﻿using System;
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
    public class ControlController : ControllerBase
    {
       
        //lisMeters.Add(15422);
        
        // GET api/ReconnectMeter/15425
        [HttpGet("ReconnectMeter/{key}")]
        public ActionResult<string> ReconnectMeter(string key)
        {
            string ans = "400";
            queue q = new queue();
            try
            {
                ans = BackgroundJob.Enqueue(() => q.ReconnectMeter(key));
            }
            catch (Exception)
            {

               
            }
            return ans;
        }
        [HttpGet("DisconnectMeter/{key}")]
        public ActionResult<string> DisconnectMeter(string key)
        {
            string ans = "400";
            queue q = new queue();

            try
            {
                ans = BackgroundJob.Enqueue(() => q.DisconnectMeter(key));
            }
            catch (Exception)
            {

                
            }
            
            return ans;
        }
        [HttpGet("ReconnectMeterMasive")]
        public ActionResult<string> ReconnectMeterMasive() 
        {
            string ans = "400";
            queue q = new queue();
            
           /* foreach (var item in lisMeters)
            {
                try
                {*/
                    ans = BackgroundJob.Enqueue(() => q.ReconnectMeterMasive());
                /*}
                catch (Exception)
                {

                    
                }
            }*/
            
            return ans;
        }
        [HttpGet("DisconnectMeterMasive")]
        public ActionResult<string> DisconnectMeterMasive()
        {
            string ans = "400";
            queue q = new queue();
            /*arrayMeter();
            foreach (var item in lisMeters)
            {
                try
                {*/
                    ans = BackgroundJob.Enqueue(() => q.DisconnectMeterMasive());
            /*}
            catch (Exception)
            {


            }
        } */
            return ans;
        }
        [HttpGet("GetReconnectMeterResultMasive")] 
        public ActionResult<string> GetReconnectMeterResultMasive()
        {
            string ans = "400";
            queue q = new queue();
            
            ans = BackgroundJob.Enqueue(() => q.GetReconnectMeterResultMasive());
            //RecurringJob.AddOrUpdate(() => q.GetReconnectMeterResultMasive(), Cron.Minutely);

            //RecurringJob.RemoveIfExists("queue.ReconnectMeterMasive");

            return ans;
        }
        [HttpGet("GetDisconnectMeterResultMasive")]
        public ActionResult<string> GetDisconnectMeterResultMasive()
        {
            string ans = "400";
            queue q = new queue();

            ans = BackgroundJob.Enqueue(() => q.GetDisconnectMeterResultMasive());
            //RecurringJob.AddOrUpdate(() => q.GetDisconnectMeterResultMasive(), Cron.Minutely);

            return ans;
        }
        [HttpGet("Print/{val}")]
        public ActionResult<string> Print(string val,string d = null) 
        {
            string ans = "400";
            queue q = new queue(); 
             
                try
                {
                    ans = BackgroundJob.Enqueue(() => q.Print(val,d));
                }
                catch (Exception)
                {


                }
            
            return ans;
        }

    }
}