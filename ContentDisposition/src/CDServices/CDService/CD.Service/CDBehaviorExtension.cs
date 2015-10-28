using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;

namespace CD.Service
{
    public class CDBehaviorExtensionElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(CDBehavior); }
        }
        protected override object CreateBehavior()
        {
            return new CDBehavior();
        }
    }  
}
