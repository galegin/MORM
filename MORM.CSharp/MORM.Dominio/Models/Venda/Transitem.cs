using MORM.Util.Atributos;
using MORM.Util.Classes;
using System;

namespace MORM.CSharp.Models
{
    [Tabela("TRANSITEM")]
    public class Transitem : CollectionItem
    {
        [Campo("ID_TRANSACAO", CampoTipo.Key)]
        public string Id_Transacao { get; set; }
        [Campo("NR_ITEM", CampoTipo.Key)]
        public int Nr_Item { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("ID_PRODUTO", CampoTipo.Req)]
        public string Id_Produto { get; set; }
        [Campo("CD_PRODUTO", CampoTipo.Req)]
        public int Cd_Produto { get; set; }
        [Campo("DS_PRODUTO", CampoTipo.Req)]
        public string Ds_Produto { get; set; }
        [Campo("CD_CFOP", CampoTipo.Req)]
        public int Cd_Cfop { get; set; }
        [Campo("CD_ESPECIE", CampoTipo.Req)]
        public string Cd_Especie { get; set; }
        [Campo("CD_NCM", CampoTipo.Req)]
        public string Cd_Ncm { get; set; }
        [Campo("QT_ITEM", CampoTipo.Req)]
        public double Qt_Item { get; set; }
        [Campo("VL_CUSTO", CampoTipo.Req)]
        public double Vl_Custo { get; set; }
        [Campo("VL_UNITARIO", CampoTipo.Req)]
        public double Vl_Unitario { get; set; }
        [Campo("VL_ITEM", CampoTipo.Req)]
        public double Vl_Item { get; set; }
        [Campo("VL_VARIACAO", CampoTipo.Req)]
        public double Vl_Variacao { get; set; }
        [Campo("VL_VARIACAOCAPA", CampoTipo.Req)]
        public double Vl_Variacaocapa { get; set; }
        [Campo("VL_FRETE", CampoTipo.Req)]
        public double Vl_Frete { get; set; }
        [Campo("VL_SEGURO", CampoTipo.Req)]
        public double Vl_Seguro { get; set; }
        [Campo("VL_OUTRO", CampoTipo.Req)]
        public double Vl_Outro { get; set; }
        [Campo("VL_DESPESA", CampoTipo.Req)]
        public double Vl_Despesa { get; set; }
    }
}