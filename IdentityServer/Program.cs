using IdentityServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddIdentityServer(
              options =>
              {
                  options.Events.RaiseErrorEvents = true;
                  options.Events.RaiseFailureEvents = true;
                  options.Events.RaiseInformationEvents = true;
                  options.Events.RaiseSuccessEvents = true;
              }
    )
    .AddInMemoryIdentityResources(Resources.GetIdentityResources())
    .AddInMemoryApiResources(Resources.GetApiResources())
    .AddInMemoryApiScopes(Resources.GetApiScopes())
    .AddInMemoryClients(Clients.Get())
    .AddJwtBearerClientAuthentication()   
     .AddDeveloperSigningCredential();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseIdentityServer();
app.Run();
