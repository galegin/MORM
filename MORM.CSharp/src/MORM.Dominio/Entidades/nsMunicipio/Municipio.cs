using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("MUNICIPIO")]
    public class Municipio : IMunicipio
    {
        [Campo("ID_MUNICIPIO", CampoTipo.Key)]
        public int Id_Municipio { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("ID_ESTAOD", CampoTipo.Req)]
        public int Id_Estado { get; set; }
        [Campo("CD_MUNICIPIO", CampoTipo.Req)]
        public string Cd_Municipio { get; set; }
        [Campo("NM_MUNICIPIO", CampoTipo.Req)]
        public string Nm_Municipio { get; set; }
        [Campo("DS_SIGLA", CampoTipo.Req)]
        public string Ds_Sigla { get; set; }

        [Relacao(nameof(Id_Estado))]
        public IEstado Estado { get; set; }

        public Municipio()
        {
            Estado = new Estado();
        }
    }
}