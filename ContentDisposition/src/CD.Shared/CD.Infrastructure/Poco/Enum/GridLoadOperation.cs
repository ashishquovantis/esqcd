using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CD.Infrastructure.Poco.Enum
{
    [DataContract]
    public enum GridLoadOperation
    {
        [EnumMember]
        InitialLoad = 1,
        [EnumMember]
        NormalLoad = 2
    }
}
