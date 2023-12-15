using Contacts.Shared.Interfaces;
using System.Diagnostics;


namespace Contacts.Shared.Services
{
    public class ContactServices : IContactService
    {
        private readonly IFileService _fileService;

  

        public bool AddContact(IContact contact)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message); 
            }
            return false;
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
