using System;
using NSwagGrocerySdk;
using System.Net.Http.Headers;
using System.Net.Http;

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

Console.WriteLine("You ready?");
Console.ReadKey();

var client = new HttpClient();
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImtrYXBsYW4iLCJzdWIiOiJra2FwbGFuIiwianRpIjoiOGI0N2VjZiIsImF1ZCI6WyJodHRwOi8vbG9jYWxob3N0OjYxNjEiLCJodHRwczovL2xvY2FsaG9zdDo0NDM4OCIsImh0dHA6Ly9sb2NhbGhvc3Q6NTA1NiIsImh0dHBzOi8vbG9jYWxob3N0OjcxMTciXSwibmJmIjoxNjgzNzI2MTgwLCJleHAiOjE2OTE2NzQ5ODAsImlhdCI6MTY4MzcyNjE4MCwiaXNzIjoiZG90bmV0LXVzZXItand0cyJ9.g7RvVs5MtlSKux674lpxu91cJL-uP2zp58T6ePDsUBM");

var groceryClient = new GroceryClient("https://localhost:7117", client);

Console.WriteLine("listening items!..");

var items = await groceryClient.GetGroceryItemsAsync();

foreach (var item in items.Data)
{
    Console.WriteLine($"Id :{item.Id} Name :{item.Name}");
}

Console.WriteLine("Adding new item..");

await groceryClient.AddGroceryItemAsync(new GroceryItem { Name = "TryClient3", Description = "tryClient3", Quantity = 1 });

Console.WriteLine("Updated items!..");

items = await groceryClient.GetGroceryItemsAsync();

foreach (var item in items.Data)
{
    Console.WriteLine($"Id :{item.Id} Name :{item.Name}");
}

Console.WriteLine("press countuniue");
Console.ReadKey();
