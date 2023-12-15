

namespace Contacts.Shared.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// Save a contact to a file
        /// </summary>
        /// <param name="filepath">Enter filepath with extension (eg. C:\user\source\repos\Contacts\contacts.json</param>
        /// <param name="contact">Enters as a string</param>
        /// <returns>Return true if save was succesfull, or false if it failed</returns>
        
        bool SaveContact(string filepath, string contact);

        /// <summary>
        /// Get content from a file
        /// </summary>
        /// <param name="filepath">Enter filepath with extension (eg. C:\user\source\repos\Contacts\contacts.json</param>
        /// <returns>Return content if file exist, else return null</returns>
        
        string GetContent(string filepath);

        /// <summary>
        /// Removes a contact from the list
        /// </summary>
        /// <param name="filepath">Enter filepath with extension (eg. C:\user\source\repos\Contacts\contacts.json</param>
        /// <param name="contact">Enters as a string</param>
        /// <returns>Return true if it was succesfully removed, else return false if failed</returns>

    }
}
