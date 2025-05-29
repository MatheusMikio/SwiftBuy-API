using SwiftBuy.Enums;

namespace SwiftBuy.DTO.Usuario
{
    public class UsuarioDTOSaida
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public PerfilEnum Tipo { get; set; }
    }
}