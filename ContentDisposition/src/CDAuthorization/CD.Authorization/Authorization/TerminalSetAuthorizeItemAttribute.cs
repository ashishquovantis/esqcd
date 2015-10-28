using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using CD.Infrastructure.Poco;
using CD.Infrastructure.Poco.Enum;
using PostSharp.Aspects;


namespace CD.Authorization.Authorization
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class TerminalSetAuthorizeItemAttribute : OnMethodBoundaryAspect
    {
        //private HelpDeskTarget target;
        //private HelpDeskCommand command;
        //private PropertyInfo currentUserInfo;

        //public TerminalSetAuthorizeItemAttribute(HelpDeskTarget target, HelpDeskCommand command)
        //{
        //    this.target = target;
        //    this.command = command;
        //}

        //public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        //{
        //    if (method.GetParameters().Any())
        //    {
        //        currentUserInfo = method.GetParameters()[0].ParameterType.GetProperty("CurrentUserProfile");
        //    }
        //}


        //public override void OnExit(MethodExecutionArgs args)
        //{
        //    TerminalSetScope(args);
        //}

        //private void TerminalSetScope(MethodExecutionArgs args)
        //{
        //    if (target.Equals(HelpDeskTarget.Incident) && command.Equals(HelpDeskCommand.View)
        //        && args.ReturnValue is IEnumerable<Incident>)
        //    {
        //        UserProfile currentUser = null;

        //        if (currentUserInfo == null && !args.Arguments.Any(arg => arg != null && arg.GetType().Name == "UserProfile"))
        //        {
        //            if (((IEnumerable<Incident>)args.ReturnValue).Count() > 0)
        //            {
        //                currentUser = ((IEnumerable<Incident>)args.ReturnValue).First().CurrentUserProfile;
        //            }
        //            if (currentUser == null)
        //            {
        //                throw new ArgumentNullException("Method decorated with 'TerminalSetAuthorizeItemAttribute' must have at least 'UserProfile' argument or existing argument must have property named 'CurrentUserProfile' of type UserProfile");
        //            }
        //        }

        //        if (currentUser == null)
        //        {
        //            if (currentUserInfo == null)
        //            {
        //                var argument = args.Arguments.FirstOrDefault(arg => arg != null && arg.GetType().Name == "UserProfile");
        //                currentUser = (UserProfile)argument;
        //            }
        //            else
        //            {
        //                currentUser = (UserProfile)currentUserInfo.GetValue(args.Arguments[0], null);
        //            }
        //        }

        //        if (currentUser == null)
        //        {
        //            throw new ArgumentNullException("Method decorated with 'AuthorizeTransitionsAttribute' must have at least 'UserProfile' argument or existing argument must have property named 'CurrentUserProfile' of type UserProfile with not null value");
        //        }

        //        if (((IEnumerable<Incident>)args.ReturnValue).Any())
        //        {
        //            args.ReturnValue = AuthorizationManager.Instance.AuthorizeIncidentList(currentUser.PermissionKey, (IEnumerable<Incident>)args.ReturnValue);
        //        }
        //    }
        //}
    }
}
