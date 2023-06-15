using MinimalApi.Database;
using MinimalApi.Repositories;
using SharedLibrary.Database;
using TestLibrary;
using TestLibrary.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(new DbConnectionString()
    { ConnectionString = builder.Configuration.GetValue<string>("DatabaseName")! });
builder.Services.AddSingleton(new DatabaseConfig()
    { ConnectionString = builder.Configuration.GetValue<string>("DatabaseName")! });

builder.Services.AddSingleton<AppDbContext>();

builder.Services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

builder.Services.AddControllers();
builder.Services.AddTestLibrary();

builder.Services.AddSwaggerGen();

var app = builder.Build();

{
    using var appscope = app.Services.CreateScope();

    var dbContext = appscope.ServiceProvider.GetRequiredService<AppDbContext>();
    
    dbContext.TestExtension();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "yeah");
app.MapControllers();
app.UseTestLibrary();

app.Run();
