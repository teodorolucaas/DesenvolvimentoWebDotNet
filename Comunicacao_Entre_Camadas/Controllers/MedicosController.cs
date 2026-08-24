using Comunicacao_Entre_Camadas.Models;
using Microsoft.AspNetCore.Mvc;

namespace Comunicacao_Entre_Camadas.Controllers
{
    public class MedicosController : Controller
    {
        public IActionResult Index()
        {
            // Cria o primeiro objeto do tipo Medico
            Medico medico1 = new Medico
            {
                Id = 1,
                Nome = "Ana Souza",
                Crm = "12345",
                Especialidade = "Cardiologia"
            };

            // Cria o segundo objeto do tipo Medico
            Medico medico2 = new Medico
            {
                Id = 2,
                Nome = "Carlos Lima",
                Crm = "67890",
                Especialidade = "Ortopedia"
            };

            // Cria uma lista que armazenará objetos do tipo Medico
            List<Medico> medicos = new List<Medico>();

            // Adiciona os objetos criados à lista
            medicos.Add(medico1);
            medicos.Add(medico2);

            // Envia a lista de médicos para a View
            return View(medicos);
        }
    }
}
