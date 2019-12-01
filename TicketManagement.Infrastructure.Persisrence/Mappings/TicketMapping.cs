using NHibernate.Mapping.ByCode.Conformist;
using TicketManagement.Domain.TicketAgg;

namespace TicketManagement.Infrastructure.Persisrence.Mappings
{
    public class TicketMapping : ClassMapping<Ticket>
    {
        public TicketMapping()
        {
            Table("Tickets");
            Lazy(false);

            Property(x => x.Message);
            Property(x => x.CreationDateTime);

            ComponentAsId(ticket => ticket.Id,
                mapper => { mapper.Property(x => x.DbId, propertyMapper => propertyMapper.Column("Id")); });

            Component(ticket => ticket.SchoolId,
                mapper => { mapper.Property(x => x.Value, propertyMapper => propertyMapper.Column("SchoolId")); });

            Component(ticket => ticket.Type,
                mapper => { mapper.Property(x => x.Value, propertyMapper => propertyMapper.Column("Type")); });
        }
    }
}