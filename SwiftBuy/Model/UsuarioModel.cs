using SwiftBuy.DTO;
using SwiftBuy.Enums;
using System.ComponentModel.DataAnnotations;

namespace SwiftBuy.Model
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Senha { get; set; }
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
