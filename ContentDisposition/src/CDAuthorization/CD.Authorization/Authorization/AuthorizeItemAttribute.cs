using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ESQ.Infrastructure.Poco;
using CD.Infrastructure.Poco;
using CD.Infrastructure.Poco.Enum;
using PostSharp.Aspects;

namespace CD.Authorization.Authorization
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Method)]
    public class AuthorizeItemAttribute : OnMethodBoundaryAspect
    {
       // private HelpDeskTarget target;
       // private HelpDeskCommand command;
       // private MethodInfo methodInfo;
       // private PropertyInfo currentUserInfo;
        
       // public AuthorizeItemAttribute(HelpDeskTarget target, HelpDeskCommand command)
       // {
       //     this.target = target;
       //     this.command = command;
       // }

       // /// <summary>
       // /// Method executed at build time. Initializes the aspect instance. After the execution
       // /// of <see cref="CompileTimeInitialize"/>, the aspect is serialized as a managed 
       // /// resource inside the transformed assembly, and deserialized at runtime.
       // /// </summary>
       // /// <param name="method">Method to which the current aspect instance 
       // /// has been applied.</param>
       // /// <param name="aspectInfo">Unused.</param>
       // public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
       // {
       //     methodInfo = (MethodInfo)method;
           
       //     if (method.GetParameters().Any())
       //     {
       //         currentUserInfo = method.GetParameters()[0].ParameterType.GetProperty("CurrentUserProfile");
       //     }
            
       // }

       // public override void OnExit(MethodExecutionArgs args)
       // {
       //     //TerminalSetScope(args);
       //     RbacScope(args);
       // }

       ///* private void TerminalSetScope(MethodExecutionArgs args)
       // {
       //     if (target.Equals(HelpDeskTarget.Incident) && command.Equals(HelpDeskCommand.View))
       //     {
       //         var parallelSource = ((IEnumerable<Incident>)args.ReturnValue).AsParallel();
       //         var userBitmap = AuthenticationManager.CurrentUserProfile.PermissionKey;

       //         args.ReturnValue =
       //             parallelSource.Where(i => TerminalSetPermissionManager.Instance.IsAtmInTermSet(userBitmap, i.ObjectKey)).ToList();
       //     }
       // }*/

       // private void RbacScope(MethodExecutionArgs args)
       // {
       //     UserProfile currentUser = null;

       //     if (currentUserInfo == null && !args.Arguments.Any(arg => arg != null && arg.GetType().Name == "UserProfile"))
       //     {
       //         if (((IEnumerable<Incident>)args.ReturnValue).Count() > 0)
       //         {
       //             currentUser = ((IEnumerable<Incident>)args.ReturnValue).First().CurrentUserProfile;
       //         }
       //         if (currentUser == null)
       //         {
       //             throw new ArgumentNullException("Method decorated with 'AuthorizeItemAttribute' must have at least 'UserProfile' argument or existing argument must have property named 'CurrentUserProfile' of type UserProfile");
       //         }
       //     }
       //     if (currentUser == null)
       //     {
       //         if (currentUserInfo == null)
       //         {
       //             var argument = args.Arguments.FirstOrDefault(arg => arg != null && arg.GetType().Name == "UserProfile");
       //             currentUser = (UserProfile)argument;
       //         }
       //         else
       //         {
       //             currentUser = (UserProfile)currentUserInfo.GetValue(args.Arguments[0], null);
       //         }
       //     }
       //     if (currentUser == null)
       //     {
       //         throw new ArgumentNullException("Method decorated with 'AuthorizeTransitionsAttribute' must have at least 'UserProfile' argument or existing argument must have property named 'CurrentUserProfile' of type UserProfile with not null value");
       //     }
       //     if (((IEnumerable<BasePoco>) args.ReturnValue).Any())
       //     {
       //         args.ReturnValue = AuthorizationManager.Instance.Filter(currentUser, target,
       //                                                            Enum.GetName(typeof(HelpDeskCommand), command),
       //                                                            ((IEnumerable<BasePoco>)args.ReturnValue).ToList());
       //     }
           
       // }
    }
}
