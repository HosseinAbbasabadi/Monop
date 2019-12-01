using System.Collections.Generic;
using Framework.Core.Events;

namespace Framework_Domain
{
    public abstract class EventSourceAggregate<T> : EntityBase<T>
    {
        public List<DomainEvent> Changes { get; set; }
        public int Version { get; set; }

        protected EventSourceAggregate()
        {
            Changes = new List<DomainEvent>();
        }

        protected abstract void Apply(DomainEvent @event);
    }
}
