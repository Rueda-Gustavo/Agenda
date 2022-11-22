using Agenda.Security.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Infra.Models.Eventos
{
    public class Evento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do evento é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Data do evento é obrigatória")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Descrição do evento é obrigatória")]
        public string Descricao { get; set; }

        public string CodigoCorEvento { get; set; }
        
        public UsuarioTeste? Usuario { get; set; }
    }
}
