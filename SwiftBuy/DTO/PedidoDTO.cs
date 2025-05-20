namespace SwiftBuy.DTO
{
    public class PedidoDTO
    {
        public int UsuarioId { get; set; }
        public string[] produtos { get; set; }
        public DateTime HoraPedido { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
