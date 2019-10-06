using System;

namespace MORM.CrossCutting
{
    public enum UsuarioBloqueio
    {
        Liberado = 0,
        Bloqueado = 1
    }

    public enum UsuarioPrivilegio
    {
        Padrao = 0,
        SemRestricao = 1,
        ApenasConsulta = 2,
        Administrador = 9
    }

    public interface IUsuario
    {
        int Id_Usuario { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        string Nm_Usuario { get; set; }
        string Nm_Login { get; set; }
        string Cd_Senha { get; set; }
        string Cd_Papel { get; set; }
        int Tp_Privilegio { get; set; }
        int Tp_Bloqueio { get; set; }
        DateTime Dt_Bloqueio { get; set; }
    }
}