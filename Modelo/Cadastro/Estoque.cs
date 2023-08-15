using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Modelo.Cadastro
{
    public class Estoque
    {
        [Key]
        public int EstoqueId { get; set; }

        public int? Quantidade { get; set; }
        [Column(TypeName = "money")]
        public decimal ValorUnitario { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
        [ForeignKey("IdEntrada")]
        public int EntradaId { get; set; }
        public virtual EntradaMercadoria EntradaMercadoria { get; set; }

    }
}
