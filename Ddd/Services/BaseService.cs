using System;
using Ddd.Core.Interfaces;

namespace Ddd.Services
{
    public class BaseService
    {
        protected internal IUnitOfWork UnitOfWork { get; set; }

        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
