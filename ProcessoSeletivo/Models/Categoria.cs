using System;
using System.Text;
using System.Collections.Generic;


namespace ProcessoSeletivo.Models
{

    public class Categoria
    {
        public virtual long Idcategoria { get; set; }
        public virtual string Descricaocategoria { get; set; }
        public virtual long? Idcategoriapai { get; set; }
    }
}
