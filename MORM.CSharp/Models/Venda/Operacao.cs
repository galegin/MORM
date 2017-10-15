using MORM.CSharp.Classes;
using System;

namespace MORM.CSharp.Models
{
    [Tabela("OPERACAO")]
    public class Operacao : CollectionItem
    {
        [Campo("ID_OPERACAO", CampoTipo.Key)]
        public string Id_Operacao { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("DS_OPERACAO", CampoTipo.Req)]
        public string Ds_Operacao { get; set; }
        [Campo("TP_MODELONF", CampoTipo.Req)]
        public int Tp_Modelonf { get; set; }
        [Campo("TP_MODALIDADE", CampoTipo.Req)]
        public int Tp_Modalidade { get; set; }
        [Campo("TP_OPERACAO", CampoTipo.Req)]
        public int Tp_Operacao { get; set; }
        [Campo("CD_SERIE", CampoTipo.Req)]
        public string Cd_Serie { get; set; }
        [Campo("CD_CFOP", CampoTipo.Req)]
        public int Cd_Cfop { get; set; }
        [Campo("ID_REGRAFISCAL", CampoTipo.Req)]
        public int Id_Regrafiscal { get; set; }
    }
}