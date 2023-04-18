using Serilog;
using Moriah.Web.Middlewares;
using Microsoft.EntityFrameworkCore;
using Moriah.Infra.Data.Context;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SQLServer");
var options = new DbContextOptionsBuilder<MoriahDataContext>()
    .UseSqlServer(connectionString)
    .Options;

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();
builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddAutoMapper();
builder.Services.AddMvc();
builder.Services.AddDbContext<MoriahDataContext>(options => options.UseSqlServer(connectionString));

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
