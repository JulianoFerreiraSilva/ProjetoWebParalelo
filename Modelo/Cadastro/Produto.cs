using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Modelo.Cadastro
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string CodBarra { get; set; }
        public string Perfil { get; set; }

        [ForeignKey("FabricanteId")]
        public int FabricanteId { get; set; }
        public virtual Fabricante Fabricante { get; set; }

        public virtual ICollection<Estoque> EstoqueProduto { get; set; }
        public virtual ICollection<ProdutoFornecedor> ProdutosFornecedores { get; set; }
        public virtual ICollection<EntradaMercadoria> EntradaMercadoria { get; set; }
    }
}
