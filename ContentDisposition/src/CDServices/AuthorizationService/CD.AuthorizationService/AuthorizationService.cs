using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESQ.CrossCutting.Instrumentation;
using CD.Infrastructure.Poco;
using CD.Infrastructure.Poco.Enum;
using CD.Infrastructure.Services.App;
using CD.Rbac.Security;
using CD.TerminalSet.Security;
using ESQ.Infrastructure.Services.App;

namespace CD.AuthorizationService
{
    [ExceptionAspect(AttributePriority = 2)]
    public class AuthorizationService : IAuthorizationService
    {
        private TerminalSetPermissionManager terminalSetPermissionManager;

        public AuthorizationService()
            : this(TerminalSetPermissionManager.Instance) { }

        public AuthorizationService(TerminalSetPermissionManager terminalSetPermissionManager)
        {
            this.terminalSetPermissionManager = terminalSetPermissionManager;
        }

        //#region Terminal set authorization

        //public void ValidateTerminalSetData()
        //{
        //    terminalSetPermissionManager.ValidateTerminalSetData();
        //}

        //public List<Incident> AuthorizeIncidents(byte[] userBitmap, List<Incident> incidents)
        //{
        //    var enIncidents = terminalSetPermissionManager.AuthorizeIncidents(userBitmap, incidents);
        //    if (enIncidents != null)
        //        return enIncidents.ToList();

        //    return new List<Incident>();
        //}

        //public List<Incident> AuthorizeAndFilter(UserProfile user, HelpDeskTarget target, string command, List<Incident> incidents)
        //{
        //    var authIncidents = terminalSetPermissionManager.AuthorizeIncidents(user.PermissionKey, incidents).ToList();
        //    var securityContext = new SecurityContext(user);
        //    var filteredIncidents = securityContext.FilterByType<Incident>(target, command, authIncidents);
        //    return filteredIncidents;
        //}

        public byte[] CreateDefaultPermissionKey()
        {
            return null;
            //return terminalSetPermissionManager.CreateDefaultPermissionKey();
        }

        public byte[] CreateZeroPermissionKey()
        {
            return null;
            //return terminalSetPermissionManager.CreateZeroPermissionKey();
        }

        public byte[] CreatePermissionKey(List<AtmSet> atmSets)
        {
            return null;
            //return terminalSetPermissionManager.CreatePermissionKey(atmSets);
        }

        public byte[] CreatePermissionKey(short userId)
        {
            return null;
            //return terminalSetPermissionManager.CreatePermissionKey(userId);
        }

        public byte[] GetPermissionKey(long atmId)
        {
            return null;
            //return terminalSetPermissionManager.GetPermissionKey(atmId);
        }

        public List<AtmSet> GetUserAssignedTerminalSet(UserProfile user)
        {
            return null;
            //return terminalSetPermissionManager.GetUserAssignedTerminalSet(user);
        }

        public byte[] GetTerminalSetBitmapForAtm(long? atmId)
        {
            return null;
            //return terminalSetPermissionManager.GetAtmBitmap(atmId);
        }

        //#endregion Terminal set authorization


        //#region RBAC

        //public bool IsActionAllowedOnEntity(UserProfile user, HelpDeskTarget target, string command)
        //{
        //    return new SecurityContext(user).IsActionAllowedOnEntity(target, command);
        //}

        //public IList<string> IsActionAllowedOnEntities(UserProfile user, HelpDeskTarget target, IList entities)
        //{
        //    var allowedEntitites = new List<string>();

        //    var securityContext = new SecurityContext(user);
        //    var genericMethodInfo = typeof(SecurityContext)
        //        .GetMethods()
        //        .Where(m => m.IsGenericMethod && m.Name == "IsActionAllowedOnEntity")
        //        .First(m => m.ContainsGenericParameters)
        //        .MakeGenericMethod(entities[0].GetType());

        //    foreach (var entity in entities)
        //    {
        //        if ((bool)genericMethodInfo.Invoke(securityContext, new[] { target, entity, entities }))
        //        {
        //            allowedEntitites.Add(entity.ToString());
        //        }
        //    }

        //    return allowedEntitites;

        //}

        //public bool IsActionAllowedOnEntity(UserProfile user, HelpDeskTarget target, string command, IList source)
        //{
        //    var securityContext = new SecurityContext(user);

        //    var genericMethodInfo = typeof(SecurityContext)
        //        .GetMethods()
        //        .Where(m => m.IsGenericMethod && m.Name == "IsActionAllowedOnEntity")
        //        .First(m => m.ContainsGenericParameters)
        //        .MakeGenericMethod(source[0].GetType());

        //    return (bool)genericMethodInfo.Invoke(securityContext, new object[] { target, command, source });
        //}

        //public bool IsActionAllowed(UserProfile user, HelpDeskTarget target, string command, string source)
        //{
        //    var securityContext = new SecurityContext(user);

        //    var genericMethodInfo = typeof(SecurityContext)
        //        .GetMethods()
        //        .Where(m => m.IsGenericMethod && m.Name == "IsActionAllowed")
        //        .First(m => m.ContainsGenericParameters)
        //        .MakeGenericMethod(source[0].GetType());

        //    return (bool)genericMethodInfo.Invoke(securityContext, new object[] { target, command, source });
        //}

        //public List<string> IsActionsAllowedOnEntity(UserProfile user, HelpDeskTarget target, List<string> actions, IList source)
        //{
        //    var allowedCommands = new List<string>();

        //    foreach (var action in actions)
        //    {
        //        var securityContext = new SecurityContext(user);
        //        var genericMethodInfo = typeof(SecurityContext)
        //            .GetMethods()
        //            .Where(m => m.IsGenericMethod && m.Name == "IsActionAllowedOnEntity")
        //            .First(m => m.ContainsGenericParameters)
        //            .MakeGenericMethod(source[0].GetType());

        //        var result = (bool)genericMethodInfo.Invoke(securityContext, new object[] { target, action, source });
        //        if (result)
        //        {
        //            allowedCommands.Add(action);
        //        }
        //    }

        //    return allowedCommands;

        //}

        //public bool IsTransitionAllowed(UserProfile user, string command)
        //{
        //    return new SecurityContext(user).IsTransitionAllowed(command);
        //}

        //public bool IsTransitionAllowed(UserProfile user, string command, IList source)
        //{
        //    var securityContext = new SecurityContext(user);
        //    var genericMethodInfo = typeof(SecurityContext)
        //        .GetMethods()
        //        .Where(m => m.IsGenericMethod && m.Name == "IsTransitionAllowed")
        //        .First(m => m.ContainsGenericParameters)
        //        .MakeGenericMethod(source[0].GetType());

        //    return (bool)genericMethodInfo.Invoke(securityContext, new object[] { command, source });

        //}

        //public List<string> IsTransitionsAllowed(UserProfile user, List<string> transitions, IList source)
        //{
        //    var allowedTransitions = new List<string>();

        //    foreach (var transition in transitions)
        //    {
        //        var securityContext = new SecurityContext(user);
        //        var genericMethodInfo = typeof(SecurityContext)
        //            .GetMethods()
        //            .Where(m => m.IsGenericMethod && m.Name == "IsTransitionAllowed")
        //            .First(m => m.ContainsGenericParameters)
        //            .MakeGenericMethod(source[0].GetType());

        //        var result = (bool)genericMethodInfo.Invoke(securityContext, new object[] { transition, source });
        //        if (result)
        //        {
        //            allowedTransitions.Add(transition);
        //        }
        //    }
        //    return allowedTransitions;

        //}

        //public object Filter(UserProfile user, HelpDeskTarget target, string command, IList source)
        //{
        //    var securityContext = new SecurityContext(user);
        //    var genericMethod = typeof(SecurityContext).GetMethod("Filter");
        //    var genericMethodInfo = genericMethod.MakeGenericMethod(source[0].GetType());

        //    return genericMethodInfo.Invoke(securityContext, new object[] { target, command, source });

        //}

        //public void RefreshRbacData(UserProfile user)
        //{
        //     new SecurityContext(user).RefreshRbacData();
        //}

        //#endregion RBAC

        //public bool IsAuthServiceinReadyState()
        //{
        //    return true;
        //}

    }
}
