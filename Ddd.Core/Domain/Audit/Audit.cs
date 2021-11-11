using Ddd.Core.Base;

namespace Ddd.Core.Domain.Audit
{
    public class Audit : BaseEntity
    {
        public string EventName { get; private set; }
        public int EventId { get; private set; }
        public string EventDescription { get; private set; }
        public Audit(string eventName, int eventId, string eventDescription)
        {
            EventName = eventName;
            EventId = eventId;
            EventDescription = eventDescription;
        }
        private Audit()
        { }

    }
}
