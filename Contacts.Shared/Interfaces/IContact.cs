

namespace Contacts.Shared.Interfaces
{
    public interface IContact
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string EmailAddress { get; set; }
        string PhoneNumber { get; set; }
        string Address { get; set; }
        string City { get; set; }
    }
}
