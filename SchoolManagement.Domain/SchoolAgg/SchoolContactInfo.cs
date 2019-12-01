using System.Collections.Generic;
using System.Collections.ObjectModel;
using Framework_Domain;

namespace SchoolManagement.Domain.SchoolAgg
{
    public class SchoolContactInfo : ValueObjectBase
    {
        private readonly IList<string> _phoneNumbers;

        public string FaxNumber { get; }
        public string WebSite { get; }
        public string Email { get; }
        public IReadOnlyCollection<string> PhoneNumbers => new ReadOnlyCollection<string>(_phoneNumbers);

        public SchoolContactInfo(IList<string> phoneNumbers, string faxNumber, string webSite, string email)
        {
            _phoneNumbers = phoneNumbers;
            FaxNumber = faxNumber;
            WebSite = webSite;
            Email = email;
        }
    }
}