using Moriah.Web.Middlewares;
using Moriah.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();
builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddAutoMapper();
builder.Services.AddMvc();
builder.Services.RegisterAllValidators();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ErrorHandlingMiddleware>();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
