using BusinessOperations.Services;
using BusinessOperations.TokenService;
using DataAccess.Context;
using DataAccess.Repository;
using DataAccess.Repository.JWT_UserRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace BillingAPI
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public static IConfiguration StaticConfig { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            StaticConfig = configuration;

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSession();
            services.AddControllers();

            //*********************** Swagger API Documentation ******************//
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BillingAPI", Version = "v1" });
            });

            //*********************** Register Connection String ******************//
            services.AddDbContext<ApplicationContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DbContextBilling"))
           );

            //*********************** Register Services ******************//
            services.AddScoped<IDapperService, DapperService>();
            services.AddScoped(typeof(IRepositoryEF<>), typeof(RepositoryEF<>));

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();

            //*********************** JWT  ******************//

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                 {
                var serverSecret = new SymmetricSecurityKey(Encoding.UTF8.
                 GetBytes(Configuration["JWT:key"]));
                 options.TokenValidationParameters = new
             TokenValidationParameters
              {
                IssuerSigningKey = serverSecret,
                ValidIssuer = Configuration["JWT:Issuer"],
                ValidAudience = Configuration["JWT:Audience"]
                };
              });





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BillingAPI v1"));
            }



            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
