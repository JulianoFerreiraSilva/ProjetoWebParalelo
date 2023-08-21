using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Cadastro
{
    public class EntradaMercadoria
    {
        public int EntradaId { get; set; }

        public int ProdutoId { get; set; }

        public int EstoqueId { get; set; }

        public int FornecedorId { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

        public decimal ValorProduto { get; set; }

        public int Quantidade { get; set; }

        public decimal ValorTotal { get; set; }

        public virtual ICollection<Produto> Produto { get; set; }
        public virtual ICollection<Estoque> Estoque { get; set; }
    }
}
