using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("PRODUTO_BARRA")]
    public class ProdutoBarra : IProdutoBarra
    {
        [Campo("ID_PRODUTOBARRA", CampoTipo.Key)]
        public int Id_ProdutoBarra { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("ID_PRODUTO", CampoTipo.Req)]
        public int Id_Produto { get; set; }
        [Campo("CD_PRODUTOBARRA", CampoTipo.Req)]
        public string Cd_ProdutoBarra { get; set; }
        [Campo("QT_EMBALAGEM", CampoTipo.Req)]
        public double Qt_Embalagem { get; set; }
        [Campo("N_PADRAO", CampoTipo.Req)]
        public bool In_Padrao { get; set; }

        [Relacao(nameof(Id_Produto))]
        public IProduto Produto { get; set; }

        public ProdutoBarra()
        {
            Produto = new Produto();
        }
    }
}
