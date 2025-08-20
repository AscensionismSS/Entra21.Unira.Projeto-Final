using Cultura.Domain.Entities;
using System.Text.Json.Serialization;


namespace Cultura.Domain.Entities
{
    public class Evento
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataRegistro { get; set; }

        public int CategoriaId { get; set; }
        public int UsuarioId { get; set; } // Representa o organizador
        public int EnderecoId { get; set; }

        [JsonIgnore]
        public Categoria Categoria { get; set; }

        [JsonIgnore]
        public Usuario Usuario { get; set; } // Organizador

        [JsonIgnore]
        public Endereco Endereco { get; set; }

        [JsonIgnore]
        public ICollection<Ingresso> Ingressos { get; set; }
    }

}