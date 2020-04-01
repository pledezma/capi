using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace capi2_1
{
    public enum Queues
    {
        
        [EnumMember]
        ReconnectMeter,
        [EnumMember]
        DisconnectMeter,
        [EnumMember]
        ReconnectMeterMasive,
        [EnumMember]
        DisconnectMeterMasive,
        [EnumMember]
        InteractiveReadByEndpointRequest,
        [EnumMember]
        InteractiveReadByEndpointResult,
        [EnumMember]
        Print 
    }
}
