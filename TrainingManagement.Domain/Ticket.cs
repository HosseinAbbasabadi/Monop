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
            if (string.IsNullOrEmpty(title))
                throw new Exception();

            Id = id;
            Title = title;
            Message = message;
        }
    }
}