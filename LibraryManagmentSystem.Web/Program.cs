using LibraryManagmentSystem.BLL.AutoMapper;
using LibraryManagmentSystem.BLL.BuisnessMapper;

using LibraryManagmentSystem.DAL;
using LibraryManagmentSystem.BLL;
using LibraryManagmentSystem.BLL.Services;
using LibraryManagmentSystem.DAL.Repos;
using Microsoft.EntityFrameworkCore;
using static LibraryManagmentSystem.DAL.Interfaces.Interfaces;
using Microsoft.AspNetCore.Authorization;
using static LibraryManagmentSystem.BLL.Interfaces.Interfaces;


namespace LibraryManagmentSystem.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // DBContext 
            builder.Services.AddDbContext<LibraryDBContext>(options => options.UseInMemoryDatabase("LibraryDB"));

            // Author 
            builder.Services.AddScoped<IAuthorRepository, AuthorRepo>();
            builder.Services.AddScoped<IAuthorService, AuthorService>();

            // Book 
            builder.Services.AddScoped<IBookRepository, BookRepo>();
            builder.Services.AddScoped<IBookService, BookService>();

            // Library 
            builder.Services.AddScoped<ILibraryRepository, LibraryRepo>();
            builder.Services.AddScoped<ILibraryService, LibraryService>();

            // AutoMapper
            builder.Services.AddAutoMapper(typeof(WebMapper).Assembly);
            builder.Services.AddAutoMapper(typeof(BuisnessMapper).Assembly);



            var app = builder.Build();

            //Dummy Data For Db Initialization
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<LibraryDBContext>();
                DbInitializer.Initialize(context); 
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=library}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
