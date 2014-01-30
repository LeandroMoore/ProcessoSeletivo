using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ProcessoSeletivo.Models
{

    public class Categoria {
        public Categoria() {
            Produtos = new List<Produto>();
        }
        public virtual long idCategoria { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(150)]
        public virtual string DescricaoCategoria { get; set; }
        public virtual long? idCategoriaPai { get; set; }
        ///public virtual IList<ProdutoCategoria> ProdutoCategoria { get; set; }
        ///
        public virtual IList<Produto> Produtos { get; set; }
    }
}
