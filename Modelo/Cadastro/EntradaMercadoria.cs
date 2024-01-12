using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Modelo.Cadastro
{
    [Table("Entrada")]
    public class EntradaMercadoria
    {
        [Key]
        public int EntradaId { get; set; }

        [Required]
        public DateTime DataEntrada { get; set; }

        [ForeignKey("EntradaProdutoId")]
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }

        [ForeignKey("EntradaEstoqueId")]
        public int EstoqueId { get; set; }
        public virtual Estoque Estoque { get; set; }

        [Required]
        public int QuantidadeEntrada { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal ValorUnitario { get; set; }

        [ForeignKey("EntradaFornecedorId")]
        public int FornecedorId { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
       
        [Column(TypeName = "money")]
        public decimal ValorTotal { get; set; }

    }
}
