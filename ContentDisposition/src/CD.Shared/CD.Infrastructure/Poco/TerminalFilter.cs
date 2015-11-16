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
    public class FilterDefs
    {
        [DataMember]
        public Int32 FilterId { get; set; }

        [DataMember]
        public string FilterName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string SQL { get; set; }

        [DataMember]
        public string FilterExpression { get; set; }

        [DataMember]
        public DateTime CreatedOn { get; set; }

        [DataMember]
        public Int16 CreatedBy { get; set; }

        [DataMember]
        public byte VisibleToOthers { get; set; }

        [DataMember]
        public Int32 ShownOnModules { get; set; }

        public int? IsAdmin { get; set; }

    }
}
