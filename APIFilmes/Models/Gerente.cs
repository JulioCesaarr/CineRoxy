using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIFilmes.Models
{
    public class Gerente
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        [JsonIgnore]
        public virtual List<Cinema> Cinemas { get; set; }
    }
}
