using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;

namespace CD.WebApiService
{
    public class CDWebApiBehaviorExtensionElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(CDWebApiBehavior); }
        }
        protected override object CreateBehavior()
        {
            return new CDWebApiBehavior();
        }
    }  
}
