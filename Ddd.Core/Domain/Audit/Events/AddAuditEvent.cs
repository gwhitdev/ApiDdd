using Ddd.Core.Base;

namespace Ddd.Core.Domain.Audit.Events
{
    public class AddAuditEvent : BaseDomainEvent
    {
        public Audit Audit { get; private set; }
        public AddAuditEvent(Audit audit)
        {
            Audit = audit;
        }
    }
}
