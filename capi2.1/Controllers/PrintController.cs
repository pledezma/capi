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
        public ActionResult<string> Print(string key,string d = null)
        {
            string ans = "400";
            queue q = new queue();
            ans = BackgroundJob.Enqueue(() => q.Print(key,d));
            return ans;
        }
        [HttpGet("hola/{key}")]
        public ActionResult<string> Hola(string key )
        {
            string ans = "hola "+ key;
             
            return ans;
        }
        [HttpGet("ErrorTest")]
        public ActionResult<string> ErrorTest()
        {
          string ans = "400";
            /*EndpointFailure k = new EndpointFailure();
            Ami_Diagnostic_Service.ReadDisconnectStateByMetersResult readDisconnectStateByMetersResult = new Ami_Diagnostic_Service.ReadDisconnectStateByMetersResult();
            k.convertFailure(readDisconnectStateByMetersResult);
            Ami_Control_Service.EndpointRequestResult endpointRequestResult = new Ami_Control_Service.EndpointRequestResult();
            k.convertFailure(endpointRequestResult);
            Ami_Data_Service.InteractiveReadByEndpointResult interactiveReadByEndpointResult = new Ami_Data_Service.InteractiveReadByEndpointResult();
            k.convertFailure(interactiveReadByEndpointResult);*/
            return ans;
        }

    }
}