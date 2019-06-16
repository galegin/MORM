using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("BAIRRO")]
    public class Bairro : IBairro
    {
        [Campo("ID_BAIRRO", CampoTipo.Key)]
        public int Id_Bairro { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("DS_BAIRRO", CampoTipo.Req)]
        public string Ds_Bairro { get; set; }
    }
}