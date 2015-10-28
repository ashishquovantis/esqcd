using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CD.Infrastructure.Poco;
using CD.Infrastructure.Poco.Enum;
using System.Collections;
using CD.Business.Logic.CD;

namespace CD.Service
{
    public partial class CDService
    {
        //public List<Incident> AuthorizeIncidents(byte[] userBitmap, List<Incident> incidents)
        //{
        //    return helpDeskManager.AuthorizeIncidents(userBitmap, incidents);
        //}

        public byte[] CreateDefaultPermissionKey()
        {
            return cdManager.CreateDefaultPermissionKey();
        }

        //public byte[] CreatePermissionKey(short userId)
        //{
        //    return helpDeskManager.CreatePermissionKey(userId);
        //}

        public byte[] CreatePermissionKey(List<AtmSet> atmSets)
        {
            return cdManager.CreatePermissionKey(atmSets);
        }

        public byte[] CreateZeroPermissionKey()
        {
            return cdManager.CreateZeroPermissionKey();
        }

        //public object Filter(UserProfile user, HelpDeskTarget target, string command, IList source)
        //{
        //    return helpDeskManager.Filter(user, target, command, source);
        //}

        //public byte[] GetPermissionKey(long atmId)
        //{
        //    return helpDeskManager.GetPermissionKey(atmId);
        //}

        public byte[] GetTerminalSetBitmapForAtm(long? atmId)
        {
            return cdManager.GetTerminalSetBitmapForAtm(atmId);
        }

        //public List<AtmSet> GetUserAssignedTerminalSet(UserProfile user)
        //{
        //    return helpDeskManager.GetUserAssignedTerminalSet(user);
        //}

        //public bool IsActionAllowed(UserProfile user, HelpDeskTarget target, string command, string action)
        //{
        //    return helpDeskManager.IsActionAllowed(user, target, command, action);
        //}

        //public IList<string> IsActionAllowedOnEntities(UserProfile user, HelpDeskTarget target, IList entities)
        //{
        //    return helpDeskManager.IsActionAllowedOnEntities(user, target, entities);
        //}

        //public bool IsActionAllowedOnEntity(UserProfile user, HelpDeskTarget target, string command, IList source)
        //{
        //    return helpDeskManager.IsActionAllowedOnEntity(user, target, command, source);
        //}

        //public bool IsActionAllowedOnEntity(UserProfile user, HelpDeskTarget target, string command)
        //{
        //    return helpDeskManager.IsActionAllowedOnEntity(user, target, command);
        //}

        //public List<string> IsActionsAllowedOnEntity(UserProfile user, HelpDeskTarget target, List<string> actions, IList source)
        //{
        //    return helpDeskManager.IsActionsAllowedOnEntity(user, target, actions, source);
        //}

        //public bool IsTransitionAllowed(UserProfile user, string command, IList source)
        //{
        //    return helpDeskManager.IsTransitionAllowed(user, command, source);
        //}

        //public bool IsTransitionAllowed(UserProfile user, string command)
        //{
        //    return helpDeskManager.IsTransitionAllowed(user, command);
        //}

        //public List<string> IsTransitionsAllowed(UserProfile user, List<string> transitions, IList source)
        //{
        //    return helpDeskManager.IsTransitionsAllowed(user, transitions, source);
        //}

        //public void ValidateTerminalSetData()
        //{
        //     helpDeskManager.ValidateTerminalSetData();
        //}

        //public List<Incident> AuthorizeAndFilter(UserProfile user, HelpDeskTarget target, string command, List<Incident> incidents)
        //{
        //    return helpDeskManager.AuthorizeAndFilter(user, target, command, incidents);
        //}

        //public void RefreshRbacData(UserProfile user)
        //{
        //    helpDeskManager.RefreshRbacData(user);
        //}

        //public bool IsAuthServiceinReadyState()
        //{
        //    return true;
        //}

    }
}
