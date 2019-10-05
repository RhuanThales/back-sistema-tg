﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using back_sistema_tg.BLL;
using back_sistema_tg.BLL.Exceptions;
using back_sistema_tg.DAL.DAO;
using back_sistema_tg.Extensions;
using back_sistema_tg.Extensions.Filters;
using back_sistema_tg.Utils;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using NLog;
using Swashbuckle.AspNetCore.Swagger;

namespace back_sistema_tg
{
    public class Startup
    {
        private readonly MapperConfiguration _mapperConfiguration;
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

            // AUTOMAPPER PARA MAPEAR DTO E MODEL
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<Configuracoes>(
                options =>
                {
                    options.ConnectionString =
                        Configuration.GetSection("MongoDb:ConnectionString").Value;
                    options.Database = Configuration.GetSection("MongoDb:Database").Value;
                });

            services.AddSingleton<IMongoClient, MongoClient>(
                _ => new MongoClient(Configuration.GetSection("MongoDb:ConnectionString").Value));

            services.AddMvc(options => 
            {
                options.Filters.Add(new ApiValidationFilterAttribute());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // JWT
            services.AddAuthentication(o =>
            {
                o.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                o.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                // options.AccessDeniedPath = new PathString("/Account/Login/");
                // options.LoginPath = new PathString("/Account/Login/");
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HJaM5dvQy5WUEQ6LPR7yRrcO4m2Mse4u94FMsgXtMjrc66XeM34sdPWQ2ilEA9fo")),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromDays(1)
                };
            });

            // Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Sistema de Gerênciamento do TG 04-013",
                        Version = "v1",
                        Description = "Sistema de Gerênciamento do TG 04-013",
                        Contact = new Contact
                        {
                            Name = "TG 04-013"
                        }
                    });
            });    

            // Log
            services.AddSingleton<ILoggerManager, LoggerManager>();

            // AUTOMAPPER
            services.AddSingleton(sp => _mapperConfiguration.CreateMapper());

            // DI
            services.AddScoped<IMongoContext, MongoContext>();

            services.AddScoped<IUsuarioDAO, UsuarioDAO>();
            services.AddScoped<IUsuarioBll, UsuarioBll>();

            services.AddScoped<IAtiradorDAO, AtiradorDAO>();
            services.AddScoped<IAtiradorBll, AtiradorBll>();

            services.AddScoped<IOficialDAO, OficialDAO>();
            services.AddScoped<IOficialBll, OficialBll>();

            services.AddScoped<IEscalaDAO, EscalaDAO>();
            services.AddScoped<IEscalaBll, EscalaBll>();

            services.AddScoped<SeedingService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeedingService seedingService, ILoggerManager logger)
        {
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                seedingService.Seed();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sistema de Gerênciamento do TG 04-013");
            });

            // Middleware
            app.ConfigureCustomExceptionMiddleware();
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
