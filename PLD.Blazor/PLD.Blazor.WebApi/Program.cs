using PLD.Blazor.DataAccess;
using Microsoft.EntityFrameworkCore;
using PLD.Blazor.Business.IRepositories;
using PLD.Blazor.Business.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")    
    )
);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors(Policy => Policy.AddPolicy("PLD.Blazor", rules => rules.AllowAnyHeader().AllowAnyOrigin()
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("PLD.Blazor");
app.UseAuthorization();

app.MapControllers();

app.Run();
