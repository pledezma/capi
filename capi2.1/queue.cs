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
        public bool ba = false;
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
        public void ReconnectMeterMasive(string key)
        {
            bool si = false;
            Ami_Control ami_Control = new CAR_AMI_LIB.Ami_Control();
            si = ami_Control.ReconnectMeterMasive(key);//ReconnectMeterMasive(key);

            Console.WriteLine("aqui ");

        }
        [Queue("disconnect_meter_masive")]
        public void DisconnectMeterMasive(string key)
        {
            bool si = false;
            CAR_AMI_LIB.Ami_Control ami_Control = new CAR_AMI_LIB.Ami_Control();
            si = ami_Control.DisconnectMeterMasive(key);

            Console.WriteLine("aqui ");

        }
        [Queue("print")]
        public void Print(string key)
        {
            bool si = false;
            CAR_AMI_LIB.Print print = new CAR_AMI_LIB.Print();
            si = print.print(key); 
            Console.WriteLine("aqui "); 
        }
        

    }
}
