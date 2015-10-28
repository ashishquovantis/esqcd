using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CD.Infrastructure.Poco.Enum
{
    [DataContract]
    public enum AssetType
    {
        [EnumMember]
        Terminal = 0,
         [EnumMember]
        Site = 1
    }
}
