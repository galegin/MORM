using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("PRODUTO_VALOR")]
    public class ProdutoValor : IProdutoValor
    {
        [Campo("ID_PRODUTOVALOR", CampoTipo.Key)]
        public int Id_ProdutoValor { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("ID_EMPRESA", CampoTipo.Req)]
        public int Id_Empresa { get; set; }
        [Campo("ID_PRODUTO", CampoTipo.Req)]
        public int Id_Produto { get; set; }
        [Campo("ID_TIPOVALOR", CampoTipo.Req)]
        public int Id_TipoValor { get; set; }
        [Campo("DT_VALOR", CampoTipo.Req)]
        public DateTime Dt_Valor { get; set; }
        [Campo("VL_PRODUTO", CampoTipo.Req)]
        public double Vl_Produto { get; set; }

        [Relacao(nameof(Id_Empresa))]
        public IEmpresa Empresa { get; set; }
        [Relacao(nameof(Id_Produto))]
        public IProduto Produto { get; set; }
        [Relacao(nameof(Id_TipoValor))]
        public ITipoValor TipoValor { get; set; }

        public ProdutoValor()
        {
            Empresa = new Empresa();
            Produto = new Produto();
            TipoValor = new TipoValor();
        }
    }
}
