using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("PRODUTO_KIT")]
    public class ProdutoKit : IProdutoKit
    {
        [Campo("ID_PRODUTOKIT", CampoTipo.Key)]
        public int Id_ProdutoKit { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("ID_KIT", CampoTipo.Req)]
        public int Id_Kit { get; set; }
        [Campo("ID_PRODUTO", CampoTipo.Req)]
        public int Id_Produto { get; set; }
        [Campo("CD_PRODUTOKIT", CampoTipo.Req)]
        public string Cd_ProdutoKit { get; set; }

        [Relacao(nameof(Id_Produto))]
        public IProduto Produto { get; set; }

        public ProdutoKit()
        {
            Produto = new Produto();
        }
    }
}
