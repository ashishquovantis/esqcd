using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CD.Infrastructure.Poco.Enum
{
    [DataContract]
    public enum HelpDeskTarget
    {
        
        [EnumMember]
        Incident,

        [EnumMember]
        IncidentBrowser,
        
        [EnumMember]
        Activity,
        
        [EnumMember]
        Command,
        
        [EnumMember]
        User,
        
        [EnumMember]
        UserGroup,
        
        [EnumMember]
        State,

        [EnumMember]
        SubState,

        [EnumMember]
        Filter,

        [EnumMember]
        PreferenceItem,

        [EnumMember]
        IncidentDetails,

        [EnumMember]
        Category,

        [EnumMember]
        SubCategory,

        [EnumMember]
        SwitchApplicationItem,

        [EnumMember]
        CommandAction,

        [EnumMember]
        Screen,

        [EnumMember]
        ScheduledIncident,

        [EnumMember]
        GridColumn,

        [EnumMember]
        ActionItem,

        [EnumMember]
        ModuleName,

        [EnumMember]
        IncidentFilterType,

        [EnumMember]
        BreakFix

    }

    public enum PermObject
    {
        Actions = 12
    }
}
