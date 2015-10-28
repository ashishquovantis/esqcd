using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using ESQ.Infrastructure.Poco;
using ESQ.CrossCutting.Instrumentation.Logging;


namespace CD.Infrastructure.Poco
{
    [DataContract]
    [Serializable]
    [HasSelfLog]
    public class ActionItem : BasePoco
    {
        [DataMember]
        public string Action { get; set; }
        [DataMember]
        public string ActionType { get; set; }
    }
}
