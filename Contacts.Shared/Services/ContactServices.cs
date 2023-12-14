using Contacts.Shared.Interfaces;


namespace Contacts.Shared.Services
{
    public class ContactServices : IContactService
    {
        public bool AddContact(IContact contact)
        {
            throw new NotImplementedException();
        }

        public IContact GetContact(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IContact> GetContacts()
        {
            throw new NotImplementedException();
        }

        public bool RemoveContact(string email)
        {
            throw new NotImplementedException();
        }
    }
}
