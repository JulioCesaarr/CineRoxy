using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Request
{
    public class SolicitaResetRequest
    {
        [Required]
        public string Email { get; set; }
    }
}
