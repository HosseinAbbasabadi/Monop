using System;

namespace Framework.Core.Events
{
    public abstract class DomainEvent : IEvent
    {
        public Guid EventId { get; }
        public string Name { get; set; }
        protected DomainEvent()
        {
            EventId = Guid.NewGuid();
        }
    }
}
