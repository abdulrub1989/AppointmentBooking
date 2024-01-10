
using SussBookingAppointment.Configuration;
using SussBookingAppointment.ExceptionHandling;
using Serilog;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
// <ms_docref_import_types>
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
// </ms_docref_import_types>

var builder = WebApplication.CreateBuilder(args);
//IEnumerable<string>? initialScopes = builder.Configuration["DownstreamApi:Scopes"]?.Split(' ');

//builder.Services.AddMicrosoftIdentityWebAppAuthentication(builder.Configuration, "AzureAd")
//    .EnableTokenAcquisitionToCallDownstreamApi(initialScopes)
//        .AddDownstreamWebApi("DownstreamApi", builder.Configuration.GetSection("DownstreamApi"))
//        .AddInMemoryTokenCaches();
// </ms_docref_add_msal>

// <ms_docref_add_default_controller_for_sign-in-out>
//builder.Services.AddRazorPages().AddMvcOptions(options =>
//{
//    var policy = new AuthorizationPolicyBuilder()
//                  .RequireAuthenticatedUser()
//                  .Build();
//    options.Filters.Add(new AuthorizeFilter(policy));
//}).AddMicrosoftIdentityUI();
// </ms_docref_add_default_controller_for_sign-in-out>

//builder.Host.ConfigureLogging(log =>
//{
//    log.ClearProviders();
//    log.AddConsole();
//    log.AddDebug();
//    log.AddEventLog();
//});

//Serilog
builder.Host.UseSerilog((HostBuilderContext context,IServiceProvider services,LoggerConfiguration loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services);
});

//builder.Services.AddHttpLogging(option => {
//    option.LoggingFields = HttpLoggingFields.RequestProperties | HttpLoggingFields.ResponsePropertiesAndHeaders;
//});
// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddControllersWithViews();
//builder.Services.AddControllersWithViews().AddMvcOptions(options =>
//{
//    var policy = new AuthorizationPolicyBuilder()
//                  .RequireAuthenticatedUser()
//                  .Build();
//    options.Filters.Add(new AuthorizeFilter(policy));
//}).AddMicrosoftIdentityUI();
// <ms_docref_enable_authz_capabilities>
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandlingMiddleware();
    //app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseSerilogRequestLogging();
//app.Logger.LogDebug("Debug");
//app.Logger.LogInformation("Information");
//app.Logger.LogCritical("Critical");
//app.Logger.LogWarning("Warning");
//app.Logger.LogError("Error");
app.UseHttpLogging();

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
