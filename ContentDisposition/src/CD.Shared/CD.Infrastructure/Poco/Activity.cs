using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using ESQ.CrossCutting.Instrumentation.Logging;

namespace HelpDesk.Infrastructure.Poco
{
    [DataContract]
    [Serializable]
    [HasSelfLog]
    public partial class Activity
    {
        [DataMember]
        private List<Attachment> attachments = new List<Attachment>();

        [DataMember]
        public long ActivityId { get; set; }

        [DataMember]
        [ToLogProperty]
        public long IncidentId { get; set; }

        [DataMember]
        public short ActivityType { get; set; }

        [DataMember]
        public int TargetPartyId { get; set; }

        [DataMember]
        public string DispatcherRefId { get; set; }

        [DataMember]
        public DateTime RecordTime { get; set; }

        [DataMember]
        public DateTime StartTime { get; set; }

        [DataMember]
        public DateTime? EndTime { get; set; }

        //[DataMember]
        //public short Priority { get; set; }
        [DataMember]
        public DateTime? EstimatedTime { get; set; }

        [DataMember]
        public DateTime? ActualTime { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        [ToLogProperty]
        public string Remarks { get; set; }

        [DataMember]
        [ToLogProperty]
        public string CategoryCode { get; set; }

        [DataMember]
        [ToLogProperty]
        public string SubCategoryCode { get; set; }

        [DataMember]
       
        public string Category { get; set; }

        [DataMember]
        
        public string SubCategory { get; set; }

        [DataMember]
        public short CreatedBy { get; set; }

        [DataMember]
        public short? UpdatedBy { get; set; }

        [DataMember]
        public string Target { get; set; }

        [DataMember]
        public string Tag { get; set; }

        [DataMember]
        public string Response { get; set; }

        [DataMember]
        public short? Retries { get; set; }

        [DataMember]
        public string AdditionalInfo { get; set; }

       [DataMember]
        public string CreatedByUser { get; set; }

        [DataMember]
        public string AssignedParty { get; set; }

        [DataMember]
        public string AssignedUser { get; set; }

        [DataMember]
        public string ToStatus { get; set; }

        [DataMember]
        public string ToSubStatus { get; set; }

        [DataMember]
        public string FromStatus { get; set; }

        [DataMember]
        public string FromSubStatus { get; set; }

        [DataMember]
        public string IncidentToStatus { get; set; }

        [DataMember]
        public string IncidentToSubStatus { get; set; }

        [DataMember]
        public string IncidentFromStatus { get; set; }

        [DataMember]
        public string IncidentFromSubStatus { get; set; }

        [DataMember]
        public string Result { get; set; }

        [DataMember]
        public string ResultText { get; set; }

        [DataMember]
        public string ExternalCategory { get; set; }

        [DataMember]
        public string ExternalSubCategory { get; set; }

        [DataMember]
        public long AssignedPartyId { get; set; }
        
        [DataMember]
        public short AssignedUserId { get; set; }

        [DataMember]
        public string Reporter { get; set; }
        
        [DataMember]
        public short IsIncidentLinked { get; set; }

        [DataMember]
        public List<Attachment> Attachments
        {
            get { return attachments; }
            set { attachments = value; }
        }

        [DataMember]
        public DateTime ActivityTime
        {
            get { return StartTime; }
            set { StartTime = value; }
        }
    }
}
