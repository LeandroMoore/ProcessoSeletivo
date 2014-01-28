﻿using System;
using System.Text;
using System.Collections.Generic;


namespace ProcessoSeletivo.Models
{

    public class Produto
    {
        public Produto()
        {
            //ProdutoCategoria = new List<ProdutoCategoria>();

            Categorias = new List<Categoria>(); 
        }
        public virtual long idProduto { get; set; }
        public virtual string DescricaoProduto { get; set; }
        public virtual decimal? Preco { get; set; }
        //public virtual IList<ProdutoCategoria> ProdutoCategoria { get; set; }

        public virtual IList<Categoria> Categorias { get; set; }               
    }
}
