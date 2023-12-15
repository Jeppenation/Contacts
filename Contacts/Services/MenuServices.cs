using Contacts.Interfaces;
using Contacts.Shared.Interfaces;
using Contacts.Shared.Models;  
using Contacts.Shared.Services;
using System.Diagnostics;

namespace Contacts.Services
{
    public class MenuServices : IMenuService
    {
        private readonly IContactService _contactService;

        public MenuServices(IContactService contactService)
        {
            _contactService = contactService;
        }

        public int GetMenuChoice()
        {
            Console.Write("\nPlease enter your choice: ");
            var choice = Console.ReadLine();
            return Convert.ToInt32(choice);
        }

        public string GetMenuTitle(string choice)
        {

            switch (choice)
            {
                case "1":
                    return "Add Contact";
                case "2":
                    return "Show All Contacts";
                case "3":
                    return "Show Specific Contact";
                case "4":
                    return "Remove Contact";
                case "55":
                    return "Exit";
                default:
                    return "Invalid Choice";
            }

        }

        public void DisplayMenu()
        {
            try
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("*** Welcome to the Contact App ***"); //<- - This is the menu
                    Console.WriteLine("1. Add Contact");
                    Console.WriteLine("2. Show All Contacts");
                    Console.WriteLine("3: Show Specific Contact");
                    Console.WriteLine("4. Remove Contact\n");
                    Console.WriteLine("55. Exit");

                    var choice = GetMenuChoice();

                    switch (choice)
                    {
                        case 1:
                            AddContactMenu();
                            break;
                        case 2:
                            ShowContactsMenu();
                            break;
                        case 3:
                            Console.WriteLine("Show Specific Contact");
                            break;
                        case 4:
                            Console.WriteLine("Remove Contact");
                            break;
                        case 55:
                            Exit();
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private  void Exit()
        {
            Console.Clear();
            Console.WriteLine("Are you sure you want to exit? (y/n)");
            var message = Console.ReadLine()!;
            message = message.ToUpper();
            if (message == "Y")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nThank you for using the app!\n\n");
                Console.ResetColor();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                DisplayMenu();
            }
            
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void ShowContactsMenu()
        {
            try
            {
                Console.Clear();
                Console.WriteLine($"*** {GetMenuTitle("2")} ***\n");
                var contacts = _contactService.GetContacts();
                foreach (var contact in contacts)
                {
                    Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                    Console.WriteLine($"Phone: {contact.PhoneNumber}");
                    Console.WriteLine($"Email: {contact.EmailAddress}");
                    Console.WriteLine($"Address: {contact.Address}");
                    Console.WriteLine($"City: {contact.City}");
                    Console.WriteLine("***********************************");
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void AddContactMenu()
        {
            //Create a new contact
            IContact contact = new Contact();

            Console.Clear();
            
            //Add contact information
            Console.WriteLine($"*** {GetMenuTitle("1")} ***\n");

            Console.Write("Enter First Name: ");
            contact.FirstName = Console.ReadLine()!;

            Console.Write("Enter Last Name: ");
            contact.LastName = Console.ReadLine()!;

            Console.Write("Enter Phone Number: ");
            contact.PhoneNumber = Console.ReadLine()!;

            Console.Write("Enter Email Address: ");
            contact.EmailAddress = Console.ReadLine()!;

            Console.Write("Enter Address: ");
            contact.Address = Console.ReadLine()!;

            Console.Write("Enter City: ");
            contact.City = Console.ReadLine()!;

            //Add the contact to the list
            _contactService.AddContact(contact);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--- Contact Added Successfully ---\n\n");
            Console.ResetColor();

            Console.WriteLine("Would you like to add another contact? (y/n)");
            var message = Console.ReadLine()!;

            message = message.ToUpper();
            if (message == "Y")
            {
                AddContactMenu();
            }
            else
            {
                DisplayMenu();
            }
            Console.ReadKey();
            DisplayMenu();
            
            
        }
    }
}
