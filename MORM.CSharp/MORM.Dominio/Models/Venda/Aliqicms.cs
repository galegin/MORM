using MORM.Util.Classes;
using System;

namespace MORM.CSharp.Models
{
    [Tabela("ALIQICMS")]
    public class Aliqicms : CollectionItem
    {
        [Campo("UF_ORIGEM", CampoTipo.Key)]
        public string Uf_Origem { get; set; }
        [Campo("UF_DESTINO", CampoTipo.Key)]
        public string Uf_Destino { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("PR_ALIQUOTA", CampoTipo.Req)]
        public double Pr_Aliquota { get; set; }
    }
}