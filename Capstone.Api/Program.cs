using Capstone.Domain.Dtos;
using Capstone.Domain.Entities;
using Capstone.Infrastructure.Persistence;
using Capstone.Infrastructure.Repositories;
using Capstone.UseCases.Commands.AddTask;
using Capstone.UseCases.Commands.DeleteTaskCommand;
using Capstone.UseCases.Commands.UpdateTask;
using Capstone.UseCases.Mapping;
using Capstone.UseCases.Queries.GetAllTasks;
using Capstone.UseCases.Queries.GetCompleteTasks;
using Capstone.UseCases.Queries.GetIncompleteTasks;
using Capstone.UseCases.Queries.GetOverdueTasks;
using Capstone.UseCases.Queries.GetTaskById;
using Capstone.UseCases.Repositories;
using Capstone.UseCases.Validation;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TaskDb>(opt => 
    opt.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TaskDB;Trusted_Connection=True;"));
builder.Services.AddScoped<ITaskRepository, TaskDbRepository>();
builder.Services.AddScoped<IValidator<TaskItemDto>, AddTaskValidator>();
builder.Services.AddScoped<IValidator<TaskItemDto>, UpdateTaskValidator>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetTaskByIdQueryHandler).Assembly));
builder.Services.AddAutoMapper(cfg => { }, typeof(TaskItemDtoMapper));

var app = builder.Build();

app.UseSerilogRequestLogging();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var tasks = app.MapGroup("/tasks");
tasks.MapGet("/", async (ISender sender) =>
{
    var query = new GetAllTasksQuery();
    var allTasks = await sender.Send(query);
    return allTasks is null ? Results.NotFound("No tasks found") : Results.Ok(allTasks) ;
});
tasks.MapGet("/{id}", async (ISender sender, [FromRoute] int id) =>
{
    var query = new GetTaskByIdQuery(id);
    var task = await sender.Send(query);
    return task is null ? Results.NotFound($"No task with id {id} found") : Results.Ok(task) ;
});
tasks.MapGet("/complete", async (ISender sender) =>
{
    var query = new GetCompleteTasksQuery();
    var completeTasks = await sender.Send(query);
    return completeTasks is null ? Results.NotFound("No complete tasks found") : Results.Ok(completeTasks) ;
});
tasks.MapGet("/incomplete", async (ISender sender) =>
{
    var query = new GetIncompleteTasksQuery();
    var incompleteTasks = await sender.Send(query);
    return incompleteTasks is null ? Results.NotFound("No incomplete tasks found") : Results.Ok(incompleteTasks);
});
tasks.MapGet("/overdue", async (ISender sender) =>
{
    var query = new GetOverdueTasksQuery();
    var overdueTasks = await sender.Send(query);
    return overdueTasks is null ? Results.NotFound("No overdue tasks found") : Results.Ok(overdueTasks);
});

tasks.MapPost("/", async (ISender sender, [FromBody] TaskItemDto taskItemDto) =>
{
    var command = new AddTaskCommand(taskItemDto);
    var result = await sender.Send(command);
    return 
        result.Success == true ? 
        Results.Created($"/tasks/{result.TaskItem!.Id}", result.TaskItem) :
        Results.ValidationProblem(result.Errors!);
});
tasks.MapPut("/{id}", async (ISender sender, [FromRoute] int id, [FromBody] TaskItemDto taskItemDto) =>
{
    var command = new UpdateTaskCommand(id, taskItemDto);
    var result = await sender.Send(command);
    return result.Success ? Results.NoContent() :
        result.NotFound == true ? Results.NotFound($"No tasks with id {id}") :
        Results.ValidationProblem(result.Errors!);
});
tasks.MapDelete("/{id}", async (ISender sender, [FromRoute] int id) =>
{
    var command = new DeleteTaskCommand(id);
    var result = await sender.Send(command);
    return result ? Results.NoContent() : Results.NotFound($"No task with id {id}");
});

app.Run();