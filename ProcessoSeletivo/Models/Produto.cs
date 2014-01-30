using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ProcessoSeletivo.Models
{

    public class Produto
    {
        public Produto()
        {
            Categorias = new List<Categoria>(); 
        }
        public virtual long idProduto { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        [StringLength(150)]
        public virtual string DescricaoProduto { get; set; }
        public virtual decimal? Preco { get; set; }
        //public virtual IList<ProdutoCategoria> ProdutoCategoria { get; set; }

        public virtual IList<Categoria> Categorias { get; set; }               
    }
}
