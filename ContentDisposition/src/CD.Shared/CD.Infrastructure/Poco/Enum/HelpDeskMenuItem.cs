using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CD.Infrastructure.Poco.Enum
{
    [DataContract]
    public enum HelpDeskMenuItem
    {
        [EnumMember]
        HelpDesk,
        [EnumMember]
        IncidentBrowser,
        [EnumMember]
        ScheduledIncident,
        [EnumMember]
        Report,
        [EnumMember]
        Dashboard,
        [EnumMember]
        ChangePassword,
        [EnumMember]
        Logout,
        [EnumMember]
        AboutApplication,
        [EnumMember]
        About,
        [EnumMember]
        PreferenceMenu,
        [EnumMember]
        ApplicationMenu,
        [EnumMember]
        UserInfoMenu,
        [EnumMember]
        SwitcherApplicationMenu,
        [EnumMember]
        ChangeCulture
    }
}
