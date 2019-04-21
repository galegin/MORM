using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("USUARIO")]
    public class Usuario : IUsuario
    {
        [Campo("ID_USUARIO", CampoTipo.Key)]
        public int Id_Usuario { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("NM_USUARIO", CampoTipo.Req)]
        public string Nm_Usuario { get; set; }
        [Campo("NM_LOGIN", CampoTipo.Req)]
        public string Nm_Login { get; set; }
        [Campo("CD_SENHA", CampoTipo.Pwd)]
        public string Cd_Senha { get; set; }
        [Campo("CD_PAPEL", CampoTipo.Nul)]
        public string Cd_Papel { get; set; }
        [Campo("TP_PRIVILEGIO", CampoTipo.Req)]
        public int Tp_Privilegio { get; set; }
        [Campo("TP_BLOQUEIO", CampoTipo.Req)]
        public int Tp_Bloqueio { get; set; }
        [Campo("DT_BLOQUEIO", CampoTipo.Nul)]
        public DateTime Dt_Bloqueio { get; set; }
    }
}