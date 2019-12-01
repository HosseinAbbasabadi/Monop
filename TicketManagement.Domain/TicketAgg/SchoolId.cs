using Framework_Domain;
using TicketManagement.Domain.TicketAgg.Constants;

namespace TicketManagement.Domain.TicketAgg
{
    public class SchoolId : ValueObjectBase
    {
        public long Value { get; }

        protected SchoolId()
        {
        }

        public SchoolId(long value)
        {
            Validate(value);

            Value = value;
        }

        private static void Validate(long value)
        {
            GuardAgainstZeroValue(value);
        }

        private static void GuardAgainstZeroValue(long value)
        {
            if (value <= 0)
                throw new LessThanOrEqaulZeroValueException(TicketExceptionMessages.SchoolIdIsLessThanOrEqualZero);
        }
    }
}