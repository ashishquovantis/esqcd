using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CD.Infrastructure.Poco.Enum
{
    [DataContract]
    public enum HelpDeskCommandActionItem
    {
        [EnumMember]
        AdjustGridEdit,
        [EnumMember]
        AdjustGridDelete,
        [EnumMember]
        IBBulkImport,
        [EnumMember]
        IBBulkExport,
        [EnumMember]
        SIBulkImport,
        [EnumMember]
        SIBulkExport,
        [EnumMember]
        SIAdd,
        [EnumMember]
        SIEdit,
        [EnumMember]
        SIDelete
    }
}
