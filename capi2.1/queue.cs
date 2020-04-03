using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.SqlServer;
using System.Threading;
using CAR_AMI_LIB;
 
namespace capi2_1
{
    /*
     
         select 
t.id,t.status,t.token,t.tokenType,t.period,
c.status ,
d.status,d.extendedSwitchState,
r.whd ,r.whnet ,r.whr,
tf.description ,tf.reason from Ami_Token t 
left join  Ami_Control c on c.token  = t.token 
left join Ami_Diagnostic d on d.token =t.token 
left join Ami_Token_Failure tf on tf.token  = t.token 
left join Ami_Reads r on r.token_request =t.token 
where t.meter = 15367 ;

         */
    public class queue
{ 

        public string[] queues = {
            "reconnect_meter",
            "disconnect_meter",
            "reconnect_meter_masive",
            "disconnect_meter_masive",
            "get_disconnect_meter_result_masive",
            "get_reconnect_meter_result_masive",
            "interactive_read_by_endpoint",
            "get_interactive_read_by_endpoint_result",
            "get_interactive_read_by_endpoint_result_masive",
            "interactive_read_by_endpoint_masive",
            "ping_by_endpoints",
            "get_ping_by_endpoints_result",
            "ping_by_endpoints_masive",
            "get_ping_by_endpoints_result_masive",
            "read_disconnect_state_by_meters",
            "get_read_disconnect_state_by_meters_result",
            "read_disconnect_state_by_meters_masive",
            "get_read_disconnect_state_by_meters_result_masive",
            "contingency_read_by_endpoints_request",
            "contingency_read_by_endpoints_request_masive",
            "interrogate_by_endpoints_request",
            "interrogate_by_endpoints_request_masive",
            "print"
        };
           


        public string[] queuesIds = {
            "ReconnectMeter",
            "DisconnectMeter",
            "ReconnectMeterMasive",
            "DisconnectMeterMasive",
            "GetDisconnectMeterResultMasive",
            "GetReconnectMeterResultMasive",
            "InteractiveReadByEndpoint", 
            "GetInteractiveReadByEndpointResult",
            "InteractiveReadByEndpointMasive",
            "GetInteractiveReadByEndpointResultMasive",
            "PingByEndpoints",
            "GetPingByEndpointsResult",
            "PingByEndpointsMsive",
            "GetPingByEndpointsResultMasive",
            "GetReadDisconnectStateByMetersResult",
            "ReadDisconnectStateByMeters",
            "GetReadDisconnectStateByMetersResultMasive",
            "ReadDisconnectStateByMetersMasive",
            "ContingencyReadByEndpoints",
            "ContingencyReadByEndpointsMasive",
            "InterrogateByEndpoints",
            "InterrogateByEndpointsMasive",
            "Print" 
        };
           
        public bool ba = false;
        /*************************************************************************************************************************************/
        /***********************************************CONTROL           *****************************************************************/
        /*************************************************************************************************************************************/
        [Queue("reconnect_meter")]
        public void ReconnectMeter(string key)
        {
            bool si = false;
            CAR_AMI_LIB.Ami_Control ami_Control = new CAR_AMI_LIB.Ami_Control();
            si = ami_Control.ReconnectMeter(key);
        }
        [Queue("disconnect_meter")]
        public void DisconnectMeter(string key)
        {
            bool si = false;
            CAR_AMI_LIB.Ami_Control ami_Control = new CAR_AMI_LIB.Ami_Control();
            si = ami_Control.DisconnectMeter(key); 
        }
        [Queue("reconnect_meter_masive")]
        public void ReconnectMeterMasive()
        {
            bool si = false;
            Ami_Control ami_Control = new CAR_AMI_LIB.Ami_Control();
            si = ami_Control.ReconnectMeterMasive();//ReconnectMeterMasive(key); 
        }
        [Queue("disconnect_meter_masive")]
        public void DisconnectMeterMasive()
        {
            bool si = false;
            CAR_AMI_LIB.Ami_Control ami_Control = new CAR_AMI_LIB.Ami_Control();
            si = ami_Control.DisconnectMeterMasive();
        }
        [Queue("get_disconnect_meter_result_masive")]
        public void GetDisconnectMeterResultMasive()
        {
            bool si = false;
            CAR_AMI_LIB.Ami_Control ami_Control = new CAR_AMI_LIB.Ami_Control();
            si = ami_Control.GetDisconnectMeterResultMasive(); 
        }
        [Queue("get_reconnect_meter_result_masive")]
        public void GetReconnectMeterResultMasive()
        {
            bool si = false;
            CAR_AMI_LIB.Ami_Control ami_Control = new CAR_AMI_LIB.Ami_Control();
            si = ami_Control.GetReconnectMeterResultMasive(); 
        }
        [Queue("print")]
        public void Print(string key,string d = null)
        {
            
            bool si = false;
            CAR_AMI_LIB.Print print = new CAR_AMI_LIB.Print();
            si = print.print(key,d); 
            Console.WriteLine("aqui "); 
        }
        [Queue("ping_by_endpoints")]
        public void PingByEndpoints(string key)//string[] arrKey
        {
            string resultado = "";
            bool si = false;
            CAR_AMI_LIB.Ami_Control ami_Control = new CAR_AMI_LIB.Ami_Control();
            si = ami_Control.PingByEndpoints(key);//arrKey 
        }
        [Queue("ping_by_endpoints_masive")]
        public void PingByEndpointsMasive()
        {
            string resultado = "";
            bool si = false;
            CAR_AMI_LIB.Ami_Control ami_Control = new CAR_AMI_LIB.Ami_Control();
            si = ami_Control.PingByEndpointsMasive();
        }
        [Queue("get_ping_by_endpoints_result")]

        public void GetPingByEndpointsResult(string token)
        {
            string resultado = "";
            bool si = false;
            CAR_AMI_LIB.Ami_Control ami_Control = new CAR_AMI_LIB.Ami_Control();
            si = ami_Control.GetPingByEndpointsResult(token);
        }
        [Queue("get_ping_by_endpoints_result_masive")]

        public void GetPingByEndpointsResultMasive()
        {
            string resultado = "";
            bool si = false;
            CAR_AMI_LIB.Ami_Control ami_Control = new CAR_AMI_LIB.Ami_Control();
            si = ami_Control.GetPingByEndpointsResultMasive();
        }
        /*************************************************************************************************************************************/
        /***********************************************DATA           *****************************************************************/
        /*************************************************************************************************************************************/
        [Queue("interactive_read_by_endpoint")]
        public void InteractiveReadByEndpoint(string key)
        {
            bool si = false;
            string resultado = "";
            CAR_AMI_LIB.Ami_Data ami_Data = new CAR_AMI_LIB.Ami_Data();
            si = ami_Data.InteractiveReadByEndpoint(key); 
        }
        [Queue("get_interactive_read_by_endpoint_result")]
        public void GetInteractiveReadByEndpointResult(string token)
        {
            string resultado = "";
            bool si = false;
            CAR_AMI_LIB.Ami_Data ami_Data = new CAR_AMI_LIB.Ami_Data();
            si = ami_Data.GetInteractiveReadByEndpointResult(token); 
        }
        [Queue("get_interactive_read_by_endpoint_result_masive")] 
        public void GetInteractiveReadByEndpointResultMasive()
        {
            bool si = false;
            string resultado = "";
            CAR_AMI_LIB.Ami_Data ami_Data = new CAR_AMI_LIB.Ami_Data();
            si = ami_Data.GetInteractiveReadByEndpointResultMasive(); 
        }
        [Queue("interactive_read_by_endpoint_masive")]
        public void InteractiveReadByEndpointMasive()
        {
            string resultado = "";
            bool si = false;
            CAR_AMI_LIB.Ami_Data ami_Data = new CAR_AMI_LIB.Ami_Data();
            si = ami_Data.InteractiveReadByEndpointMasive(); 
        }
        [Queue("contingency_read_by_endpoints")] 
        public void ContingencyReadByEndpoints(string key)
        {
            string resultado = "";
            bool si = false;
            CAR_AMI_LIB.Ami_Data ami_Data = new CAR_AMI_LIB.Ami_Data();
            si = ami_Data.ContingencyReadByEndpoints(key);
        }
        [Queue("contingency_read_by_endpoints_masive")]
        public void ContingencyReadByEndpointsMasive()
        {
            string resultado = "";
            bool si = false;
            CAR_AMI_LIB.Ami_Data ami_Data = new CAR_AMI_LIB.Ami_Data();
            si = ami_Data.ContingencyReadByEndpointsMasive();
        }
        [Queue("interrogate_by_endpoints")]
        public void InterrogateByEndpoints(string key)
        {
            string resultado = "";
            bool si = false;
            CAR_AMI_LIB.Ami_Data ami_Data = new CAR_AMI_LIB.Ami_Data();
            si = ami_Data.InterrogateByEndpoints(key);
        }
        [Queue("interrogate_by_endpoints_masive")]
        public void InterrogateByEndpointsMasive()
        {
            string resultado = "";
            bool si = false;
            CAR_AMI_LIB.Ami_Data ami_Data = new CAR_AMI_LIB.Ami_Data();
            si = ami_Data.InterrogateByEndpointsMasive();
        }
        /*************************************************************************************************************************************/
        /***********************************************DIAGNOSTIC           *****************************************************************/
        /*************************************************************************************************************************************/

        [Queue("get_read_disconnect_state_by_meters_result")] 
        public void GetReadDisconnectStateByMetersResult(string token)
        {
            string resultado = "";
            bool si = false;
            CAR_AMI_LIB.Ami_Diagnostic ami_Diagnostic = new CAR_AMI_LIB.Ami_Diagnostic();
            si = ami_Diagnostic.GetReadDisconnectStateByMetersResult(token); 
        }
        [Queue("get_read_disconnect_state_by_meters_result_masive")]
        public void GetReadDisconnectStateByMetersResultMasive()
        {
            string resultado = "";
            bool si = false;
            CAR_AMI_LIB.Ami_Diagnostic ami_Diagnostic = new CAR_AMI_LIB.Ami_Diagnostic();
            si = ami_Diagnostic.GetReadDisconnectStateByMetersResultMasive(); 
        }
        [Queue("read_disconnect_state_by_meters")]
        public void ReadDisconnectStateByMeters(string key)//string[] arrKey
        {
            string resultado = "";
            bool si = false;
            CAR_AMI_LIB.Ami_Diagnostic ami_Diagnostic = new CAR_AMI_LIB.Ami_Diagnostic();
            si = ami_Diagnostic.ReadDisconnectStateByMeters(key);//arrKey 
        }
        [Queue("read_disconnect_state_by_meters_masive")]
        public void ReadDisconnectStateByMetersMasive()
        {
            string resultado = "";
            bool si = false;
            CAR_AMI_LIB.Ami_Diagnostic ami_Diagnostic = new CAR_AMI_LIB.Ami_Diagnostic();
            si = ami_Diagnostic.ReadDisconnectStateByMetersMasive(); 
        }


    }
}
