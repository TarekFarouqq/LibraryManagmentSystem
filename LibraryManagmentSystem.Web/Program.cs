using LibraryManagmentSystem.BLL.AutoMapper;
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

            // AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

            var app = builder.Build();

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
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
