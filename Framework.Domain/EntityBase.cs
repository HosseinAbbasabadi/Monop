using System;
using Framework.Core.Events;

namespace Framework_Domain
{
    public abstract class EntityBase<T>
    {
        public T Id { get; protected set; }
        public IEventPublisher EventPublisher { get; protected set; }
        public DateTime CreationDateTime { get; protected set; }

        protected EntityBase()
        {
        }

        protected EntityBase(T id)
        {
            Id = id;
            CreationDateTime = DateTime.Now;
        }

        protected EntityBase(T id, IEventPublisher eventPublisher)
        {
            Id = id;
            CreationDateTime = DateTime.Now;
            EventPublisher = eventPublisher;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != GetType()) return false;

            var entity = obj as EntityBase<T>;
            return Id.Equals(entity.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}