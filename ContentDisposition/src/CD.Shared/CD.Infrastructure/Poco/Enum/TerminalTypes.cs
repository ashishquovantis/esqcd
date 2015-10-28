using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CD.Infrastructure.Poco.Enum
{
    [DataContract]
    public enum TerminalTypes
    {
        [EnumMember]
        FromTerminalSet = 1,
        [EnumMember]
        SpecificTerminal,
        [EnumMember]
        SpecificSite
        //,
        //[EnumMember]
        //PresetTerminal,
        //[EnumMember]
        //CreateFilter

    }
}
