using SwiftBuy.DTO;
using SwiftBuy.Enums;
using System.ComponentModel.DataAnnotations;

namespace SwiftBuy.Model
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O telefone deve ter 11 dígitos!")]
        public string Telefone { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "O e-mail deve ser válido!")]
        public string Email { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 dígitos!")]
        public string CPF { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "A senha deve ter entre 8 e 20 caracteres.")]
        public string Senha { get; set; }
        [Required]
        public PerfilEnum Tipo { get; set; }
        public List<PedidoModel> Pedidos { get; set; } = new();

        public UsuarioModel(UsuarioDTO usuarioDTO)
        {
            Nome = usuarioDTO.Nome;
            Telefone = usuarioDTO.Telefone;
            Email = usuarioDTO.Email;
            Tipo = usuarioDTO.Tipo;
            CPF = usuarioDTO.CPF;
        }
        public UsuarioModel() { }
    }
}
