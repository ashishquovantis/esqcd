using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using ESQ.CrossCutting.Instrumentation.Logging;
using ESQ.Infrastructure.Poco;
using ESQ.Infrastructure.Preferences;
using CD.Infrastructure.Poco.Enum;


namespace CD.Infrastructure.Poco
{
    [DataContract]
    [Serializable]
    [HasSelfLog]
    public class UserProfile : BasePoco
    {
        [DataMember]
        [ToLogProperty]
        public short UserId { get; set; }

        [DataMember]
        public short GroupId { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        [ToLogProperty]
        public string UserName { get; set; }

        [DataMember]
        public bool IsAdmin { get; set; }

        [DataMember]
        public DateTime LastLogin { get; set; }

        [DataMember]
        public DateTime CurrenLogintTime { get; set; }

        [DataMember]
        public string GroupName { get; set; }

        [DataMember]
        public string GroupRole { get; set; }

        [DataMember]
        public byte[] PermissionKey { get; set; }

        [DataMember]
        public IList<AtmSet> AssignedAtmSet { get; set; }

        [DataMember]
        public UserPreference Preference { get; set; }

        [DataMember]
        public string XmlPreference { get; set; }

        [DataMember]
        public UserAuthenticationMode AuthenticationMode { get; set; }

        [DataMember]
        public bool IsAutoLoggedIn { get; set; }

        [DataMember]
        public string GUID { get; set; }

        [DataMember]
        public string Theme { get; set; }

        [DataMember]
        public long CultureId { get; set; }

        [DataMember]
        public string AssignParty { get; set; }

        [DataMember]
        public IList<ActionItem> ActionItemList { get; set; }

        [DataMember]
        public List<int> TabPermRefIds { get; set; }
    }

}

