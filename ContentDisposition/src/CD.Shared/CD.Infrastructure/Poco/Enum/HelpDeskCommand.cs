using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CD.Infrastructure.Poco.Enum
{
    [DataContract]
    public enum HelpDeskCommand
    {
        [EnumMember]
        View,
        [EnumMember]
        Create,
        [EnumMember]
        Assign,
        [EnumMember]
        AssignToMe,
        [EnumMember]
        AssignGroup,
        [EnumMember]
        Categorize,
        [EnumMember]
        LinkIncident,
        [EnumMember]
        SwitchFault,
        [EnumMember]
        Prioritize,
        [EnumMember]
        Adjust,
        [EnumMember]
        AddNote,
        [EnumMember]
        BulkEdit,
        [EnumMember]
        Authorize,
        [EnumMember]
        EarlyMaintenance,
        [EnumMember]
        Edit,
        [EnumMember]
        Delete,
        [EnumMember]
        CancelIncident,
        [EnumMember]
        Execute,
        [EnumMember]
        TerminalCommands,
        [EnumMember]
        AuthorizedView,
        [EnumMember]
        ETA,
        [EnumMember]
        ATA,
        [EnumMember]
        ChangeExternalTicketInfo,
        [EnumMember]
        ViewAssignTab,
	 	[EnumMember]
		ExternalTicket
        
    }
}
