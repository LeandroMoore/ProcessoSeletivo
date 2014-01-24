using System;
using System.Text;
using System.Collections.Generic;


namespace ProcessoSeletivo.Models
{

    public class Produto
    {
        public virtual long idProduto { get; set; }
        public virtual string DescricaoProduto { get; set; }
        public virtual decimal? Preco { get; set; }
    }
}
