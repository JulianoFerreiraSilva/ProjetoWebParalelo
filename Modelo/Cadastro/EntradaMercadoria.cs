using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Modelo.Cadastro
{
    [Table("EntradaMercadorias")]
    public class EntradaMercadoria
    {
        [Key]
        public int EntradaId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataEntrada { get; set; }
        public long? NotaFornecedor { get; set; }
        public string Produto { get; set; }
        public int? Quantidade { get; set; }
        [Column(TypeName = "money")]
        public decimal ValorUnitarioProduto { get; set; }
        [Column(TypeName = "money")]
        public decimal ValorTotalProduto { get; set; }
        [Column(TypeName = "money")]
        public decimal ValorTotalNota { get; set; }

        public virtual ICollection<ProdutoFornecedor> ProdutoFornecedor { get; set; }
        [ForeignKey("IdEstoque")]
        public int EstoqueId { get; set; }
        public virtual Estoque Estoque { get; set; }
    }
}
