using MORM.Utilidade.Atributos;
using System;

namespace MORM.Repositorio.Tests.Models
{
    [Tabela("TESTE")]
    public class TesteModel
    {
        public TesteModel()
        {
            Tipo = new TesteTipoModel();
        }

        [Campo("CD_TESTE", CampoTipo.Key)]
        public int Codigo { get; set; }
        [Campo("DS_TESTE", CampoTipo.Req)]
        public string Descricao { get; set; }
        [Campo("DT_TESTE", CampoTipo.Req)]
        public DateTime Data { get; set; }
        [Campo("IN_TESTE", CampoTipo.Req)]
        public bool Ativo { get; set; }
        [Campo("NR_TESTE", CampoTipo.Req)]
        public int Numero { get; set; }
        [Campo("VL_TESTE", CampoTipo.Req)]
        public double Valor { get; set; }
        [Campo("CD_TIPOTESTE", CampoTipo.Req)]
        public int CodigoTipo { get; set; }

        [Relacao(new string[] { nameof(CodigoTipo) + "=" + nameof(TesteTipoModel.Codigo) })]
        public TesteTipoModel Tipo { get; set; }
    }
}