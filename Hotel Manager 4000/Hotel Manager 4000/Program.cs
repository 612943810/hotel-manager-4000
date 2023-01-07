using Hotel_Manager_4000.Data;
using Hotel_Manager_4000.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HotelContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("HotelContext")));


builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequiredLength = 12;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
})
 
  .AddEntityFrameworkStores<HotelContext>()
  .AddRoles<IdentityRole>()
.AddDefaultTokenProviders();
/* builder.Services.AddAuthorization(options =>
{
   options.FallbackPolicy = new AuthorizationPolicyBuilder()
         .RequireAuthenticatedUser()
         .Build();
});*/

var app=builder.Build();
using (var appScope = app.Services.CreateScope())
{
    var services = appScope.ServiceProvider;
    var context = services.GetRequiredService<HotelContext>();
    context.Database.Migrate();
    await SeedData.CreateUsers(services);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();
app.UseCors(options =>options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
