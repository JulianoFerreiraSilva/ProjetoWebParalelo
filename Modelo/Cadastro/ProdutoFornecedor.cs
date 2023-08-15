
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Modelo.Cadastro
{
    [Table("ProdutosFornecedores")]
    public class ProdutoFornecedor
    {
        [Key]
        public int ProdFornecedorId { get; set; }
        public int ProdutoId { get; set; }
        public int FornecedorId { get; set; }
        public int CodProdutoFornecedor { get; set; }

        public Produto Produto { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public EntradaMercadoria EntradaMercadoria { get; set; }
    }
}
