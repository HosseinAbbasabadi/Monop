using Framework.Core;

namespace Framework_Domain
{
    public abstract class ValueObjectBase
    {
        public override bool Equals(object obj)
        {
            return obj != null && (obj.GetType() == this.GetType() && EqualsBuilder.ReflectionEquals(this, obj));
        }

        public override int GetHashCode()
        {
            return HashCodeBuilder.ReflectionHashCode(this);
        }
    }

    public class SimpleValueObject<T> : ValueObjectBase
    {
        public T Value { get; set; }

        protected SimpleValueObject(T value)
        {
            Value = value;
        }

        public SimpleValueObject()
        {
        }
    }
}