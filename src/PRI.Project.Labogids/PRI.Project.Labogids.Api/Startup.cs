using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PRI.Project.Labogids.Core.Entities;
using PRI.Project.Labogids.Core.Interfaces.Repositories;
using PRI.Project.Labogids.Core.Interfaces.Services;
using PRI.Project.Labogids.Core.Services;
using PRI.Project.Labogids.Infrastructure.Data;
using PRI.Project.Labogids.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PRI.Project.Labogids.Api
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
            //configure identity
            services.AddIdentity<ApplicationUser, IdentityRole>(
                options =>
                {
                    //only in development
                    options.SignIn.RequireConfirmedEmail = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 3;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddHttpContextAccessor();
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("LabGuideDatabase")));
            services.AddCors(options =>
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            }));

            //authentication - authorization
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateActor = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = Configuration["JWTConfiguration:Issuer"],
                        ValidAudience = Configuration["JWTConfiguration:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWTConfiguration:SigninKey"]))
                    };
                });

            services.AddAuthorization( options =>
            {
                options.AddPolicy("admin", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "admin");
                });
                options.AddPolicy("user", policy =>
                {
                    policy.RequireAssertion(context =>
                    {
                        if (context.User.HasClaim(ClaimTypes.Role, "admin")
                        || context.User.HasClaim(ClaimTypes.Role, "user"))
                        {
                            return true;
                        }
                        return false;
                    });
                });
            });

            //repositories
            services.AddScoped<ILaboratoryRepository, LaboratoryRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IReferenceValueRepository, ReferenceValueRepository>();
            services.AddScoped<IRequestDefinitionRepository, RequestDefinitionRepository>();
            services.AddScoped<ISpecimenRepository, SpecimenRepository>();
            services.AddScoped<IStorageConditionRepository, StorageConditionRepository>();
            
            //services
            services.AddScoped<ILaboratoryService, LaboratoryService>();
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<IReferenceValueService, ReferenceValueService>();
            services.AddScoped<IRequestDefinitionService, RequestDefinitionService>();
            services.AddScoped<ISpecimenService, SpecimenService>();
            services.AddScoped<IStorageConditionService, StorageConditionService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IUserService, UserService>();

            services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                x.JsonSerializerOptions.IgnoreNullValues = true;
            });

            services.AddSwaggerGen(c => {
                {
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "Enter the token below:"
                    });
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                         {
                               new OpenApiSecurityScheme
                                 {
                                     Reference = new OpenApiReference
                                     {
                                         Type = ReferenceType.SecurityScheme,
                                         Id = "Bearer"
                                     }
                                 },
                                 new string[] {}
                         }
                    });
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "cu.ApiBasics.Lesvoorbeeld.Avond.Api", Version = "v1" });
                }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PRI.Project.Labogids.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
