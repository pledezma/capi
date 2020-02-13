using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAR_AMI_LIB;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace capi2_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrintController : ControllerBase
    {
        [HttpGet("{key}")]
        public ActionResult<string> Print(string key)
        {
            string ans = "400";
            queue q = new queue();
            ans = BackgroundJob.Enqueue(() => q.Print(key));
            return ans;
        }

    }
}