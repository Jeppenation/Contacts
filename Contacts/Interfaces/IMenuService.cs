

namespace Contacts.Interfaces
{
    public interface IMenuService
    {
        /// <summary>
        /// Displays the menu
        /// </summary>
        /// <returns>void</returns> 

        void DisplayMenu();


        /// <summary>
        ///Takes the user input and converts into a INT 
        /// </summary>
        /// <returns>Returns choice as an int</returns>
        public int GetMenuChoice();
    }
}
