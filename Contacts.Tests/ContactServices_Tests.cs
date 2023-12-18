using Contacts.Shared.Interfaces;
using Contacts.Shared.Models;
using Contacts.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Tests
{
    public class ContactServices_Tests
    {
        [Fact]
        public void AddToList_ShouldAddContactToList_ThenReturnTrue()
        {
            // Arrange
            IContact contact = new Contact { FirstName = "John", LastName = "Doe", EmailAddress = "test@domain.com", Address = "teststreet 123", City = "Test City", PhoneNumber = "555-12345" };
            IFileService fileService = new FileService();
            IContactService contactService = new ContactServices(fileService);

            // Act
            var result = contactService.AddContact(contact);

            // Assert
            Assert.True(result);

        }
    }
}
