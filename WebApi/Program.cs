using ApplicationService;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<AdventistContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Adventist"),
    builder => builder.MigrationsAssembly("WebApi")));

builder.Services.AddControllers();
builder.Services.AddScoped<ICrudService, CrudService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    await SeedData.Initialize(scope.ServiceProvider);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
