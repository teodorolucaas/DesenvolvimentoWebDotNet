using Agendamento.Data;
using Agendamento.Models;
using Agendamento.Services;
using Microsoft.AspNetCore.Mvc;

namespace Agendamento.Controllers
{
    // A classe MedicoController recebe as requisições relacionadas aos médicos.
    //
    // Ela utiliza o MedicoService para solicitar as operações da aplicação
    // e retorna as views que serão apresentadas ao usuário.
    public class MedicoController : Controller
    {
        // Armazena uma referência para o serviço responsável pelas
        // operações relacionadas aos médicos.
        private readonly MedicoService _medicoService;

        // Recebe o MedicoService por Injeção de Dependência.
        // O ASP.NET Core fornece uma instância do serviço ao criar a controller.
        public MedicoController(MedicoService medicoService)
        {
            // Armazena o serviço para que ele possa ser utilizado
            // pelas ações da controller.
            _medicoService = medicoService;
        }

        // Recebe a requisição para a página de listagem de médicos.
        public IActionResult Index()
        {
            // Solicita ao serviço todos os médicos cadastrados.
            var listaMedicos = _medicoService.Listar();

            // Envia a lista recebida para a view Index.cshtml.
            return View(listaMedicos);
        }

        // Recebe uma requisição GET para abrir a tela de inserção.
        public IActionResult Inserir()
        {
            // Retorna a view Inserir.cshtml, que contém o formulário.
            return View();
        }

        // Indica que esta ação será executada quando o formulário
        // enviar os dados utilizando o método HTTP POST.
        [HttpPost]
        public IActionResult Inserir(Medico medico)
        {
            // Recebe o objeto Medico preenchido com os dados enviados
            // pelos campos do formulário e solicita sua inserção ao serviço.
            _medicoService.Inserir(medico);

            // Redireciona o usuário para a ação Index(), carregando
            // novamente a listagem após a inserção.
            return RedirectToAction(nameof(Index));
        }
    }
}
