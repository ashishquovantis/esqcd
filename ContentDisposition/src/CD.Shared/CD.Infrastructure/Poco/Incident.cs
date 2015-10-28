using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using ESQ.CrossCutting.Instrumentation.Logging;
using CD.Infrastructure.Util;

namespace CD.Infrastructure.Poco
{
    [DataContract]
    [Serializable]
    [HasSelfLog]
    public partial class Incident
    {
        //private string assignedPartyRole = String.Empty;
        //private string assignedParty = string.Empty;
        //private string createDate = string.Empty;

        //private Dictionary<string, object> _additionalInformationDict;
        //private Dictionary<string, object> _incidentFormulaColumns;
        //public Incident()
        //{
        //    _incidentFormulaColumns = new Dictionary<string, object>();
        //}

        //[DataMember]
        //private List<Activity> activities = new List<Activity>();

        //[DataMember]
        //private Dictionary<string, object> customAtmData = new Dictionary<string, object>();

        //[DataMember]
        //private string statusCode = "01";

        //[DataMember]
        //private string subStatusCode = "01";

        //[DataMember]
        //private short incidentType = 1;

        //[DataMember]
        //public string Type { get; set; }

        //[DataMember]
        //private DateTime updateTime = DateTime.UtcNow;

        //[DataMember]
        //[ToLogProperty]
        //public long IncidentId { get; set; }

        //[DataMember]
        //public long? OldIncidentId { get; set; }

        //[DataMember]
        //public short IsLinked { get; set; }

        //[DataMember]
        //public short IncidentType
        //{
        //    get { return incidentType; }
        //    set { incidentType = value; }
        //}

        //[DataMember]
        //public int SourceProblemId { get; set; }

        //[DataMember]
        //[ToLogProperty(LogPropertyName = "Problem")]
        //public string SourceProblemName { get; set; }

        //[DataMember]
        //public long? SourceSubProblemId { get; set; }

        //[DataMember]
        //public long? ObjectKey { get; set; }

        //[DataMember]
        //public int ObjectType { get; set; }

        //[DataMember]
        //[ToLogProperty(LogPropertyName = "Asset")]
        //public string ObjectId { get; set; }

        //[DataMember]
        //public string ObjectOwner { get; set; }
        
        //[DataMember]
        //public string ObjectAdditionalInfo { get; set; }

        //[DataMember]
        //public string StatusCode
        //{
        //    get { return statusCode; }
        //    set { statusCode = value; }
        //}

        //[DataMember]
        //public string SubStatusCode
        //{
        //    get { return subStatusCode; }
        //    set { subStatusCode = value; }
        //}
        //[DataMember]
        //public string Summary { get; set; }

        //[DataMember]
        //public string Description { get; set; }

        //[DataMember]
        //public DateTime CreateTime { get; set; }

        //[DataMember]
        //public DateTime CreateTimeUTC { get; set; }

        //[DataMember]
        //public string CreateDate
        //{
        //    get
        //    {
        //        createDate = CreateTime.Date.ToShortDateString();
        //        return createDate;
        //    }
        //    set
        //    {
        //        createDate = value;
        //    }
        //}

        //[DataMember]
        //public DateTime UpdateTime
        //{
        //    get { return updateTime; }
        //    set { updateTime = value; }
        //}

        //[DataMember]
        //public DateTime? CloseTime { get; set; }

        //[DataMember]
        //public DateTime? AckTime { get; set; }

        //[DataMember]
        //public DateTime RecordTime { get; set; }

        //[DataMember]
        //public short CreatedBy { get; set; }

        //[DataMember]
        //public string CreatedByGroupName { get; set; }

        //[DataMember]
        //public string Created { get; set; }

        //[DataMember]
        //public string LastUpdatedBy { get; set; }

        //[DataMember]
        //public short LastUpdatedById { get; set; }

        //[DataMember]
        //public short? AckedBy { get; set; }

        //[DataMember]
        //public string ClosedBy { get; set; }

        //[DataMember]
        //public short? AssignedUserId { get; set; }

        //[DataMember]
        //public DateTime? EstimatedTime { get; set; }

        //[DataMember]
        //public string AdditionalInformation { get; set; }

        //[DataMember]
        //[ToLogProperty]
        //public short Priority { get; set; }

        //[DataMember]
        //public string PriorityText { get; set; }

        //[DataMember]
        //public string AssetType { get; set; }

        //[DataMember]
        //public string AssignedParty
        //{
        //    get { return assignedParty; }
        //    set { assignedParty = value; }
        //}

        //[DataMember]
        //public string Category { get; set; }

        //[DataMember]
        //public string SubCategory { get; set; }

        //[DataMember]
        //public string AssignedUser { get; set; }

        //[DataMember]
        //public string Remarks { get; set; }

        //[DataMember]
        //public string RemarksHtml { get; set; }

        //[DataMember]
        //public string ExternalTicketStatus { get; set; }

        //[DataMember]
        //public string ExternalTicketSubStatus { get; set; }

        //[DataMember]
        //public string ExternalTicketId { get; set; }

        //[DataMember]
        //public string ExternalTicketDetails { get; set; }

        //[DataMember]
        //public int IncidentStatusFlagValue { get; set; }

        //[DataMember]
        //public long ParentIncidentId { get; set; }

        //[DataMember]
        //public string Age
        //{
        //    get
        //    {
        //        return IncidentAge;
        //    }
        //    set
        //    {

        //    }
        //}

        //[DataMember]
        //public string IncidentAge
        //{
        //    get
        //    {
        //        string incidentAge = "";
        //        Int64 seconds = IncidentAgeSeconds;
        //        string days = "";
        //        days = Math.Floor(Convert.ToDouble(seconds / 86400)).ToString().PadLeft(2, '0');
        //        seconds = seconds % 86400;
        //        string hours = "";
        //        hours = Math.Floor(Convert.ToDouble(seconds / 3600)).ToString().PadLeft(2, '0');
        //        seconds = seconds % 3600;
        //        string minutes = "";
        //        minutes = Math.Ceiling(Convert.ToDouble(seconds / 60)).ToString().PadLeft(2, '0');
        //        switch (Config.IncidentAgeFormat)
        //        {
        //            case "1":
        //                incidentAge = string.Format("{0}:{1}:{2}", days, hours, minutes);
        //                break;
        //            case "2":
        //                incidentAge = string.Format("{0}d {1}h {2}m", days, hours, minutes);
        //                break;
        //            case "3":
        //                incidentAge = string.Format("{0}day{3} {1}hour{4} {2}minute{5}", days, hours, minutes, (Convert.ToInt32(days) > 0 ? "s" : ""), (Convert.ToInt32(days) > 0 ? "s" : ""), (Convert.ToInt32(minutes) > 0 ? "s" : ""));
        //                break;
        //        }

        //        return incidentAge;
        //    }
        //    set
        //    {
        //    }
        //}

        //[DataMember]
        //public Int64 IncidentAgeSeconds
        //{
        //    get
        //    {
        //        if (StatusCode == "05" || StatusCode == "02")
        //        {
        //            if (LastResolvedDate != null)
        //                return Convert.ToInt64(Math.Ceiling(((DateTime)LastResolvedDate - CreateTime).TotalSeconds));
        //            else
        //                if (CloseTime != null)
        //                    return Convert.ToInt64(Math.Ceiling(((DateTime)CloseTime - CreateTime).TotalSeconds));
        //                else
        //                    return Convert.ToInt64(Math.Ceiling((DateTime.UtcNow - CreateTimeUTC).TotalSeconds));
        //        }
        //        if (CloseTime != null)
        //        {
        //            return Convert.ToInt64(Math.Ceiling(((DateTime)CloseTime - CreateTime).TotalSeconds));
        //        }
        //        else
        //        {
        //            return Convert.ToInt64(Math.Ceiling((DateTime.UtcNow - CreateTimeUTC).TotalSeconds));
        //        }
        //    }
        //    set
        //    {
        //    }
        //}


        //[DataMember]
        //public string AssignedPartyRole
        //{
        //    get { return assignedPartyRole; }
        //    set { assignedPartyRole = value; }
        //}

        //[DataMember]
        //public int AssignedPartyId { get; set; }

        //[DataMember]
        //public string Reporter { get; set; }

        //[DataMember]
        //public string Status { get; set; }

        //[DataMember]
        //public string SubStatus { get; set; }

        //[DataMember]
        //public long SwitchToFaultId { get; set; }

        //[DataMember]
        //public long ParentFaultId { get; set; }

        //[DataMember]
        //public short FromProblemId { get; set; }

        //[DataMember]
        //public DateTime ParentFaultTime { get; set; }

        //[DataMember]
        //public DateTime SwitchFaultTime { get; set; }

        //[DataMember]
        //public bool SwitchTimeInLocal { get; set; }

        //[DataMember]
        //public string LastEscalation { get; set; }

        //[DataMember]
        //public string ReferenceId { get; set; }

        //[DataMember]
        //public string OriginalAssignedParty { get; set; }

        //[DataMember]
        //public string TargetApps { get; set; }
        
        //[DataMember]
        //public Dictionary<string, object> CustomAtmData
        //{
        //    get { return customAtmData; }
        //    set { customAtmData = value; }
        //}

        //[DataMember]
        //public List<Activity> Activities
        //{
        //    get { return activities; }
        //    set { activities = value; }
        //}

        //[DataMember]
        //public byte[] AtmBitmap { get; set; }

        //[DataMember]
        //public UserProfile CurrentUserProfile { get; set; }

        //[DataMember]
        //public DateTime? LastUserActivity { get; set; }

        //[DataMember]
        //public DateTime? LastResolvedDate { get; set; }

        //[DataMember]
        //public short PolicyKind { get; set; }

        //[DataMember]
        //private List<SpareParts> sparePartsIncidents = new List<SpareParts>();
        
        //[DataMember]
        //public List<SpareParts> SparePartsIncidents
        //{
        //    get { return sparePartsIncidents; }
        //    set { sparePartsIncidents = value; }
        //}

        //[DataMember]
        //public DateTime? ActualTime { get; set; }

        //[DataMember]
        //public string ThirdPartyTicketStatus { get; set; }

        //[DataMember]
        //public string ThirdPartyTicketSubStatus { get; set; }

        //[DataMember]
        //public string ThirdPartyTicketId { get; set; }

        //[DataMember]
        //public string ThirdPartyTicketDetails { get; set; }

        //[DataMember]
        //public Dictionary<string, object> IncidentFormulaColumns
        //{
        //    get
        //    {
        //        return _incidentFormulaColumns;
        //    }
        //    set
        //    {
        //        _incidentFormulaColumns = value;
        //    }
        //}

        //[DataMember]
        //public long IncidentFlag { get; set; }
        //[DataMember]
        //public Dictionary<string, object> AdditionalInformationDict
        //{
        //    get { return _additionalInformationDict; }
        //    set { _additionalInformationDict = value; }
        //}
    }
}
