using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using ESQ.CrossCutting.Instrumentation.Logging;

namespace CD.Infrastructure.Poco
{
    [DataContract]
    [Serializable]
    [HasSelfLog]
    public partial class Transition// : BasePoco
    {
        public Transition() { }
        public Transition(Tuple<string, string> fromStatusSubStatus, Tuple<string, string> toStatusSubStatus,
                          string transitionAction)
        {
            FromStatusSubStatus = fromStatusSubStatus;
            ToStatusSubStatus = toStatusSubStatus;

            TransitionAction = transitionAction;
        }

        [DataMember]
        [ToLogProperty]
        public Tuple<string, string> FromStatusSubStatus { get; set; }

        [DataMember]
        [ToLogProperty]
        public Tuple<string, string> ToStatusSubStatus { get; set; }

        [DataMember]
        public string TransitionAction { get; set; }

        [DataMember]
        [ToLogProperty]
        public Incident OldIncident { get; set; }

        [DataMember]
        [ToLogProperty]
        public Incident NewIncident { get; set; }

        [DataMember]
        public UserProfile CurrentUserProfile { get; set; }

        private delegate bool Action(Incident incident);

        public override int GetHashCode()
        {
            //create a unique transition key
            return GetHashCode(FromStatusSubStatus, ToStatusSubStatus);
        }

        public static int GetHashCode(Tuple<string, string> fromStatusSubStatus, Tuple<string, string> toStatusSubStatus)
        {
            return (fromStatusSubStatus.GetHashCode() << 8) + toStatusSubStatus.GetHashCode();
        }

        public bool ExecuteAction(string action, Incident incident)
        {
            var result = true;

            if (!string.IsNullOrEmpty(action))
            {
                var methodInfo = GetType().GetMethod(action);

                var transitionAction = (Action)Delegate.CreateDelegate(typeof(Action), this, methodInfo);

                result = transitionAction.Invoke(incident);
            }

            return result;
        }
    }

    
}
