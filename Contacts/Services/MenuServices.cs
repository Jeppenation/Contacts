using Contacts.Interfaces;
using Contacts.Shared.Interfaces;
using Contacts.Shared.Models;  
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
            //Get the user input
            Console.Write("\nPlease enter your choice: ");
            var choice = Console.ReadLine();
            return Convert.ToInt32(choice);
        }

        public string GetMenuTitle(string choice)
        {
            //Return the menu title based on the choice
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

        //public void DisplayMenu()
        //{
        //    try
        //    {
        //        while (true)
        //        {
        //            //Display the menu
        //            Console.Clear();
        //            Console.WriteLine("*** Welcome to the Contact App ***");
        //            Console.WriteLine("1. Add Contact");
        //            Console.WriteLine("2. Show All Contacts");
        //            Console.WriteLine("3: Show Specific Contact");
        //            Console.WriteLine("4. Remove Contact\n");
        //            Console.WriteLine("55. Exit");

        //            var choice = GetMenuChoice();

        //            switch (choice)
        //            {
        //                case 1:
        //                    AddContactMenu();
        //                    break;
        //                case 2:
        //                    ShowContactsMenu();
        //                    break;
        //                case 3:
        //                    ShowContactMenu();
        //                    break;
        //                case 4:
        //                    DeleteContact();
        //                    break;
        //                case 55:
        //                    Exit();
        //                    break;
        //                default:
        //                    Console.Clear();
        //                    Console.ForegroundColor = ConsoleColor.Red;
        //                    Console.WriteLine("Invalid Choice");
        //                    Console.ResetColor();
        //                    ConfirmContinue();
        //                    break;
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //    }
        //}

        public void DisplayMenu()
        {
            int menuIndex = 0;

            try
            {
                while (true)
                {
                    // Display the menu based on menuIndex
                    Console.Clear();
                    Console.WriteLine("*** Welcome to the Contact App ***\n");

                    for (int i = 1; i <= 5; i++)
                    {
                        
                        if (i == menuIndex + 1 && i != 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("-> ");
                            Console.ResetColor();
                        }
                        else if (i == menuIndex + 1 && i == 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("-> ");
                            
                        }
                        else
                        {
                            Console.Write(" ");
                        }

                        switch (i)
                        {
                            case 1:
                                Console.WriteLine("Add Contact");
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
                            case 5:
                                Console.WriteLine("Exit");
                                break;
                        }

                        Console.ResetColor();
                    }

                    // Handle arrow key input
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        menuIndex = (menuIndex + 1) % 5;
                    }
                    else if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        menuIndex = (menuIndex - 1 + 5) % 5;
                    }
                    else if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        // Perform action based on the selected menu item (menuIndex)
                        switch (menuIndex + 1)
                        {
                            case 1:
                                AddContactMenu();
                                break;
                            case 2:
                                ShowContactsMenu();
                                break;
                            case 3:
                                ShowContactMenu();
                                break;
                            case 4:
                                DeleteContact();
                                break;
                            case 5:
                                Exit();
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


        private void DeleteContact()
        {
            try
            {
                Console.Clear();
                Console.WriteLine($"*** {GetMenuTitle("4")} ***\n");

                //Get the contact to delete
                Console.Write("Enter the email of the contact you want to delete: ");
                var email = Console.ReadLine()!.ToLower();
                
                //Find the contact
                var contact = _contactService.GetContacts().FirstOrDefault(c => c.EmailAddress.Equals(email, StringComparison.OrdinalIgnoreCase));

                
                //If the contact is found, remove it
                if (contact != null)
                {

                    Console.WriteLine($"\nName: {contact.FirstName} {contact.LastName}");
                    Console.WriteLine($"Phone: {contact.PhoneNumber}");
                    Console.WriteLine($"Email: {contact.EmailAddress}");
                    Console.WriteLine($"Address: {contact.Address}");
                    Console.WriteLine($"City: {contact.City}");
                    Console.WriteLine("***********************************");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\nAre you sure you want to delete this contact? (y/n): ");
                    var message = Console.ReadLine()!;
                    message = message.ToUpper();
                    Console.ResetColor();


                    if (message == "Y")
                    {
                        //Attempt to remove the contact, and check the result
                        bool isRemoved = _contactService.RemoveContact(email);

                        //If the contact was removed, show a success message
                        if (isRemoved)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("--- Contact Removed Successfully ---\n\n");
                            Console.ResetColor();
                            ConfirmContinue();
                        }

                        //If the contact was not removed, show an error message
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("--- Contact Not Removed ---\n\n");
                            Console.ResetColor();
                            ConfirmContinue();
                        }
                    }
                   
                    
                }
                //If the contact was not found, show an error message
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Contact not found!");
                    Console.ResetColor();
                    ConfirmContinue();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void ShowContactMenu()
        {
            try
            {
                Console.Clear();
                Console.WriteLine($"*** {GetMenuTitle("3")} ***\n");
                Console.Write("Enter the email of the contact you want to view: ");
                var email = Console.ReadLine()!;

                var contact = _contactService.GetContacts().FirstOrDefault(c => c.EmailAddress.Equals(email, StringComparison.OrdinalIgnoreCase));

                if (contact != null)
                {
                    Console.WriteLine($"\nName: {contact.FirstName} {contact.LastName}");
                    Console.WriteLine($"Phone: {contact.PhoneNumber}");
                    Console.WriteLine($"Email: {contact.EmailAddress}");
                    Console.WriteLine($"Address: {contact.Address}");
                    Console.WriteLine($"City: {contact.City}");
                    Console.WriteLine("***********************************");

                    ConfirmContinue();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Contact not found!");
                    Console.ResetColor();
                    ConfirmContinue();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private  void ConfirmContinue()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private  void Exit()
        {
            Console.Clear();
            Console.Write("Are you sure you want to exit? (y/n): ");
            var message = Console.ReadLine()!;
            message = message.ToUpper();
            if (message == "Y")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nThank you for using the app!\n\n");
                Console.ResetColor();
                ConfirmContinue();
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

                if (contacts.Count() == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No contacts found!");
                    Console.ResetColor();
                    ConfirmContinue();
                    return;
                }
                else
                {
                    foreach (var contact in contacts)
                    {
                        Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                        Console.WriteLine($"Phone: {contact.PhoneNumber}");
                        Console.WriteLine($"Email: {contact.EmailAddress}");
                        Console.WriteLine($"Address: {contact.Address}");
                        Console.WriteLine($"City: {contact.City}");
                        Console.WriteLine("***********************************");
                    }
                }
               
                ConfirmContinue();
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
            contact.EmailAddress = contact.EmailAddress.ToLower();

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
