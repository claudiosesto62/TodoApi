using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Antiforgery;
using System;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace TodoApi
{
    public class Startup
    {
   
        private readonly string _policyName = "CorsPolicy"; //este nombre es para la aplicación del atributo

        //list de sitios permitidos se deberia leer de algun repositorio (appsetting, etc)
        private readonly string[] _origin_Allowed = { "https://localhost:4200", "https://localhost:44307" };
        private  IAntiforgery _antiforgery;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddCors(options => options.AddPolicy(_policyName, builder =>
            {
                builder.WithOrigins(_origin_Allowed)
                .AllowAnyMethod()
                .WithHeaders("x-csrf-token", "content-type"); //.AllowAnyHeader();
            }));
 
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TodoApi", Version = "v1" });
            });

            services.AddAntiforgery(options => options.HeaderName = "X-CSRF-TOKEN");
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi v1"));
            }
            
//            app.UseAntiforgeryTokens();


            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'; form-action 'self'");
                context.Response.Headers.Add("Referrer-Policy", "strict-origin-when-cross-origin");
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
                context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
                context.Response.Headers.Add("Strict-Transport-Security", "max-age=63072000; includeSubDomains; preload");

                await next();
            });
             //   quizas sea mejor trabajar sobre user agent (que no es bueno para nadie), que si viene desde postman, no se desde curl
    
            app.Use(async (context, next) =>
            {
                string referer = context.Request.Headers["Referer"].ToString(); 

                if (string.IsNullOrWhiteSpace(referer) || !_origin_Allowed.Any(origin => referer.StartsWith(origin, StringComparison.OrdinalIgnoreCase)))
                {
                    byte[] data = Encoding.ASCII.GetBytes("Not Recognized Request");
                    context.Response.StatusCode = 400;
                    await context.Response.Body.WriteAsync(data);
                    return;
                }
                await next();
            });

            _antiforgery = app.ApplicationServices.GetRequiredService<IAntiforgery>();

            app.Use((context, next) =>
            {
                string path = context.Request.Path.Value;

                if (string.Equals(path, "/", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(path, "/index.html", StringComparison.OrdinalIgnoreCase))
                {
                    // The request token can be sent as a JavaScript-readable cookie,
                    
                     var tokens = _antiforgery.GetAndStoreTokens(context);
                    context.Response.Cookies.Append("X-XSRF-TOKEN", tokens.RequestToken,
                        new CookieOptions() { HttpOnly = false });
                   
                }
                return next();
            });

            app.UseHttpsRedirection();
            //app.UseMiddleware<ValidateAntiForgeryTokenMiddleware>();
            app.PLXAntiforgeryTokens();
            app.UseRouting();
            app.UseCors(_policyName);  // despues se puede usar por metodo como atributo en el controlador

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors(_policyName);
            });
        }
    }
}
