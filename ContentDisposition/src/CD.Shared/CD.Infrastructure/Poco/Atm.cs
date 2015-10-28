using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using ESQ.Infrastructure.Poco;

namespace CD.Infrastructure.Poco
{
    [DataContract]
    public class Atm : BasePoco
    {
        [DataMember]
        public long AtmId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Value { get; set; }
        [DataMember]
        public short AtmSetId { get; set; }
    }
}
