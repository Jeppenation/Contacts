

namespace Contacts.Shared.Interfaces
{
    internal interface IContactService
    {

        /// <summary>
        /// Add a contact to the contact list
        /// </summary>
        /// <param name="contact">A contact made with IContact</param>
        /// <returns>Return true if succesfull, return false if failed or customer already exist</returns>
        bool AddContact(IContact contact);

        /// <summary>
        /// Get all contacts from contact list
        /// </summary>
        /// 
        /// <returns>Returns contacts if list have items in it, else return null</returns>
        IEnumerable<IContact> GetContacts();

        /// <summary>
        /// Get a specific contact from contact list
        /// </summary>
        /// <param name="email">Enter email as a string</param>
        /// <returns>Returns the found customer if it exist, else returns null.</returns>
        IContact GetContact(string email);

        /// <summary>
        /// Removes a contact from the list with the help of email
        /// </summary>
        /// <param name="email">Enter email as a string</param>
        /// <returns>Return true if succesfully removed, returns false if failed or not found</returns>
        bool RemoveContact(string email);
    }
}
