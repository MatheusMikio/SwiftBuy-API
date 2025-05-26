using System.ComponentModel.DataAnnotations;

namespace SwiftBuy.Model
{
    public class ImagemModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UrlImagem { get; set; }
        public int ProdutoId { get; set; }
        public ProdutoModel Produto { get; set; }

        public ImagemModel() { }
    }
}