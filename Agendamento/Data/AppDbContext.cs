using Microsoft.EntityFrameworkCore;
using Agendamento.Models;

namespace Agendamento.Data
{
    // Representa a conexão entre a aplicação e o banco de dados.
    // Por meio desta classe, o Entity Framework Core consulta
    // e modifica os dados armazenados.
    public class AppDbContext:DbContext
    {
        // Recebe as configurações do contexto por injeção de dependência,
        // como o provedor e a string de conexão com o banco de dados.
        // O método base(options) envia essas configurações para DbContext.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Representa a tabela de médicos no banco de dados.
        // Permite consultar, adicionar, alterar e excluir médicos.
        // Para adicionar outra tabela ao banco,
        // basta criar outro DbSet com a entidade correspondente.
        public DbSet<Medico> Medicos { get; set; }

    }
}
