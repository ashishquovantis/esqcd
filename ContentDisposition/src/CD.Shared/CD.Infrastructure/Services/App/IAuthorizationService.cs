using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using CD.Infrastructure.Poco;
using CD.Infrastructure.Poco.Enum;
using ESQ.Infrastructure.Preferences;

namespace CD.Infrastructure.Services.App
{
    [ServiceContract]
    public interface IAuthorizationService
    {
        //#region Terminal Set

        //[OperationContract]
        //void ValidateTerminalSetData();

        //[OperationContract]
        //[ServiceKnownType(typeof(Incident))]
        //List<Incident> AuthorizeIncidents(byte[] userBitmap, List<Incident> incidents);

        [OperationContract]
        byte[] CreateDefaultPermissionKey();

        [OperationContract]
        byte[] CreateZeroPermissionKey();

        [OperationContract]
        byte[] CreatePermissionKey(List<AtmSet> atmSets);

        //[OperationContract]
        //byte[] GetPermissionKey(Int64 atmId);

        //[OperationContract]
        //List<AtmSet> GetUserAssignedTerminalSet(UserProfile user);

        [OperationContract]
        byte[] GetTerminalSetBitmapForAtm(long? atmId);

        //[OperationContract(Name = "CreatePermissionKeyForUser")]
        //byte[] CreatePermissionKey(short userId);

        //#endregion Terminal Set

        //#region Rbac

        //[OperationContract]
        //bool IsActionAllowedOnEntity(UserProfile user, HelpDeskTarget target, string command);

        //[OperationContract]
        //IList<string> IsActionAllowedOnEntities(UserProfile user, HelpDeskTarget target, IList entities);

        //[OperationContract(Name = "IsActionAllowedOnEntityWithSource")]
        //[ServiceKnownType(typeof(Incident))]
        //[ServiceKnownType(typeof(Activity))]
        //bool IsActionAllowedOnEntity(UserProfile user, HelpDeskTarget target, string command, IList source);

        //[OperationContract(Name = "IsActionsAllowedOnEntityWithSource")]
        //[ServiceKnownType(typeof(Incident))]
        //[ServiceKnownType(typeof(Activity))]
        //List<string> IsActionsAllowedOnEntity(UserProfile user, HelpDeskTarget target, List<string> actions, IList source);

        //[OperationContract]
        //bool IsActionAllowed(UserProfile user, HelpDeskTarget target, string command, string action);

        //[OperationContract]
        //bool IsTransitionAllowed(UserProfile user, string command);

        //[OperationContract(Name = "IsTransitionAllowedWithSource")]
        //[ServiceKnownType(typeof(Incident))]
        //bool IsTransitionAllowed(UserProfile user, string command, IList source);

        //[OperationContract]
        //[ServiceKnownType(typeof(Incident))]
        //List<string> IsTransitionsAllowed(UserProfile user, List<string> transitions, IList source);

        //[OperationContract]
        //[ServiceKnownType(typeof(List<UserDef>))]
        //[ServiceKnownType(typeof(List<Substatus>))]
        //[ServiceKnownType(typeof(List<GroupDef>))]
        //[ServiceKnownType(typeof(List<LeftSideConfigurationItem>))]
        //[ServiceKnownType(typeof(List<PreferenceMenuItem>))]
        //[ServiceKnownType(typeof(List<Incident>))]
        //[ServiceKnownType(typeof(List<ActionItem>))]
        //[ServiceKnownType(typeof(List<GridColumn>))]
        //[ServiceKnownType(typeof(List<IncidentFilterType>))]
        //[ServiceKnownType(typeof(List<CategorySubCategory>))]
        //[ServiceKnownType(typeof(List<SubstatusEx>))]
        //[ServiceKnownType(typeof(UserDef))]
        //[ServiceKnownType(typeof(Substatus))]
        //[ServiceKnownType(typeof(GroupDef))]
        //[ServiceKnownType(typeof(LeftSideConfigurationItem))]
        //[ServiceKnownType(typeof(PreferenceMenuItem))]
        //[ServiceKnownType(typeof(Incident))]
        //[ServiceKnownType(typeof(ActionItem))]
        //[ServiceKnownType(typeof(GridColumn))]
        //[ServiceKnownType(typeof(IncidentFilterType))]
        //[ServiceKnownType(typeof(CategorySubCategory))]
        //[ServiceKnownType(typeof(SubstatusEx))]

        ////IList Filter(UserProfile user, HelpDeskTarget target, string command, IList source);
        //object Filter(UserProfile user, HelpDeskTarget target, string command, IList source);

        //#endregion Rbac

        //[OperationContract]
        //List<Incident> AuthorizeAndFilter(UserProfile user, HelpDeskTarget target, string command, List<Incident> incidents);

        //[OperationContract]
        //void RefreshRbacData(UserProfile user);

        //[OperationContract]
        //bool IsAuthServiceinReadyState();
    }
}
