using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CD.Infrastructure.Poco;
using CD.Infrastructure.Poco.Enum;
using CD.Infrastructure.Services.App;
using PostSharp.Aspects;

namespace CD.Authorization.Authorization
{
    [Serializable]
    public class AuthorizeActionsAttribute : OnMethodBoundaryAspect
    {
        //private MethodInfo methodInfo;
        //private PropertyInfo currentUserInfo;
        //public HelpDeskCommand Command { get; set; }
        //public HelpDeskTarget Target { get; set; }

       
        //public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        //{
        //    methodInfo = (MethodInfo)method;
        //    if (method.GetParameters().Any())
        //    {
        //        currentUserInfo = method.GetParameters()[0].ParameterType.GetProperty("CurrentUserProfile");
        //    }
        //}

        //public override void OnEntry(MethodExecutionArgs args)
        //{
        //    var operationResult = IsActionAllowed(args);

        //    if (!operationResult.Result)
        //    {
        //        if (methodInfo != null && methodInfo.ReturnType.IsAssignableFrom(typeof(IOperationResult)))
        //        {
        //            operationResult.Message = "Action is forbidden.";
        //            operationResult.MessageKey = "ActionForbidden";
        //            args.ReturnValue = operationResult;

        //        }

        //        args.FlowBehavior = FlowBehavior.Return;
        //    }
        //}

        //private IOperationResult IsActionAllowed(MethodExecutionArgs args)
        //{
        //    var result = false;

        //    var operationResult = new OperationResult() { Result = true, Data = new List<object>() { -1 } };

        //    if (methodInfo != null && args.Arguments.Count() > 0
        //        && args.Arguments[0].GetType().IsAssignableFrom(typeof(Incident)))
        //    {
        //        var incident = (Incident)args.Arguments[0];

        //        UserProfile currentUser;

        //        if (currentUserInfo == null && !args.Arguments.Any(arg => arg != null && arg.GetType().Name == "UserProfile"))
        //        {
        //            throw new ArgumentNullException("Method decorated with 'AuthorizeActionsAttribute' must have at least 'UserProfile' argument or existing argument must have property named 'CurrentUserProfile' of type UserProfile");
        //        }

        //        if (currentUserInfo == null)
        //        {
        //            var argument = args.Arguments.FirstOrDefault(arg => arg != null && arg.GetType().Name == "UserProfile");
        //            currentUser = (UserProfile)argument;
        //        }
        //        else
        //        {
        //            currentUser = (UserProfile)currentUserInfo.GetValue(args.Arguments[0], null);
        //        }
        //        if (currentUser == null)
        //        {
        //            throw new ArgumentNullException("Method decorated with 'AuthorizeActionsAttribute' must have at least 'UserProfile' argument or existing argument must have property named 'CurrentUserProfile' of type UserProfile with not null value");
        //        }
        //        result = AuthorizationManager.Instance.IsActionAllowedOnEntity(currentUser, Target,
        //                                                                       Enum.GetName(typeof (HelpDeskCommand),Command),
        //                                                                       incident);
        //        operationResult.Result = result;
        //        operationResult.Data = new List<object>() { incident.IncidentId };
        //    }

        //    return operationResult;
        //}

    }
}
