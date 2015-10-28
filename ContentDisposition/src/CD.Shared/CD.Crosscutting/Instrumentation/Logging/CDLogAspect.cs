using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ESQ.CrossCutting.Instrumentation;
using ESQ.CrossCutting.Instrumentation.Logging;
using CD.Infrastructure.Services.App;
using PostSharp.Aspects;

namespace CD.CrossCutting.Instrumentation.Logging
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Method)]
    [ExceptionLoggingAspect]
    public class CDLogAspect : LogAspect
    {
        //protected override void ProcessSuccessFinish(MethodExecutionArgs args)
        //{
        //    if (typeof (IOperationResult).IsAssignableFrom(args.ReturnValue.GetType())
        //        || typeof (IWebOperationResult).IsAssignableFrom(args.ReturnValue.GetType()))
        //    {
        //        Logger.Log.InfoFormat("{0} exited with: {1}", MethodFullName, args.ReturnValue);
        //    }
        //    else
        //    {
        //        base.ProcessSuccessFinish(args);
        //    }
        //}

    }
}
