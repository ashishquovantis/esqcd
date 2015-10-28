using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CD.Infrastructure.Poco.Enum
{
    [DataContract]
    public enum ResultCodes
    {
        [EnumMember]
        Error,
        [EnumMember]
        Ok,
        [EnumMember]
        ValidationFailed,
        [EnumMember]
        AlreadyClosed
    }
}
