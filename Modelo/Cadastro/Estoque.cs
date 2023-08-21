using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Cadastro
{
    public class Estoque
    {
        [Key]
        public int EstoqueId { get; set; }

        public int? Quantidade { get; set; }
        [Column(TypeName = "money")]
        public decimal ValorUnitario { get; set; }

        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
