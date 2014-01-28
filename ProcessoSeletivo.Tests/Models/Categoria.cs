using System;
using System.Text;
using System.Collections.Generic;


namespace ProcessoSeletivo.Models
{

    public class Categoria {
        public Categoria() {
            ProdutoCategoria = new List<ProdutoCategoria>();
        }
        public virtual long idCategoria { get; set; }
        public virtual string DescricaoCategoria { get; set; }
        public virtual long? idCategoriaPai { get; set; }
        public virtual IList<ProdutoCategoria> ProdutoCategoria { get; set; }
    }
}
