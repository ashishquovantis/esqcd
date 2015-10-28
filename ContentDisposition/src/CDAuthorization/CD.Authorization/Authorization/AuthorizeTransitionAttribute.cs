using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ESQ.Infrastructure.Poco;
using CD.Infrastructure.Poco;
using CD.Infrastructure.Services.App;
//using CD.TransitionsWorkflow;
using PostSharp.Aspects;



namespace CD.Authorization.Authorization
{
    [Serializable]
    public class AuthorizeTransitionsAttribute : MethodInterceptionAspect
      {
    //    private MethodInfo methodInfo;
    //    private PropertyInfo currentUserInfo;

    //    [NonSerialized]
    //    private Transition transition;
    //    [NonSerialized]
    //    private Incident incidentInTransition;
    //    /// <summary>
    //    /// Method executed at build time. Initializes the aspect instance. After the execution
    //    /// of <see cref="CompileTimeInitialize"/>, the aspect is serialized as a managed 
    //    /// resource inside the transformed assembly, and deserialized at runtime.
    //    /// </summary>
    //    /// <param name="method">Method to which the current aspect instance 
    //    /// has been applied.</param>
    //    /// <param name="aspectInfo">Unused.</param>
    //    public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
    //    {
    //        methodInfo = (MethodInfo)method;

    //        if (method.GetParameters().Any())
    //        {
    //            currentUserInfo = method.GetParameters()[0].ParameterType.GetProperty("CurrentUserProfile");
    //        }
    //    }



    //    public override void OnInvoke(MethodInterceptionArgs args)
    //    {
    //        var result = IsTransitionAllowed(args);

    //        if (!result)
    //        {
    //            if (methodInfo != null && methodInfo.ReturnType.IsAssignableFrom(typeof(IOperationResult)))
    //            {
    //                //operationResult.MessageKey = "StatusTransitionFailed";
    //                args.ReturnValue = new OperationResult
    //                    {
    //                        Result = result,
    //                        Message = "Transition is forbidden.",
    //                        MessageKey = "TransitionForbidden",
    //                        Data = new List<object> { ((Transition)args.Arguments[0]).NewIncident.IncidentId }
    //                    };
    //            }
    //        }
    //        else
    //        {
    //            //TODO Not finished
    //            transition.NewIncident = incidentInTransition;
    //            args.Arguments.SetArgument(0, transition);

    //            args.Proceed();
    //        }
    //    }
       
    //    private bool IsTransitionAllowed(MethodInterceptionArgs args)
    //    {
    //        if (methodInfo != null && args.Arguments.Count > 0 && args.Arguments[0] != null
    //            && args.Arguments[0].GetType().IsAssignableFrom(typeof(Transition)))
    //        {
    //            transition = ((Transition)args.Arguments[0]);
    //            incidentInTransition = transition.NewIncident;

    //            UserProfile currentUser;

    //            if (currentUserInfo == null && !args.Arguments.Any(arg => arg != null && arg.GetType().Name == "UserProfile"))
    //            {
    //                throw new ArgumentNullException("Method decorated with 'AuthorizeTransitionsAttribute' must have at least 'UserProfile' argument or existing argument must have property named 'CurrentUserProfile' of type UserProfile with not null value");
    //            }
    //            if (currentUserInfo == null)
    //            {
    //                var argument = args.Arguments.FirstOrDefault(arg => arg != null && arg.GetType().Name == "UserProfile");
    //                currentUser = (UserProfile)argument;
    //            }
    //            else
    //            {
    //                currentUser = (UserProfile)currentUserInfo.GetValue(args.Arguments[0], null);
    //            }
    //            if (currentUser == null)
    //            {
    //                throw new ArgumentNullException("Method decorated with 'AuthorizeTransitionsAttribute' must have at least 'UserProfile' argument or existing argument must have property named 'CurrentUserProfile' of type UserProfile with not null value");
    //            }

    //            return AuthorizationManager.Instance.IsTransitionAllowed(transition, currentUser);
    //        }

    //        return true;
    //    }
        
    }
}
