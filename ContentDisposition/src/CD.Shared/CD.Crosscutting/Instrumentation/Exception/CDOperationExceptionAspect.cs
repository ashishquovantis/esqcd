using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using ESQ.CrossCutting.Instrumentation;
using ESQ.CrossCutting.Instrumentation.Exceptions;
using CD.Infrastructure.Poco;
using CD.Infrastructure.Poco.Enum;
using CD.Infrastructure.Services.App;
using PostSharp.Aspects;
using System.ServiceModel;

namespace CD.CrossCutting.Instrumentation.Exception
{
    [Serializable]
    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CDOperationExceptionAspect : ExceptionAspect
    {

        ///*/// <summary>
        ///// Method executed at build time. Initializes the aspect instance. After the execution
        ///// of <see cref="CompileTimeInitialize"/>, the aspect is serialized as a managed 
        ///// resource inside the transformed assembly, and deserialized at runtime.
        ///// </summary>
        ///// <param name="method">Method to which the current aspect instance 
        ///// has been applied.</param>
        ///// <param name="aspectInfo">Unused.</param>
        //public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        //{
        //    methodName = method.Name;
        //}*/

        //public override void OnException(MethodExecutionArgs args)
        //{
        //    var methodInfo = (MethodInfo)args.Method;
        //    Logger.Log.Error("Exception trapped");
        //    if (args.Exception is FaultException
        //           || args.Exception is CommunicationException
        //           || args.Exception is TimeoutException
        //           || args.Exception is EndpointNotFoundException
        //           || args.Exception.InnerException is FaultException
        //           || args.Exception.InnerException is CommunicationException
        //           || args.Exception.InnerException is TimeoutException
        //           || args.Exception.InnerException is EndpointNotFoundException
        //           )
        //    {
        //        base.OnException(args);
        //        //args.FlowBehavior = FlowBehavior.RethrowException;
        //    }
        //    else if (methodInfo != null && methodInfo.ReturnType.IsAssignableFrom(typeof(IOperationResult)))
        //    {
        //        if (args.Exception.Message.Contains("The message could not be dispatched because the service at the endpoint address"))
        //        {
        //            Logger.Log.Error("HelpDeskOperationExceptionAspect trapped endpoint " + args.Exception.GetType());
        //        }
        //        else
        //        {
        //            Logger.Log.Error("HelpDeskOperationExceptionAspect trapped type : " + args.Exception.GetType());
        //        }

        //        var opResult = new OperationResult()
        //                               {
        //                                   Result = false,
        //                                   Exception = args.Exception,
        //                                   ResultCode = (args.Exception is EsqArgumentException
        //                                                ? ResultCodes.ValidationFailed
        //                                                : ResultCodes.Error),
        //                                   MessageKey = (args.Exception is EsqArgumentException
        //                                                ? ((EsqArgumentException)args.Exception).MessageKey
        //                                                : String.Format("{0}_Failed", args.Method.Name)),
        //                                   Message = (args.Exception is EsqArgumentException
        //                                                ? args.Exception.Message
        //                                                : String.Format("{0} failed. Message:{1} \r\n {2}. ", args.Method.Name, args.Exception.Message, args.Exception.StackTrace))
        //                               };

        //        if (args.Arguments[0].GetType().IsAssignableFrom(typeof(Incident)))
        //        {
        //            opResult.Data = new List<object> { ((Incident)args.Arguments[0]).IncidentId };
        //        }
        //        else if (args.Arguments[0].GetType().IsAssignableFrom(typeof(Transition)))
        //        {
        //            opResult.Data = new List<object> { ((Transition)args.Arguments[0]).NewIncident.IncidentId };
        //        }

        //        args.ReturnValue = opResult;

        //        args.FlowBehavior = FlowBehavior.Return;
        //    }
        //    else
        //    {
        //        string methodFullName = args.Method.DeclaringType.FullName + "." + args.Method.Name;

        //        Logger.Log.Error("HelpDeskOperationExceptionAspect Type " + args.Exception.GetType() + " Method Name : " + args.Method + " DeclaringType " + args.Method.DeclaringType.FullName);

        //        Logger.ExceptionLog.ErrorFormat("{0} failed. Message:{1} InnerMessage: {2} ExceptionTrace {3}",
        //                             methodFullName,
        //                             args.Exception.Message,
        //                             args.Exception.InnerException != null ? args.Exception.InnerException.Message : string.Empty,
        //                             args.Exception.StackTrace);

        //        //args.FlowBehavior = FlowBehavior.Return;
        //        //base.OnException(args);

        //    }
        //}
    }
}
