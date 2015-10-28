using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;


namespace CD.AuthorizationService
{
    public class AuthorizationServiceBehaviorElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(AuthorizationServiceBehavior); }
        }
        protected override object CreateBehavior()
        {
            return new AuthorizationServiceBehavior();
        }
    }
}
