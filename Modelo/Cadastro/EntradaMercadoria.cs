using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Modelo.Cadastro
{
    public class EntradaMercadoria
    {
        [Key]
        public int EntradaId { get; set; }
        [ForeignKey("ProdutoId")]
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        
        [ForeignKey("EstoqueId")]
        public int EstoqueId { get; set; }
        public virtual Estoque Estoque { get; set; }

        [ForeignKey("FornecedorId")]
        public int FornecedorId { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
       
        [Column(TypeName = "money")]
        public decimal ValorTotal { get; set; }

    }
}
