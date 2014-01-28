using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProcessoSeletivo;

namespace ProcessoSeletivo.Tests
{
    [TestClass]
    [DeploymentItem(@"Models","Models")]
    public class CatalogoTeste
    {
        [TestMethod]
        public void CadastrarCategoria()
        {

            Models.Categoria _Categoria = new Models.Categoria();
            _Categoria.DescricaoCategoria = "Testando Teste";
            _Categoria.idCategoriaPai = 1;

            Models.CategoriaDAL _categoriaDal = new Models.CategoriaDAL();
            _categoriaDal.CreateCategoria(_Categoria);

            Assert.IsNotNull(_Categoria);
        }
    }
}
