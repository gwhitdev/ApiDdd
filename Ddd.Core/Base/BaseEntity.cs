﻿using System.Collections.Generic;

namespace Ddd.Core.Base
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }

    
}
