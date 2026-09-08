using System.ComponentModel.DataAnnotations;

namespace Agendamento.Models
{
    public class Medico
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Nome { get; set; }

        [Required]
        [MaxLength(15)]
        public string? Crm { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Especialidade  { get; set; }
    }
}
