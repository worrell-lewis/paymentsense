using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Paymentsense.Coding.Challenge.Api.Configuration;
using Paymentsense.Coding.Challenge.Api.Http;
using Paymentsense.Coding.Challenge.Api.Http.Interfaces;

namespace Paymentsense.Coding.Challenge.Api
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
            services.Configure<Config>(Configuration.GetSection("AppSettings"));
            ConfigureAppSettings(services);
            services.AddHttpClient<ICountryClient, CountryClient>();
            services.AddControllers();
            services.AddHealthChecks();
            services.AddCors(options =>
            {
                options.AddPolicy("PaymentsenseCodingChallengeOriginPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors("PaymentsenseCodingChallengeOriginPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }

        private void ConfigureAppSettings(IServiceCollection services)
        {
            services.Configure<Config>(config =>
            {
                config.CountryApi = Configuration.GetValue<string>("COUNTRY_API");
            });
        }
    }
}
