using Contacts.Shared.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;


namespace Contacts.Shared.Services
{
    public class ContactServices : IContactService
    {
        private readonly IFileService _fileService;

        private readonly string _filePath = @"C:\Users\Hwila\source\repos\Contacts";

        private List<IContact> _contacts = [];

        public bool AddContact(IContact contact)
        {
            try
            {
                if (! _contacts.Any(_contacts => _contacts.Email == contact.Email))
                {
                    _contacts.Add(contact);
                    string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All,
                        Formatting = Formatting.Indented
                    }) ;

                    var result = _fileService.SaveContact(_filePath, json);
                    return true;
                }
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
