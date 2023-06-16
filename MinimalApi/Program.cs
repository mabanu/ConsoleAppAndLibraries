using Dapper;
using MinimalApi;
using SharedLibrary.Database;
using TestLibrary;
using TestLibrary.Database;
using Users;
using Users.Database;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton(new DbConnectionString()
    { ConnectionString = builder.Configuration.GetValue<string>("DatabaseName")! });

builder.Services.AddSingleton<AppDbContext>();

builder.Services.AddTestModule();
builder.Services.AddUserModule();

builder.Services.AddSwaggerGen();

// Fix Guid problem with dapper
SqlMapper.AddTypeHandler(new GuidTypeHandler());
SqlMapper.RemoveTypeMap(typeof(Guid));
SqlMapper.RemoveTypeMap(typeof(Guid));

var app = builder.Build();

{
    using var appscope = app.Services.CreateScope();

    var dbContext = appscope.ServiceProvider.GetRequiredService<AppDbContext>();

    dbContext.TestExtension();
    dbContext.UserExtension();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "yeah");
app.MapControllers();
app.UseTestModule();

app.Run();