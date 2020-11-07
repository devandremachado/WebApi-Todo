using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Todo.Domain.Handlers;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Infra.Repositories;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("DataBase"));
            services.AddDbContext<DataContext>(opt => 
                opt.UseSqlServer(Configuration.GetConnectionString("connectionstring")));


            //AddScoped - Cria uma instancia para cada requisição, porém, a primeira instancia fica na memoria para as proximas a utilizarem e não ficar sempre criando uma nova (bom uso é a conexão com banco de dados, cria uma e reaproveita)
            //AddTransient - Cria sempre uma nova instancia para cada requisição, diferente do Scoped, nao usa da memoria, sempre vai criar um novo (bom uso é Interface x Implementação) 
            //AddSingleton - Cria apenas uma instancia em toda aplicação e a utiliza em todas requests (esse modelo é raramente usado)
            services.AddTransient<ITodoRepository, TodoRepository>();
            services.AddTransient<TodoHandler, TodoHandler>();

            // Autenticacao JWT Bearer via Google
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://secureToken.google.com/balta7196todo";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true, // validar quem está mandando o token? Sim!
                        ValidIssuer = "https://securetoken.google.com/balta7196todo", //Como validar? - Neste google
                        ValidateAudience = true, // Validar o app? Sim
                        ValidAudience = "balta7196todo", // Nome do App
                        ValidateLifetime = true // valida o tempo de vida do Token? Sim
                    };
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
