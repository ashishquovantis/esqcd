using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CD.Infrastructure.Poco;
using CD.Infrastructure.Poco.Enum;
//using CD.TransitionsWorkflow;
using ESQ.CrossCutting.Instrumentation;


namespace CD.Authorization.Authorization
{
    /// <summary>
    /// Proxy for Authorization service
    /// </summary>
    public class AuthorizationManager
    {
        private static AuthorizationManager instance = new AuthorizationManager();

        static AuthorizationManager() { }

        public static AuthorizationManager Instance
        {
            get { return instance; }
        }

        #region todo

        ///// <summary>
        ///// Method for RBAC authorization of action on specific entity
        ///// </summary>
        ///// <param name="user"></param>
        ///// <param name="target"></param>
        ///// <param name="command"></param>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //public bool IsActionAllowedOnEntity(UserProfile user, HelpDeskTarget target, string command, /*Incident*/dynamic entity/*incident*/)
        //{
        //    var result = false;

        //    if (entity is IEnumerable)
        //    {
        //        var list = Enumerable.ToList(entity);

        //        AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService().ExecuteCommand(s =>
        //        {
        //            result = s.IsActionAllowedOnEntity(user, target, command, list);
        //        });
        //    }
        //    else
        //    {
        //        AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService().ExecuteCommand(s =>
        //        {
        //            result = s.IsActionAllowedOnEntity(user, target, command, new List<dynamic>{entity});
        //        });
                
        //    }

        //    return result;
        //}


        ///// <summary>
        ///// Method for RBAC authorization of action on specific entity
        ///// </summary>
        ///// <param name="user"></param>
        ///// <param name="target"></param>
        ///// <param name="command"></param>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //public bool IsActionAllowed(UserProfile user, HelpDeskTarget target, string command, string action)
        //{
        //    var result = false;

        //    AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService().ExecuteCommand(s =>
        //    {
        //        result = s.IsActionAllowed(user, target, command, action);
        //    });

        //    return result;
        //}

        ///// <summary>
        ///// Method for RBAC authorization of action on list of commands
        ///// </summary>
        ///// <param name="user"></param>
        ///// <param name="target"></param>
        ///// <param name="command"></param>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //public IList<string> IsActionAllowedOnEntities(UserProfile user, HelpDeskTarget target, IList entities)
        //{
        //    IList<string> result = new List<string>();

        //    AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService().ExecuteCommand(s =>
        //        {
        //            result = s.IsActionAllowedOnEntities(user, target, entities);
        //        });

        //    return result;
        //}


        ///// <summary>
        ///// Method which is responsible for filtering collection regarding RBAC target and command
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="user"></param>
        ///// <param name="target"></param>
        ///// <param name="command"></param>
        ///// <param name="list"></param>
        ///// <returns></returns>
        //public IList Filter<T>(UserProfile user, HelpDeskTarget target, string command, List<T> list)
        //{
        //    object authorizedList = null;
        //    if (list.Any())
        //    {
        //        AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService().ExecuteCommand(s =>
        //            {
        //                authorizedList = s.Filter(user, target, command, list);
        //            });
        //    }
        //    return (IList)authorizedList;
        //}


        //public List<Incident> AuthorizeAndFilter(UserProfile user, HelpDeskTarget target, string command, List<Incident> list)
        //{
        //    List<Incident> authorizedList = null;
        //    if (list.Any())
        //    {
        //        AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService().ExecuteCommand(s =>
        //        {
        //            authorizedList = s.AuthorizeAndFilter(user, target, command, list);
        //        });
        //    }
        //    return authorizedList;
        //}

        ///// <summary>
        ///// Method for RBAC and workflow definition authorization of specific transition
        ///// </summary>
        ///// <param name="transition"></param>
        ///// <param name="user"></param>
        ///// <returns></returns>
        //public bool IsTransitionAllowed(Transition transition, UserProfile user)
        //{
        //    return RbacTransionAllowed(user, transition)
        //           && WorkflowTransitionAllowed(transition);
        //}

        //private bool RbacTransionAllowed(UserProfile user, Transition transition)
        //{
        //    var result = false;
        //    var command = transition.FromStatusSubStatus.Item1 + "-" + transition.ToStatusSubStatus.Item1;

        //    AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService().ExecuteCommand(s =>
        //    {
        //        result = s.IsTransitionAllowed(user, command, new List<Incident> { transition.OldIncident });
        //    });

        //    return result;
        //}

        //private bool WorkflowTransitionAllowed(Transition transition)
        //{
        //    //TODO Not finished
        //    transition
        //        = StatusTransitionManager.Instance.IsTransitionAllowed(transition.FromStatusSubStatus, transition.ToStatusSubStatus);

        //    return transition != null;
        //}

        /// <summary>
        /// Return terminal set bitmap for specific user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public byte[] GetTerminalSetBitmap(UserProfile user)
        {
            byte[] bitmap = null;

            if (user.IsAdmin)
            {
                AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService().ExecuteCommand(s =>
                {
                    bitmap = s.CreateDefaultPermissionKey();
                });
            }
            else
            {
                if (user.AssignedAtmSet != null)
                {
                    AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService()
                                                     .ExecuteCommand(s =>
                                                     {
                                                         bitmap = s.CreatePermissionKey(user.AssignedAtmSet.ToList());
                                                     });
                }
                else
                {
                    AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService().ExecuteCommand(s =>
                    {
                        bitmap = s.CreateZeroPermissionKey();
                    });
                }
            }

            return bitmap;


        }

        //public List<AtmSet> GetUserAssignedTerminalSet(UserProfile user)
        //{
        //    List<AtmSet> userassignedAtmSet = new List<AtmSet>();

        //    AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService().ExecuteCommand(s =>
        //    {
        //        userassignedAtmSet = s.GetUserAssignedTerminalSet(user);
        //    });

        //    return userassignedAtmSet;
        //}
        ///// <summary>
        ///// Checks if any incident in parameter collection is erlated to ATM which is in user terminal set
        ///// </summary>
        ///// <param name="userBitmap"></param>
        ///// <param name="incidents"></param>
        ///// <returns></returns>
        //public bool IsAny(byte[] userBitmap, IEnumerable<Incident> incidents)
        //{
        //    List<Incident> authorizedList = incidents.ToList();

        //    AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService().ExecuteCommand(s =>
        //    {
        //        authorizedList = s.AuthorizeIncidents(userBitmap, authorizedList);
        //    });

        //    return authorizedList.Any();
        //}

        ///// <summary>
        ///// Authorize incident list for specific user(regarding user terminal set bitmap)
        ///// </summary>
        ///// <param name="userBitmap"></param>
        ///// <param name="incidents"></param>
        ///// <returns></returns>
        //public IList<Incident> AuthorizeIncidentList(byte[] userBitmap, IEnumerable<Incident> incidents)
        //{
        //    List<Incident> authorizedList = incidents.ToList();
        //    AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService().ExecuteCommand(s =>
        //    {
        //        authorizedList = s.AuthorizeIncidents(userBitmap, authorizedList);
        //    });
        //    Logger.Log.DebugFormat("Authorization Manager : AuthorizeIncidentList -> 1 count after authorize : {0}", authorizedList.Count);
        //    return authorizedList;

        //}

        /// <summary>
        /// Returns terminal set bitmap for specific ATM
        /// </summary>
        /// <param name="atmId"></param>
        /// <returns></returns>
        public byte[] GetTerminalSetBitmapForAtm(long? atmId)
        {
            byte[] bitmap = null;

            AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService().ExecuteCommand(s =>
            {
                bitmap = s.GetTerminalSetBitmapForAtm(atmId);
            });

            return bitmap;
        }

        public byte[] CreateDefaultPermissionKey()
        {
            byte[] bitmap = null;
            AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService()
                                                    .ExecuteCommand(s =>
                                                    {
                                                        bitmap = s.CreateDefaultPermissionKey();
                                                    });

            return bitmap;
        }



        //public byte[] CreateDefaultPermissionKey(short userId)
        //{
        //    byte[] bitmap = null;
        //    AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService()
        //                                            .ExecuteCommand(s =>
        //                                            {
        //                                                bitmap = s.CreatePermissionKey(userId);
        //                                            });

        //    return bitmap;
        //}

        public byte[] CreatePermissionKey(List<AtmSet> atmSets)
        {

            byte[] bitmap = null;
            AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService()
                                                    .ExecuteCommand(s =>
                                                    {
                                                        bitmap = s.CreatePermissionKey(atmSets);
                                                    });

            return bitmap;
        }

        public byte[] CreateZeroPermissionKey()
        {
            byte[] bitmap = null;
            AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService()
                                                    .ExecuteCommand(s =>
                                                    {
                                                        bitmap = s.CreateZeroPermissionKey();
                                                    });

            return bitmap;
        }

   
        //public object Filter(UserProfile user, HelpDeskTarget target, string command, IList source)
        //{
        //    object obj = null;
        //    AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService()
        //                                            .ExecuteCommand(s =>
        //                                            {
        //                                                obj = s.Filter(user, target,command, source);
        //                                            });

        //    return obj;
        //}



        //public byte[] GetPermissionKey(long atmId)
        //{
        //    byte[] bitmap = null;
        //    AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService()
        //                                            .ExecuteCommand(s =>
        //                                            {
        //                                                bitmap = s.GetPermissionKey(atmId);
        //                                            });

        //    return bitmap;
        //}

        //public bool IsActionAllowedOnEntity(UserProfile user, HelpDeskTarget target, string command)
        //{
        //    var result = false;

        //    AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService().ExecuteCommand(s =>
        //    {
        //        result = s.IsActionAllowedOnEntity(user, target, command);
        //    });

        //    return result;
        //}

        //public List<string> IsActionsAllowedOnEntity(UserProfile user, HelpDeskTarget target, List<string> actions, IList source)
        //{
        //    List<string> result = new List<string>();

        //    AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService().ExecuteCommand(s =>
        //    {
        //        result = s.IsActionsAllowedOnEntity(user, target, actions, source);
        //    });

        //    return result;
        //}

        //public bool IsTransitionAllowed(UserProfile user, string command, IList source)
        //{
        //    var result = false;

        //    AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService().ExecuteCommand(s =>
        //    {
        //        result = s.IsTransitionAllowed(user, command, source);
        //    });

        //    return result;
        //}

        //public bool IsTransitionAllowed(UserProfile user, string command)
        //{
        //    var result = false;

        //    AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService().ExecuteCommand(s =>
        //    {
        //        result = s.IsTransitionAllowed(user, command);
        //    });

        //    return result;
        //}

        //public List<string> IsTransitionsAllowed(UserProfile user, List<string> transitions, IList source)
        //{
        //    List<string> result = new List<string>();

        //    AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService().ExecuteCommand(s =>
        //    {
        //        result = s.IsTransitionsAllowed(user, transitions, source);
        //    });

        //    return result;
        //}

        //public void ValidateTerminalSetData()
        //{
        //    AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService().ExecuteCommand(s =>
        //    {
        //         s.ValidateTerminalSetData();
        //    });
        //}

        //public void RefreshRbacData(UserProfile user)
        //{
        //    AuthorizationServiceProxyProvider.AuthorizationServiceProxyProvider.Instance.GetService().ExecuteCommand(s =>
        //    {
        //        s.RefreshRbacData(user);
        //    });
        //}

        #endregion 
    }
}
