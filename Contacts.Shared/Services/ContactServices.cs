using Contacts.Shared.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;


namespace Contacts.Shared.Services
{
    public class ContactServices : IContactService
    {
        private readonly IFileService _fileService;

        //Path to the file
        private static string baseDirectory = AppDomain.CurrentDomain.BaseDirectory ?? Directory.GetCurrentDirectory();
        private static string relativePath = @"..\..\..\..\..\contacts.json";
        private static string absolutePath = Path.Combine(baseDirectory, relativePath);

        //made the path to the file flexible, so it can be used on different computers
        //Its placed directly under "repos" folder
        private readonly string _filePath = absolutePath;

        private List<IContact> _contacts = [];

        public ContactServices(IFileService fileService)
        {
            _fileService = fileService;
        }

        public bool AddContact(IContact contact)
        {
            try
            {
                if (! _contacts.Any(_contacts => _contacts.EmailAddress == contact.EmailAddress))
                {
                    Debug.WriteLine(_filePath);
                    _contacts.Add(contact);
                    var json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings
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
            try 
            {
                GetContacts();
                var contact = _contacts.FirstOrDefault(_contacts => _contacts.EmailAddress == email);
                return contact ??= null!;
            }
            
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null!;
        }

        public IEnumerable<IContact> GetContacts()
        {
            try
            {
                var json = _fileService.GetContent(_filePath);
                if (json != null)
                {
                    _contacts = JsonConvert.DeserializeObject<List<IContact>>(json, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All,
                        Formatting = Formatting.Indented
                    })!;
                }
                return _contacts;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null!;
        }


        //Expremintellt här nedan: 
        public bool RemoveContact(string email)
        {
            try
            {

                //Hämta alla kontakter
                GetContacts();

                //Hitta kontakten med email
                var contact = _contacts.FirstOrDefault(_contacts => _contacts.EmailAddress == email);

                //om kontakten finns, ta bort den
                if (contact != null)
                {

                    //Ta bort kontakten
                    _contacts.Remove(contact);

                    //Serialisera om listan
                    string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All,
                        Formatting = Formatting.Indented
                    }) ;

                    //Spara uppdaterade listan
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
    }
}
