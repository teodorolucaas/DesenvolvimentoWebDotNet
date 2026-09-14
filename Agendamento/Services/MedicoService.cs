using Agendamento.Data;
using Agendamento.Models;

namespace Agendamento.Services
{
    // A classe MedicoService centraliza as operações da aplicação
    // relacionadas aos médicos, como listar, inserir, atualizar e remover registros.
    //
    // A controller (MedicoController) solicita essas operações ao serviço
    // (MedicoService). Para acessar os dados, o serviço utiliza o AppDbContext,
    // que representa o contexto do banco de dados. O Entity Framework Core é
    // responsável por executar a comunicação com o banco de dados.
    public class MedicoService
    {
        // Armazena uma referência para o contexto do banco de dados.
        // O readonly impede que essa referência seja substituída após
        // a criação do objeto MedicoService.
        private readonly AppDbContext _context;

        // Recebe o AppDbContext por Injeção de Dependência.
        // O ASP.NET Core fornece automaticamente o contexto configurado
        // quando cria uma instância do MedicoService.
        public MedicoService(AppDbContext context)
        {
            // Armazena o contexto para que os métodos da classe possam
            // acessar a tabela de médicos no banco de dados.
            _context = context;
        }

        // Retorna todos os médicos cadastrados no banco de dados.
        public List<Medico> Listar()
        {
            // Acessa a tabela Medicos, executa a consulta e transforma
            // os registros retornados em uma lista de objetos Medico.
            return _context.Medicos.ToList();
        }

        // Insere um novo médico no banco de dados.
        // O parâmetro obj representa o médico recebido pela controller.
        public void Inserir(Medico obj)
        {
            // Adiciona o novo médico ao contexto.
            // A alteração ainda não foi gravada definitivamente no banco.
            _context.Medicos.Add(obj);

            // Confirma as alterações pendentes.
            // O Entity Framework Core gera e executa o comando INSERT.
            _context.SaveChanges();
        }
    }
}
