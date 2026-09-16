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
            return _context.Medicos.OrderBy(m => m.Id).ToList(); 

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

        // Procura um médico no banco de dados utilizando seu identificador.
        // O parâmetro id representa o identificador do médico procurado.
        public Medico? EncontrarId(int id)
        {
            // O método Find() procura um registro pela chave primária.
            // Retorna o médico encontrado ou null caso ele não exista.
            return _context.Medicos.Find(id);
        }


        // Remove um médico do banco de dados.
        // O parâmetro id representa o identificador do médico que será removido.
        public void Remover(int id)
        {
            // Procura o médico no banco de dados utilizando sua chave primária.
            var obj = _context.Medicos.Find(id);

            // Verifica se foi encontrado um médico com o identificador informado.
            // Caso não exista, encerra o método sem realizar nenhuma operação.
            if (obj == null)
            {
                return;
            }

            // Marca o médico encontrado para remoção.
            // A alteração ainda não foi gravada definitivamente no banco.
            _context.Medicos.Remove(obj);

            // Confirma as alterações pendentes.
            // O Entity Framework Core gera e executa o comando DELETE.
            _context.SaveChanges();
        }


        // Atualiza os dados de um médico no banco de dados.
        // O parâmetro obj representa o médico recebido pela controller.
        public void Atualizar(Medico obj)
        {
            // Marca o objeto como modificado no contexto.
            // A alteração ainda não foi gravada definitivamente no banco.
            _context.Medicos.Update(obj);

            // Confirma as alterações pendentes.
            // O Entity Framework Core gera e executa o comando UPDATE.
            _context.SaveChanges();
        }

    }
}
