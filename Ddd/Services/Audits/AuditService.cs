using System;
using Microsoft.Extensions.Logging;
using Ddd.Core.Domain.Audit;
using Ddd.Core.Interfaces;
using System.Linq;
using Ddd.DTOs.Audits;
using System.Threading.Tasks;

namespace Ddd.Services.Audits
{
    public class AuditService : BaseService
    {
        private ILogger<AuditService> _logger;
        //private IUnitOfWork _unitOfWork;
        public AuditService(IUnitOfWork unitOfWork, ILogger<AuditService> logger) : base(unitOfWork)
        {
            _logger = logger;
            //_unitOfWork = unitOfWork;
        }

        public async Task AddNewAuditAsync(AddAuditRequest auditEvent)
        {
            var audit = new Audit(
                    auditEvent.EventName,
                    auditEvent.EventId,
                    auditEvent.EventDescription
                );
            var repository = UnitOfWork.AsyncRepository<Audit>();
            await repository.AddAsync(audit);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
