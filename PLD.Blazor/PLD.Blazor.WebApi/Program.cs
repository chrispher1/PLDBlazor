using PLD.Blazor.DataAccess;
using Microsoft.EntityFrameworkCore;
using PLD.Blazor.Business.IRepositories;
using PLD.Blazor.Business.Repositories;
using System.Text.Json.Serialization;
using PLD.Blazor.Common;

using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PLD.Blazor.Service.IService;
using PLD.Blazor.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PLD Blazor Web_Api", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter Bearer and then token in the field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      new string[] { }
                    }
                });
});
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")    
    )
);

var test = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors(Policy => Policy.AddPolicy("PLD.Blazor", builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()

    )
);

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var apiSettingsSection = builder.Configuration.GetSection(nameof(APISettings));
builder.Services.Configure<APISettings>(apiSettingsSection);

var apiSettings = apiSettingsSection.Get<APISettings>();
var key = Encoding.ASCII.GetBytes(apiSettings.SecretKey);

IConfigurationSection defaultAdminSection = builder.Configuration.GetSection(nameof(DefaultAdmin));
builder.Services.Configure<DefaultAdmin>(defaultAdminSection);

IConfigurationSection defaultRolesSection = builder.Configuration.GetSection(nameof(DefaultRoles));
builder.Services.Configure<DefaultRoles>(defaultRolesSection);
var defaultRoles = defaultRolesSection.Get<DefaultRoles>();

defaultRolesSection.Bind(defaultRoles);

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidAudience = apiSettings.ValidAudience,
        ValidIssuer = apiSettings.ValidIssuer,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization(options =>
{    
    // Assign policy for the list of roles
    options.AddPolicy(ConstantClass.CaseRolePolicy, policy =>
        policy.RequireRole(defaultRoles.Role_Case_User, defaultRoles.Role_Admin)
        );
    options.AddPolicy(ConstantClass.CommissionRolePolicy, policy =>
        policy.RequireRole(defaultRoles.Role_Commission_User, defaultRoles.Role_Admin)
        );
    options.AddPolicy(ConstantClass.PaymentRolePolicy, policy =>
        policy.RequireRole(defaultRoles.Role_Payment_User, defaultRoles.Role_Admin)
        );
    options.AddPolicy(ConstantClass.ReportRolePolicy, policy =>
        policy.RequireRole(defaultRoles.Role_Reports_User, defaultRoles.Role_Admin)
        );
    options.AddPolicy(ConstantClass.MaintenanceRolePolicy, policy =>
        // Code to support the policy must contain all roles
        //policy.RequireAssertion(context =>
        //        context.User.IsInRole(defaultRoles.Role_Maintenance_User) &&
        //        context.User.IsInRole(defaultRoles.Role_Case_User) 
        //)
        policy.RequireRole(defaultRoles.Role_Maintenance_User,defaultRoles.Role_Admin)
        );
    options.AddPolicy(ConstantClass.CommissionUpsertRolePolicy, policy =>
        policy.RequireRole(defaultRoles.Role_Commission_User_Create, defaultRoles.Role_Commission_User_Edit
        , defaultRoles.Role_Admin)
        );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1 c1");
        options.RoutePrefix = string.Empty;
    });
}

await SeedDatabase();
app.UseHttpsRedirection();
app.UseCors("PLD.Blazor");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

async Task SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
       var i = scope.ServiceProvider.GetService<IDbInitializer>();
        await i.Initialize();
    }
}
