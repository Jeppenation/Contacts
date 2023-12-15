using Contacts.Interfaces;
using Contacts.Shared.Interfaces;
using Contacts.Shared.Models;  
using Contacts.Shared.Services;

namespace Contacts.Services
{
    public class MenuServices : IMenuService
    {
        public int GetMenuChoice()
        {
            Console.Write("\nPlease enter your choice: ");
            var choice = Console.ReadLine();
            return Convert.ToInt32(choice);

        }

        public void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("*** Welcome to the Contact App ***"); //<- - This is the menu
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Show All Contacts");
                Console.WriteLine("3: Show Specific Contact");
                Console.WriteLine("4. Remove Contact\n");
                Console.WriteLine("55. Exit");

                var choice = GetMenuChoice();

                switch(choice)
                {
                    case 1:
                        AddContactMenu();
                        break;
                    case 2:
                        Console.WriteLine("Show All Contacts");
                        break;
                    case 3:
                        Console.WriteLine("Show Specific Contact");
                        break;
                    case 4:
                        Console.WriteLine("Remove Contact");
                        break;
                    case 55:
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

            }
        }

        private void AddContactMenu()
        {
            throw new NotImplementedException();
        }
    }
}
