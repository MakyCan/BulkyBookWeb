using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repositories.IRepositories;
using BulkyBook.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();//not needed for .NET 6.0

//Adding DI
//TODO: when running migrations, apply this command: 
//Add-Migration NewMigrationName -Project BulkyBook.DataAccess
builder.Services.AddDbContext<BulkyDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("BulkyBook.DataAccess")
));
//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); ==> no longer needed
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<DbContext, BulkyDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else 
{ 
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "area_route",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}"
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();

public partial class Program { }
