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
    public class Terminal
    {
        [DataMember]
        public Int16 AtmSetId { get; set; }

        [DataMember]
        public string Name { get; set; }

        //[DataMember]
        //public string Description { get; set; }

        //[DataMember]
        //public string QueryBlob { get; set; }

        //[DataMember]
        //public string TermIds { get; set; }

        [DataMember]
        public string SQL { get; set; }

        //[DataMember]
        //public Int64 UserId { get; set; }
    }
}
