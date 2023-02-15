using Albaflex.IoC;
using Albaflex.WebApi;
using FluentMigrator.Runner;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddBusinessServices();
builder.Services.AddDatabaseConfiguration();
builder.Services.AddMvc(options => options.Filters.Add<NotificationFilter>());

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var scope = app.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;
var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
runner.MigrateUp();

// added to resolve exception "Cannot write DateTime with Kind=UTC to PostgreSQL type 'timestamp without time zone'"
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.Run();
