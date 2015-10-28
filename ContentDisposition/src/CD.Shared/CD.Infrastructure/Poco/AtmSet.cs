using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using ESQ.Infrastructure.Poco;


namespace CD.Infrastructure.Poco
{
    [DataContract]
    public class AtmSet : BasePoco
    {
        [DataMember]
        public short AtmSetId { get; set; }
        [DataMember]
        public string Sql { get; set; }
        [DataMember]
        public bool Create { get; set; }
        [DataMember]
        public bool Modify { get; set; }
        [DataMember]
        public bool Delete { get; set; }
        [DataMember]
        public IList<Atm> Atms { get; set; }
        [DataMember]
        public bool View { get; set; }
        [DataMember]
        public bool Execute { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public short UserId { get; set; }
    }
}
