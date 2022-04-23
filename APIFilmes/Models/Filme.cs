using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIFilmes.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Necessario adicionar um titulo ao filme")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Campo DIRETOR deve ser preenchido!")]
        public string Diretor { get; set; }
        [StringLength(40, ErrorMessage = "Genero não pode conter mais de 40 caractéres.")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "A duração deve ter no minimo 1 e no máximo 600 minutos!")]
        public int duracao { get; set; }
        public int ClassificacaoEtaria { get; set; }

        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
    }
}
