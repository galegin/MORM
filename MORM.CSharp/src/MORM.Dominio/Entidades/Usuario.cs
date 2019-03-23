using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    public class Usuario : IUsuario
    {
        public int Id_Usuario { get; set; }
        public string U_Version { get; set; }
        public int Cd_Operador { get; set; }
        public DateTime Dt_Cadastro { get; set; }
        public string Nm_Usuario { get; set; }
        public string Nm_Login { get; set; }
        public string Cd_Senha { get; set; }
        public string Cd_Papel { get; set; }
        public int Tp_Privilegio { get; set; }
        public int Tp_Bloqueio { get; set; }
        public DateTime Dt_Bloqueio { get; set; }
    }
}