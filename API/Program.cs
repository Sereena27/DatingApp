using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddDbContext<Datacontext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("Defaultconnection"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();

app.Run();
