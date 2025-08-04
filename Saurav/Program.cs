using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Saurav.DataAccess;
using Saurav.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnections"), b => b.MigrationsAssembly("Saurav")));
builder.Services.AddDefaultIdentity<ApplicationUsers>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.SignIn.RequireConfirmedEmail = false;
}).AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDBContext>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

using(var scope = app.Services.CreateScope()){
   var services = scope.ServiceProvider;
    try
    {
        var DbContext = services.GetRequiredService<ApplicationDBContext>();
        DbContext.Database.Migrate();

        var seedTask = SeedData.CreateRoles(services);
    }
    catch
    {
        throw;
    }
}

if(app.Environment.IsDevelopment()){
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();


app.MapGet("/", () => "Hello World!");

app.MapRazorPages();

app.Run();

