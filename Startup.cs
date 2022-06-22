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
        private readonly string[] _origin_Allowed = { "http://localhost:4200", "https://localhost:4200", "https://localhost:44307" };
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
                builder.AllowAnyOrigin() //WithOrigins("http://localhost:4200", "https://localhost:4200", "https://localhost:44307")
                .AllowAnyMethod()
                .WithHeaders("X-XSRF-TOKEN", "content-type"); //; .AllowAnyHeader();
            }));
           
            services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TodoApi", Version = "v1" });
                c.OperationFilter<XsfrHeaderSW>();
            });

       


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

            app.Use(async (context, next) =>
            {
                /*
                         _antiforgery = app.ApplicationServices.GetRequiredService<IAntiforgery>();
                         var tokens = _antiforgery.GetTokens(context);
                         context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken, new CookieOptions() { HttpOnly = false }); 
         */
                context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'; form-action 'self'");
                context.Response.Headers.Add("Referrer-Policy", "strict-origin-when-cross-origin");
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
                context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
                context.Response.Headers.Add("Strict-Transport-Security", "max-age=63072000; includeSubDomains; preload");


                //   return next();
                await next();
            });

            //   quizas sea mejor trabajar sobre user agent (que no es bueno para nadie), que si viene desde postman, no se desde curl






            app.UseHttpsRedirection();
          
            app.PLXAntiforgeryTokens(); // la puse este bonito y propietario nombre para la implemntaci+on 
            app.UseRouting();
            app.UseCors(_policyName);  // despues se puede usar por metodo como atributo en el controlador

            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
            //cosas locas si pongo esto debajo del if deja de funcionar
            string referer = context.Request.Headers["Referer"].ToString();

       //         if (_origin_Allowed.Any(origin => referer.StartsWith(origin, StringComparison.OrdinalIgnoreCase)))
         //       {
                    _antiforgery = app.ApplicationServices.GetRequiredService<IAntiforgery>();
                    var tokens = _antiforgery.GetAndStoreTokens(context);//GetTokens(context);
                context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken, new CookieOptions() { HttpOnly = false });
                    await next();
           //    }
            });

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
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors(_policyName);
            });
        }
    }
}
