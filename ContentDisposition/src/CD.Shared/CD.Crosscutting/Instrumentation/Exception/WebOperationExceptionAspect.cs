using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using ESQ.CrossCutting.Instrumentation;
using CD.Infrastructure.Services.App;
using PostSharp.Aspects;

namespace CD.CrossCutting.Instrumentation.Exception
{
    [Serializable]
    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class WebOperationExceptionAspect : ExceptionAspect
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

        //    if (methodInfo != null && methodInfo.ReturnType.IsAssignableFrom(typeof(IWebOperationResult)))
        //    {
        //        var opResult = new WebOperationResult()
        //        {
        //            Result = false,
        //            ResultText = args.Exception.Message,
        //            HttpStatusCode = HttpStatusCode.BadRequest,
        //        };
                
        //        args.ReturnValue = opResult;

        //        args.FlowBehavior = FlowBehavior.Return;
        //    }
        //    else
        //    {
        //       base.OnException(args);
        //    }

            

        //}
    }
}
