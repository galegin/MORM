using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("PRODUTO_SALDO")]
    public class ProdutoSaldo : IProdutoSaldo
    {
        [Campo("ID_PRODUTOSALDO", CampoTipo.Key)]
        public int Id_ProdutoSaldo { get; set; }
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
        [Campo("ID_TIPOSALDO", CampoTipo.Req)]
        public int Id_TipoSaldo { get; set; }
        [Campo("DT_SALDO", CampoTipo.Req)]
        public DateTime Dt_Saldo { get; set; }
        [Campo("QT_SALDO", CampoTipo.Req)]
        public double Qt_Saldo { get; set; }
        [Campo("VL_SALDO", CampoTipo.Req)]
        public double Vl_Saldo { get; set; }

        [Relacao(nameof(Id_Empresa))]
        public IEmpresa Empresa { get; set; }
        [Relacao(nameof(Id_Produto))]
        public IProduto Produto { get; set; }
        [Relacao(nameof(Id_TipoSaldo))]
        public ITipoSaldo TipoSaldo { get; set; }

        public ProdutoSaldo()
        {
            Empresa = new Empresa();
            Produto = new Produto();
            TipoSaldo = new TipoSaldo();
        }
    }
}