using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Modelo.Cadastro
{
    [Table("Fornecedores")]
    public class Fornecedor
    {
        public int FornecedorId { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }

        public virtual ICollection<ProdutoFornecedor> ProdutosFornecedores { get; set; }
        public virtual ICollection<EntradaMercadoria> EntradaMercadoria { get; set; }
    }
}
