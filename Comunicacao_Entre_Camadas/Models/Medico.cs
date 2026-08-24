namespace Comunicacao_Entre_Camadas.Models
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty; //Esse comando atribui uma string vazia para o atributo 
        public string Crm { get; set; } = string.Empty;
        public string Especialidade { get; set; } = string.Empty;
    }
}
