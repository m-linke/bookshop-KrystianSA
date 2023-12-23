using BookShop.Domain;
using BookShop.Infrastructure.Context;
using BookShop.Infrastructure.Handlers.Commands;
using BookShop.Infrastructure.Handlers.Queries;
using BookShop.Infrastructure.Repositories;
using BookShop.Infrastructure.Validations;
using BookShop.Models;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookShop.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<ShopDbContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddTransient<AuthorRepository>();
            services.AddTransient<CreateAuthorCommandHandler>();
            services.AddTransient<GetAuthorListQueryHandler>();
            services.AddTransient<BookRepository>();
            services.AddTransient<CreateBookCommandHandler>();
            services.AddTransient<UpdateAuthorBookCountCommandHandler>();
            services.AddTransient<GetBookListQueryHandler>();
            services.AddScoped<IValidator<AuthorModel>, AuthorValidator>();
            services.AddScoped<IValidator<BookModel>, BookValidator>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Authors}/{action=AuthorList}/{id?}");
            });
        }
    }
}