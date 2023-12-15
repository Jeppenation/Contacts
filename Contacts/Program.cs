// See https://aka.ms/new-console-template for more information
using Contacts.Interfaces;
using Contacts.Services;
using Contacts.Shared.Interfaces;
using Contacts.Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddSingleton<IFileService, FileService>();
    services.AddSingleton<IContactService, ContactServices>();
    services.AddSingleton<IMenuService, MenuServices>();
}).Build();

builder.Start();
Console.Clear();

var menuService = builder.Services.GetRequiredService<IMenuService>();
menuService.DisplayMenu();

