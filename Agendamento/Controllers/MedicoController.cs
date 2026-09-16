using System.Diagnostics;
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
        [ValidateAntiForgeryToken]
        public IActionResult Inserir(Medico medico)
        {
            // Recebe o objeto Medico preenchido com os dados enviados
            // pelos campos do formulário e solicita sua inserção ao serviço.
            _medicoService.Inserir(medico);

            // Redireciona o usuário para a ação Index(), carregando
            // novamente a listagem após a inserção.
            return RedirectToAction(nameof(Index));
        }

        // Recebe o identificador do médico selecionado na listagem
        // e apresenta seus dados na página de detalhes.
        public IActionResult Detalhar(int? id)
        {
            // Verifica se um identificador foi informado na requisição.
            // Caso não tenha sido informado, retorna uma resposta 404.
            if (id == null)
            {
                return NotFound();
            }

            // Solicita ao serviço a busca do médico pelo identificador recebido.
            var obj = _medicoService.EncontrarId(id.Value);

            // Verifica se algum médico foi encontrado.
            // Caso não exista, retorna uma resposta 404.
            if (obj == null)
            {
                return NotFound();
            }

            // Envia o médico encontrado para a view Detalhar.
            return View(obj);
        }


        // Recebe o identificador do médico selecionado e apresenta
        // seus dados no formulário de edição.
        public IActionResult Editar(int? id)
        {
            // Verifica se um identificador foi informado na requisição.
            // Caso não tenha sido informado, retorna uma resposta 404.
            if (id == null)
            {
                return NotFound();
            }

            // Solicita ao serviço a busca do médico que será editado.
            var obj = _medicoService.EncontrarId(id.Value);

            // Verifica se o médico foi encontrado no banco de dados.
            // Caso não exista, retorna uma resposta 404.
            if (obj == null)
            {
                return NotFound();
            }

            // Envia o médico encontrado para a view Editar,
            // permitindo que o formulário seja preenchido com seus dados.
            return View(obj);
        }


        // Indica que esta ação será executada quando o formulário
        // de edição enviar os dados utilizando o método HTTP POST.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Medico medico)
        {
            // Recebe o objeto Medico preenchido com os dados enviados
            // pelo formulário e solicita sua atualização ao serviço.
            _medicoService.Atualizar(medico);

            // Redireciona o usuário para a ação Index(), carregando
            // novamente a listagem após a atualização.
            return RedirectToAction(nameof(Index));
        }


        // Recebe o identificador do médico selecionado e apresenta
        // seus dados na página de confirmação da remoção.
        public IActionResult Remover(int? id)
        {
            // Verifica se um identificador foi informado na requisição.
            // Caso não tenha sido informado, retorna uma resposta 404.
            if (id == null)
            {
                return NotFound();
            }

            // Solicita ao serviço a busca do médico que será removido.
            var obj = _medicoService.EncontrarId(id.Value);

            // Verifica se o médico foi encontrado no banco de dados.
            // Caso não exista, retorna uma resposta 404.
            if (obj == null)
            {
                return NotFound();
            }

            // Envia o médico encontrado para a view Remover,
            // permitindo que o usuário confira os dados antes da exclusão.
            return View(obj);
        }


        // Indica que esta ação será executada quando o formulário
        // de confirmação enviar os dados utilizando o método HTTP POST.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remover(int id)
        {
            // Recebe o identificador enviado pelo formulário e solicita
            // ao serviço a remoção do médico correspondente.
            _medicoService.Remover(id);

            // Redireciona o usuário para a ação Index(), carregando
            // novamente a listagem após a remoção.
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error(string message)
        {
            var errorViewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(errorViewModel);
        }

    }
}
