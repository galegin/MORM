using MORM.Utilidade.Atributos;
using System;

namespace MORM.Repositorio.Tests
{
    [Tabela("TESTE")]
    public class TesteModel
    {
        public TesteModel()
        {
            Tipo = new TipoModel();
        }

        [Campo("CD_TESTE", CampoTipo.Key)]
        public int Cd_Teste { get; set; }
        [Campo("DS_TESTE", CampoTipo.Req)]
        public string Ds_Teste { get; set; }
        [Campo("DT_TESTE", CampoTipo.Req)]
        public DateTime Dt_Teste { get; set; }
        [Campo("IN_TESTE", CampoTipo.Req)]
        public bool In_Ativo { get; set; }
        [Campo("NR_TESTE", CampoTipo.Req)]
        public int Nr_Teste { get; set; }
        [Campo("VL_TESTE", CampoTipo.Req)]
        public double Vl_Teste { get; set; }
        [Campo("CD_TIPO", CampoTipo.Req)]
        public int Cd_Tipo { get; set; }

        [Relacao(new string[] { nameof(Cd_Tipo) + "=" + nameof(TipoModel.Cd_Tipo) })]
        public TipoModel Tipo { get; set; }
    }
}