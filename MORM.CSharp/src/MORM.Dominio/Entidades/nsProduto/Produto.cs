using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("PRODUTO")]
    public class Produto : IProduto
    {
        [Campo("ID_PRODUTO", CampoTipo.Key)]
        public int Id_Produto { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("CD_PRODUTO", CampoTipo.Req)]
        public string Cd_Produto { get; set; }
        [Campo("DS_PRODUTO", CampoTipo.Req)]
        public string Ds_Produto { get; set; }
        [Campo("CD_ESPECIE", CampoTipo.Req)]
        public string Cd_Especie { get; set; }
        [Campo("CD_NCM", CampoTipo.Req)]
        public string Cd_Ncm { get; set; }
        [Campo("CD_CST", CampoTipo.Req)]
        public string Cd_Cst { get; set; }
        [Campo("IN_FABRPROPRIA", CampoTipo.Req)]
        public bool In_FabrPropria { get; set; }
        [Campo("IN_ARREDONDA", CampoTipo.Req)]
        public bool In_Arredonda { get; set; }
    }
}