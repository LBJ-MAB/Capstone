using Capstone.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TaskDb>(opt => 
    opt.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TaskDB;Trusted_Connection=True;"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();