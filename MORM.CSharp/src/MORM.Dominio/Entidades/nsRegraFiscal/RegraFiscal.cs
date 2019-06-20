using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;
using System.Collections.Generic;

namespace MORM.Dominio.Entidades
{
    [Tabela("REGRA_FISCAL")]
    public class RegraFiscal : IRegraFiscal
    {
        [Campo("ID_REGRAFISCAL", CampoTipo.Key)]
        public int Id_RegraFiscal { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("CD_REGRAFISCAL", CampoTipo.Req)]
        public string Cd_RegraFiscal { get; set; }
        [Campo("DS_REGRAFISCAL", CampoTipo.Req)]
        public string Ds_RegraFiscal { get; set; }
        [Campo("CD_CFOPENTRADA", CampoTipo.Req)]
        public int Cd_CfopEntrada { get; set; }
        [Campo("CD_CFOPSAIDA", CampoTipo.Req)]
        public int Cd_CfopSaida { get; set; }

        [Relacao(nameof(Id_RegraFiscal), RelacaoTipo.Update)]
        public ICollection<IRegraFiscalImposto> Impostos { get; set; }

        public RegraFiscal()
        {
            Impostos = new List<IRegraFiscalImposto>();
        }
    }
}