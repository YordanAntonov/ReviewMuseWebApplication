namespace ReviewMuse.Web
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using ReviewMuse.Data;
    using ReviewMuse.Data.Models;
    using ReviewMuse.Services.AuthorService;
    using ReviewMuse.Services.BookService;
    using ReviewMuse.Services.CategoryService;
    using ReviewMuse.Services.Contracts;
    using ReviewMuse.Services.EditorService;
    using ReviewMuse.Services.ReviewService;
    using ReviewMuse.Services.UserService;
    using ReviewMuse.Web.Infrastructure.ModelBinders;
    using ReviewMuse.Web.Infrastructure.Extensions;

    using static ReviewMuse.Common.GeneralConstants;

    using Stripe;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ReviewMuseDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                //SignIn options:
                options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");

                //Password options:
                options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
                options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                options.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");

                //Lockout options:
                options.Lockout.MaxFailedAccessAttempts = builder.Configuration.GetValue<int>("Identity:Lockout:MaxFailedAccessAttempts");

            })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<ReviewMuseDbContext>();

            builder.Services
                .AddControllersWithViews()
                .AddMvcOptions(options =>
                {
                    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                });

            //Services
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IEditorService, EditorService>();
            builder.Services.AddScoped<IReviewService, Services.ReviewService.ReviewService>();
            builder.Services.AddScoped<IAuthorService, AuthorService>();
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IUserService, UserService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();

            app.UseAuthentication();
            app.UseAuthorization();

            if (app.Environment.IsDevelopment())
            {
                app.SeedAdministrator(FirstAdminSeedEmail);
            }

            app.UseEndpoints(config =>
            {
                config.MapControllerRoute(
                    name: "areas",
                    pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                config.MapControllerRoute(
                    name: "ProtectingUrlRoute",
                    pattern: "/{controller}/{action}/{id}/{information}",
                    defaults: new { Controller = "Category", Action = "Details" });

                config.MapDefaultControllerRoute();

                config.MapRazorPages();
            });

            app.Run();
        }
    }
}