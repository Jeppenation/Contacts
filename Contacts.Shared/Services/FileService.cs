using Contacts.Shared.Interfaces;
using System.Diagnostics;


namespace Contacts.Shared.Services
{
    public class FileService : IFileService
    {
        public string GetContent(string filepath)
        {
            try
            {
                if (File.Exists(filepath))
                {
                    return File.ReadAllText(filepath);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null!;

        }

        public bool SaveContact(string filepath, string contact)
        {
           try
            {
                Debug.WriteLine(filepath);
                using var writer = new StreamWriter(filepath);
                writer.WriteLine(contact);
                return true;
           }
           catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
           }
            return false;
        }
    }
}
