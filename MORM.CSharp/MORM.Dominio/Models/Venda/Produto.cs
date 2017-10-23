using MORM.Util.Atributos;
using MORM.Util.Classes;
using System;

namespace MORM.CSharp.Models
{
    [Tabela("PRODUTO")]
    public class Produto : CollectionItem
    {
        [Campo("ID_PRODUTO", CampoTipo.Key)]
        public string Id_Produto { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("CD_PRODUTO", CampoTipo.Req)]
        public int Cd_Produto { get; set; }
        [Campo("DS_PRODUTO", CampoTipo.Req)]
        public string Ds_Produto { get; set; }
        [Campo("CD_ESPECIE", CampoTipo.Req)]
        public string Cd_Especie { get; set; }
        [Campo("CD_NCM", CampoTipo.Req)]
        public string Cd_Ncm { get; set; }
        [Campo("CD_CST", CampoTipo.Req)]
        public string Cd_Cst { get; set; }
        [Campo("CD_CSOSN", CampoTipo.Req)]
        public string Cd_Csosn { get; set; }
        [Campo("PR_ALIQUOTA", CampoTipo.Req)]
        public double Pr_Aliquota { get; set; }
        [Campo("TP_PRODUCAO", CampoTipo.Req)]
        public int Tp_Producao { get; set; }
        [Campo("VL_CUSTO", CampoTipo.Req)]
        public double Vl_Custo { get; set; }
        [Campo("VL_VENDA", CampoTipo.Req)]
        public double Vl_Venda { get; set; }
        [Campo("VL_PROMOCAO", CampoTipo.Req)]
        public double Vl_Promocao { get; set; }
    }
}