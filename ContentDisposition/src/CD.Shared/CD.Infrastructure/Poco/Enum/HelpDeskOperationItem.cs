using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CD.Infrastructure.Poco.Enum
{
    [DataContract]
    public enum HelpDeskOperationItem
    {
        [EnumMember]
        BulkEdit,
        [EnumMember]
        BulkChangeStatus,
        [EnumMember]
        BulkCloseIncident,
        [EnumMember]
        BulkAddNote,
        [EnumMember]
        BulkPrioritize,
        [EnumMember]
        BulkAssign,
        [EnumMember]
        BulkAssignGroup
    }
}
