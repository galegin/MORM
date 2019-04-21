using MORM.Apresentacao.Models;
using MORM.Dominio.Atributos;
using System;

namespace MORM.WSist.Models.Manutencao
{
    [SVC("Usuario")]
    public class AbstractUsuarioModel : AbstractModel
    {
        #region variaveis
        private int _id_Usuario;
        private string _u_Version;
        private int _cd_Operador;
        private DateTime _dt_Cadastro;
        private string _nm_Usuario;
        private string _nm_Login;
        private string _cd_Senha;
        private string _cd_Papel;
        private int _tp_Privilegio;
        private int _tp_Bloqueio;
        private DateTime _dt_Bloqueio;
        #endregion

        #region propriedades
        public int Id_Usuario
        {
            get => _id_Usuario;
            set => SetField(ref _id_Usuario, value);
        }
        public string U_Version
        {
            get => _u_Version;
            set => SetField(ref _u_Version, value);
        }
        public int Cd_Operador
        {
            get => _cd_Operador;
            set => SetField(ref _cd_Operador, value);
        }
        public DateTime Dt_Cadastro
        {
            get => _dt_Cadastro;
            set => SetField(ref _dt_Cadastro, value);
        }
        public string Nm_Usuario
        {
            get => _nm_Usuario;
            set => SetField(ref _nm_Usuario, value);
        }
        public string Nm_Login
        {
            get => _nm_Login;
            set => SetField(ref _nm_Login, value);
        }
        public string Cd_Senha
        {
            get => _cd_Senha;
            set => SetField(ref _cd_Senha, value);
        }
        public string Cd_Papel
        {
            get => _cd_Papel;
            set => SetField(ref _cd_Papel, value);
        }
        public int Tp_Privilegio
        {
            get => _tp_Privilegio;
            set => SetField(ref _tp_Privilegio, value);
        }
        public int Tp_Bloqueio
        {
            get => _tp_Bloqueio;
            set => SetField(ref _tp_Bloqueio, value);
        }
        public DateTime Dt_Bloqueio
        {
            get => _dt_Bloqueio;
            set => SetField(ref _dt_Bloqueio, value);
        }
        #endregion
    }
}