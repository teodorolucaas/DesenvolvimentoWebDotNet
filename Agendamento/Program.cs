using Agendamento.Data;
using Microsoft.EntityFrameworkCore;

namespace Agendamento
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Registra o AppDbContext na injeção de dependência, configura o PostgreSQL e obtém a string de conexão "DefaultConnection"
            // do appsettings.json.
            builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(
                builder.Configuration.GetConnectionString("DefaultConnection")));

            // Registra o SeedingService na injeção de dependência.
            // AddScoped cria uma instância do serviço para cada escopo/requisição.
            builder.Services.AddScoped<SeedingService>();

            var app = builder.Build();

            // Verifica se a aplicação não está sendo executada
            // no ambiente de produção.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else //se estiver em ambiente de desenvolvimento
            {
                // Cria manualmente um escopo de injeção de dependência.
                // Isso é necessário porque o SeedingService e o AppDbContext
                // foram registrados como serviços Scoped.
                using (var scope = app.Services.CreateScope())
                {
                    // Obtém uma instância do SeedingService dentro do escopo criado.
                    // O AppDbContext também será fornecido automaticamente
                    // ao construtor do SeedingService.
                    var seedingService = scope.ServiceProvider
                        .GetRequiredService<SeedingService>();

                    // Executa o método responsável por adicionar os dados iniciais.
                    seedingService.Popula();
                }
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
