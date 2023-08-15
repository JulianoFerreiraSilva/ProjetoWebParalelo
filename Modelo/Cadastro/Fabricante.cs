using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Cadastro
{
    public class Fabricante
    {
        [Key]
        public int? FabricanteId { get; set; }
        public string Nome { get; set; }
        public string Nacionalidade { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
