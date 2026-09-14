using System.ComponentModel.DataAnnotations;

namespace Agendamento.Models
{
    public class Medico
    {
        // Identificador único do médico.
        // O Entity Framework Core utiliza essa propriedade como chave primária da tabela.
        public int Id { get; set; }

         
        [Required] // Indica que o nome é obrigatório.
        [MaxLength(100)] // Define que o nome pode ter, no máximo, 100 caracteres.
        public string? Nome { get; set; }

        
        [Required] // Indica que o CRM é obrigatório.
        [MaxLength(15)] // Define que o CRM pode ter, no máximo, 15 caracteres.
        public string? Crm { get; set; }

        
        [Required] // Indica que a especialidade é obrigatória.
        [MaxLength(50)] // Define que a especialidade pode ter, no máximo, 50 caracteres.
        public string? Especialidade { get; set; }
    }
}
