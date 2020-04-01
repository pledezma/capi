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
    public class queue
{ 

        public string[] queues = {
            "reconnect_meter",
            "disconnect_meter",
            "reconnect_meter_masive",
            "disconnect_meter_masive",
            "get_disconnect_meter_result_masive",
            "get_reconnect_meter_result_masive",
            "interactive_read_by_endpoint_request",
            "interactive_read_by_endpoint_result",
            "interactive_read_by_endpoint_result_masive",
            "interactive_read_by_endpoint_request_masive",
            "ping_by_endpoints",
            "get_ping_by_endpoints_result",
            "ping_by_endpoints_masive",
            "get_ping_by_endpoints_result_masive",
            "read_disconnect_state_by_meters",
            "get_read_disconnect_state_by_meters_result",
            "read_disconnect_state_by_meters_masive",
            "get_read_disconnect_state_by_meters_result_masive",
            "print"
        };

         
        public string[] queuesIds = {
            "ReconnectMeter",
            "DisconnectMeter",
            "ReconnectMeterMasive",
            "DisconnectMeterMasive",
            "GetDisconnectMeterResultMasive",
            "GetReconnectMeterResultMasive",
            "InteractiveReadByEndpointRequest",
            "InteractiveReadByEndpointResult",
            "InteractiveReadByEndpointRequestMasive",
            "InteractiveReadByEndpointResultMasive",
            "PingByEndpoints",
            "GetPingByEndpointsResult",
             "PingByEndpointsMsive",
              "GetPingByEndpointsResultMasive",
            "GetReadDisconnectStateByMetersResult",
            "ReadDisconnectStateByMeters",
            "GetReadDisconnectStateByMetersResultMasive",
            "ReadDisconnectStateByMetersMasive",
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
            ba = si;
            Console.WriteLine("aqui");

        }
        [Queue("disconnect_meter")]
        public void DisconnectMeter(string key)
        {
            bool si = false;
            CAR_AMI_LIB.Ami_Control ami_Control = new CAR_AMI_LIB.Ami_Control();
            si = ami_Control.DisconnectMeter(key);

            Console.WriteLine("aqui ");

        }
        [Queue("reconnect_meter_masive")]
        public void ReconnectMeterMasive()
        {
            bool si = false;
            Ami_Control ami_Control = new CAR_AMI_LIB.Ami_Control();
            si = ami_Control.ReconnectMeterMasive();//ReconnectMeterMasive(key);

            Console.WriteLine("aqui ");

        }
        [Queue("disconnect_meter_masive")]
        public void DisconnectMeterMasive()
        {
            bool si = false;
            CAR_AMI_LIB.Ami_Control ami_Control = new CAR_AMI_LIB.Ami_Control();
            si = ami_Control.DisconnectMeterMasive();

            Console.WriteLine("aqui ");

        }
        [Queue("get_disconnect_meter_result_masive")]
        public void GetDisconnectMeterResultMasive()
        {
            bool si = false;
            CAR_AMI_LIB.Ami_Control ami_Control = new CAR_AMI_LIB.Ami_Control();
            si = ami_Control.GetDisconnectMeterResultMasive();

            Console.WriteLine("aqui ");

        }
        [Queue("get_reconnect_meter_result_masive")]
        public void GetReconnectMeterResultMasive()
        {
            bool si = false;
            CAR_AMI_LIB.Ami_Control ami_Control = new CAR_AMI_LIB.Ami_Control();
            si = ami_Control.GetReconnectMeterResultMasive();

            Console.WriteLine("aqui ");

        }
        [Queue("print")]
        public void Print(string key,string d = null)
        {
            
            bool si = false;
            CAR_AMI_LIB.Print print = new CAR_AMI_LIB.Print();
            si = print.print(key,d); 
            Console.WriteLine("aqui "); 
        }

        /*************************************************************************************************************************************/
        /***********************************************DATA           *****************************************************************/
        /*************************************************************************************************************************************/
        [Queue("interactive_read_by_endpoint_request")]
        public void InteractiveReadByEndpointRequest(string key)
        {
            bool si = false;
            string resultado = "";
            CAR_AMI_LIB.Ami_Data ami_Data = new CAR_AMI_LIB.Ami_Data();
            si = ami_Data.InteractiveReadByEndpointRequest(key);
            //Print(resultado,"token");
            Console.WriteLine("aqui " + resultado);
        }
        [Queue("interactive_read_by_endpoint_result")]
        public void InteractiveReadByEndpointResult(string token)
        {
            string resultado = "";
            bool si = false;
            CAR_AMI_LIB.Ami_Data ami_Data = new CAR_AMI_LIB.Ami_Data();
            si = ami_Data.InteractiveReadByEndpointResult(token);
            Print(resultado, "lectura");
            Console.WriteLine("aqui " + resultado);
        }
        [Queue("interactive_read_by_endpoint_request_masive")] 
        public void InteractiveReadByEndpointRequestMasive()
        {
            bool si = false;
            string resultado = "";
            CAR_AMI_LIB.Ami_Data ami_Data = new CAR_AMI_LIB.Ami_Data();
            si = ami_Data.InteractiveReadByEndpointRequestMasive();
            //Print(resultado,"token");
            Console.WriteLine("aqui " + resultado);
        }
        [Queue("interactive_read_by_endpoint_result_masive")]
        public void InteractiveReadByEndpointResultMasive()
        {
            string resultado = "";
            bool si = false;
            CAR_AMI_LIB.Ami_Data ami_Data = new CAR_AMI_LIB.Ami_Data();
            si = ami_Data.InteractiveReadByEndpointResultMasive();
            Print(resultado, "lectura");
            Console.WriteLine("aqui " + resultado);
        }
        /*************************************************************************************************************************************/
        /***********************************************DIAGNOSTIC           *****************************************************************/
        /*************************************************************************************************************************************/
        [Queue("ping_by_endpoints")]
        public void PingByEndpoints(string[] arrKey)
        {
            string resultado = "";
            bool si = false;
            CAR_AMI_LIB.Ami_Diagnostic ami_Diagnostic = new CAR_AMI_LIB.Ami_Diagnostic();
            si = ami_Diagnostic.PingByEndpoints(arrKey);
            Print(resultado, "lectura");
            Console.WriteLine("aqui " + resultado);
        }
        [Queue("ping_by_endpoints_masive")]
        public void PingByEndpointsMasive()
        {
            string resultado = "";
            bool si = false;
            CAR_AMI_LIB.Ami_Diagnostic ami_Diagnostic = new CAR_AMI_LIB.Ami_Diagnostic();
            si = ami_Diagnostic.PingByEndpointsMasive();
            Print(resultado, "lectura");
            Console.WriteLine("aqui " + resultado);
        }
        [Queue("get_ping_by_endpoints_result")]
       
        public void GetPingByEndpointsResult(string token)
        {
            string resultado = "";
            bool si = false;
            CAR_AMI_LIB.Ami_Diagnostic ami_Diagnostic = new CAR_AMI_LIB.Ami_Diagnostic();
            si = ami_Diagnostic.GetPingByEndpointsResult(token);
            Print(resultado, "lectura");
            Console.WriteLine("aqui " + resultado);
        }
        [Queue("get_ping_by_endpoints_result_masive")]

        public void GetPingByEndpointsResultMasive()
        {
            string resultado = "";
            bool si = false;
            CAR_AMI_LIB.Ami_Diagnostic ami_Diagnostic = new CAR_AMI_LIB.Ami_Diagnostic();
            si = ami_Diagnostic.GetPingByEndpointsResultMasive();
            Print(resultado, "lectura");
            Console.WriteLine("aqui " + resultado);
        }
        [Queue("get_read_disconnect_state_by_meters_result")] 
        public void GetReadDisconnectStateByMetersResult(string token)
        {
            string resultado = "";
            bool si = false;
            CAR_AMI_LIB.Ami_Diagnostic ami_Diagnostic = new CAR_AMI_LIB.Ami_Diagnostic();
            si = ami_Diagnostic.GetReadDisconnectStateByMetersResult(token);
            Print(resultado, "lectura");
            Console.WriteLine("aqui " + resultado);
        }
        [Queue("get_read_disconnect_state_by_meters_result_masive")]
        public void GetReadDisconnectStateByMetersResultMasive()
        {
            string resultado = "";
            bool si = false;
            CAR_AMI_LIB.Ami_Diagnostic ami_Diagnostic = new CAR_AMI_LIB.Ami_Diagnostic();
            si = ami_Diagnostic.GetReadDisconnectStateByMetersResultMasive();
            Print(resultado, "lectura");
            Console.WriteLine("aqui " + resultado);
        }
        [Queue("read_disconnect_state_by_meters")]
        public void ReadDisconnectStateByMeters(string[] arrKey)
        {
            string resultado = "";
            bool si = false;
            CAR_AMI_LIB.Ami_Diagnostic ami_Diagnostic = new CAR_AMI_LIB.Ami_Diagnostic();
            si = ami_Diagnostic.ReadDisconnectStateByMeters(arrKey);
            Print(resultado, "lectura");
            Console.WriteLine("aqui " + resultado);
        }
        [Queue("read_disconnect_state_by_meters_masive")]
        public void ReadDisconnectStateByMetersMasive()
        {
            string resultado = "";
            bool si = false;
            CAR_AMI_LIB.Ami_Diagnostic ami_Diagnostic = new CAR_AMI_LIB.Ami_Diagnostic();
            si = ami_Diagnostic.ReadDisconnectStateByMetersMasive();
            Print(resultado, "lectura");
            Console.WriteLine("aqui " + resultado);
        }


    }
}
