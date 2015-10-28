using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CD.Infrastructure.Poco.Enum
{
    [DataContract]
    public enum GridCustomOperation
    {
        [EnumMember]
        ApplyProcessing = 1,
        [EnumMember]
        PreventProcessing = 2
    }
}
