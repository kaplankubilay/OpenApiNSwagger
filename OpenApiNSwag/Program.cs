using Business.Abstract;
using Business.Concrete;
using GroceryDal;
using GroceryDal.Abstract;
using GroceryDal.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IGroceryRepository, EfGroceryRepository>();
builder.Services.AddScoped<IGroceryService, GroceryService>();

//JWT implements
builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Swagger sacurity schemes added.
builder.Services.Configure<SwaggerGeneratorOptions>(x => { x.InferSecuritySchemes = true; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/groceries", (IGroceryService groceryService) =>
{
    return TypedResults.Ok(groceryService.GetAll());
}).WithName("GetGroceryItems");

//app.MapGet("/api/groceries", (IGroceryService groceryRepository) =>
//    {
//        return TypedResults.Ok(groceryRepository.GetAll());
//    }).WithName("GetGroceryItems");

app.MapGet("/api/groceries/{id:int}",
    Results<Ok<GroceryItem>, NotFound> ([FromRoute] int id, IGroceryService groceryService) =>
    {
        GroceryItem item = groceryService.GetByGroceryId(id).Data;
        return item != null ? TypedResults.Ok(item) : TypedResults.NotFound();
    }).WithName("GetGroceryItem");

//app.MapGet("/api/groceries/{id:int}",
//    Results<Ok<GroceryItem>, NotFound> ([FromRoute] int id, IGroceryRepository groceryRepository) =>
//    {
//        GroceryItem item = groceryRepository.Get(id);
//        return item != null ? TypedResults.Ok(item) : TypedResults.NotFound();
//    }).WithName("GetGroceryItem");

app.MapPost("/api/groceries", [Authorize] (IGroceryService groceryService, GroceryItem groceryItem) =>
    {
        groceryService.AddGrocery(groceryItem);
        return TypedResults.Created($"/api/groceries/{groceryItem.Id}", groceryItem);
    }).WithName("AddGroceryItem")

    //open api security implemented
    .WithOpenApi(operation =>
    {
        operation.Security = new List<OpenApiSecurityRequirement>
        {
         new OpenApiSecurityRequirement
         {
             {
                 new OpenApiSecurityScheme
                 {
                     Reference = new OpenApiReference
                     {
                         Type = ReferenceType.SecurityScheme,
                         Id = JwtBearerDefaults.AuthenticationScheme,
                     },
                     Scheme = SecuritySchemeType.Http.ToString(),
                     Name = JwtBearerDefaults.AuthenticationScheme,
                 },
                 new List<string>()
             }
         }

        };
        return operation;
    });

app.Run();
