using System.ComponentModel.DataAnnotations;

namespace FutApi
{
    public class Time
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cidade { get; set; }
        public int TitulosBrasileiros { get; set; }
        public int TitulosMundiais { get; set; }
    }
}