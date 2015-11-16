using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CD.Infrastructure.Poco
{
    [DataContract]
    [Serializable]
    public class Template
    {
        [DataMember]
        public Int16 TemplateId { get; set; }

        [DataMember]
        public Byte CannedCommand { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string AppName { get; set; }

        [DataMember]
        public string Params { get; set; }

        [DataMember]
        public Byte UseCommandShell { get; set; }

        [DataMember]
        public Int16 TimeoutDurationSecs { get; set; }

        [DataMember]
        public Int16 UserId { get; set; }

        [DataMember]
        public Int16 WaitInterval { get; set; }

        [DataMember]
        public string InvokeCategory { get; set; }

        [DataMember]
        public string CommandResultTestPatternText { get; set; }

        [DataMember]
        public Int16 CommandResultTestPatternType { get; set; }

        [DataMember]
        public Int16 CommandMenuGroupId { get; set; }

        [DataMember]
        public string InvokeItemName { get; set; }

        [DataMember]
        public bool IsOverride { get; set; }

        [DataMember]
        public string TemplatePath { get; set; } 

        [DataMember]
        public string FilePartSize { get; set; } 

    }
}
