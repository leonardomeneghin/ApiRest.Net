using ApiRest.Net.Business;
using ApiRest.Net.Business.implementations;
using ApiRest.Net.Model.Context;
using ApiRest.Net.Repository;
using ApiRest.Net.Repository.implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace ApiRest.Net
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllers();

            var con = Configuration["SQLServerConnection:SQLServerConnectionString"];
            services.AddDbContext<SQLServerContext>(options => options.UseSqlServer(con));
            //Migration
            if (Environment.IsDevelopment())
            {
                MigrateDatabase(con);
            }

            //ContentNegotiation
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true; //Aceitará o headers das solicitações
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", "application/json");
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", "application/xml");

            })
                .AddJsonOptions(options => 
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                })
                .AddXmlSerializerFormatters();

            //Adicionando o versioning API
            services.AddApiVersioning();

            //Injeção de dependências, a (Interface, Implementação do serviço)
            services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
            services.AddScoped<IBookBusiness, BooksBusinessImplementation>();
            services.AddScoped<IPlayerDataBusiness, PlayerDataImplementationBusiness>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepositoryImplementation<>));
            services.AddScoped(typeof(IGenericRepository2<>), typeof(GenericRepositoryImplementation2<>));
        }

      



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void MigrateDatabase(string con)
        {
            try
            {
                var evolveConnection = new SqlConnection(con);
                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { 
                        "db/migrations",
                        "db/datasets" 
                    }, //Lista de diretórios para o evolve
                    IsEraseDisabled = true,
                };
                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error("Database migration failed", ex);
                throw;
            }
        }

    }
}
