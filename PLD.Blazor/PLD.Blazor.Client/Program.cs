using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PLD.Blazor.Client;
using PLD.Blazor.Common.Utilities.AuthenticationProviders;
using PLD.Blazor.Service;
using PLD.Blazor.Service.IService;
using PLD.Blazor.Common;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseAPIUrl")) });

builder.Services.AddScoped<ICarrierService, CarrierService>();
builder.Services.AddScoped<IProductTypeService, ProductTypeService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IActivityService, ActivityService>();

// register the Telerik services
builder.Services.AddTelerikBlazor();

//register the BlazoredLocalStorage service
builder.Services.AddBlazoredLocalStorage();


IConfigurationSection defaultRolesSection = builder.Configuration.GetSection(nameof(DefaultRoles));
var defaultRoles = defaultRolesSection.Get<DefaultRoles>();


builder.Services.AddAuthorizationCore(options =>
{
    // Assign policy for the list of roles
    options.AddPolicy(ConstantClass.CaseRolePolicy, policy =>
        policy.RequireRole(defaultRoles.Role_Case_User)
        );
    options.AddPolicy(ConstantClass.CommissionRolePolicy, policy =>
        policy.RequireRole(defaultRoles.Role_Commission_User)
        );
    options.AddPolicy(ConstantClass.PaymentRolePolicy, policy =>
        policy.RequireRole(defaultRoles.Role_Payment_User)
        );
    options.AddPolicy(ConstantClass.ReportRolePolicy, policy =>
        policy.RequireRole(defaultRoles.Role_Reports_User)
        );
    options.AddPolicy(ConstantClass.MaintenanceRolePolicy, policy =>    
        // Code to support the policy must contain all roles
        //policy.RequireAssertion(context =>
        //        context.User.IsInRole(defaultRoles.Role_Maintenance_User) &&
        //        context.User.IsInRole(defaultRoles.Role_Case_User) 
        //)
        policy.RequireRole(defaultRoles.Role_Maintenance_User)
        );
    options.AddPolicy(ConstantClass.CommissionUpsertRolePolicy, policy =>
        policy.RequireRole(defaultRoles.Role_Commission_User_Create, defaultRoles.Role_Commission_User_Edit)
        );
});

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, WebAssemblyAuthenticationStateProvider>();

await builder.Build().RunAsync();
