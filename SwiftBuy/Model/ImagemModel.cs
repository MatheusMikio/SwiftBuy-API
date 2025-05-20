using System.ComponentModel.DataAnnotations;

namespace SwiftBuy.Model
{
    public class ImagemModel
    {
        [Key]
        public int Id { get; set; }
        public string ? UrlImagem { get; set; }
        public string ? ImagemThumb { get; set; }
        [Required]
        public int ProdutoId { get; set; }
        public bool Principal { get; set; }
        public ProdutoModel Produto { get; set; }

        public ImagemModel() { }
    }
}