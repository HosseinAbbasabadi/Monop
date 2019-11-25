using System;
using System.Transactions;

namespace TrainingManagement.Domain
{
    public class Ticket
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        public Ticket(long id, string title, string message)
        {
            Id = id;
            Title = title;
            Message = message;
        }
    }
}