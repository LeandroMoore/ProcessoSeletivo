using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProcessoSeletivo.Models
{
    public class ProdutoCategoria
    {
        public virtual long idProdCat { get; set; }

        public virtual long idProduto { get; set; }
        [ForeignKey("idProduto")]
        public virtual Produto Produto { get; set; }

        public virtual long idCategoria { get; set; }
        [ForeignKey("idCategoria")]
        public virtual Categoria Categoria { get; set; }
    }
}
