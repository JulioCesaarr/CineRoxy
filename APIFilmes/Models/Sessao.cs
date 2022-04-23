using System;
using System.ComponentModel.DataAnnotations;

namespace APIFilmes.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public virtual Cinema cinema { get; set; }
        public virtual Filme filme { get; set; }
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }

        public DateTime HorarioDeEncerramento { get; set; } 
    }
}
