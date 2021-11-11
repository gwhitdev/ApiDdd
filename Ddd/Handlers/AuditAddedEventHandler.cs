using System;
using MediatR;
using Ddd.Core.Domain.Audit.Events;
using System.Threading.Tasks;
using System.Threading;
using Ddd.Services.Audits;
using Ddd.DTOs.Audits;

namespace Ddd.Events.Handlers.Audits
{
    public class AuditAddedEventHandler : INotificationHandler<AddAuditEvent>
    {
        private AuditService _auditService;
        public AuditAddedEventHandler(AuditService auditService)
        {
            _auditService = auditService;
        }

        public async Task Handle(AddAuditEvent notification, CancellationToken cancellationToken)
        {
            var audit = new AddAuditRequest(
                notification.Audit.EventName,
                notification.Audit.EventId,
                notification.Audit.EventDescription);

            await _auditService.AddNewAuditAsync(audit);            
        }
    }
}
