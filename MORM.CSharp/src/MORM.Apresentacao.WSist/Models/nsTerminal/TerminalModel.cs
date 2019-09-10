using MORM.CrossCutting;
using System;

namespace MORM.Apresentacao.Models
{
    [SVC("Terminal")]
    public class TerminalModel : AbstractModel
    {
        #region variaveis
        private int _id_Terminal;
        private string _u_Version;
        private int _cd_Operador;
        private DateTime _dt_Cadastro;
        private string _cd_Terminal;
        private string _ds_Terminal;
        #endregion
        
        #region propriedades
        public int Id_Terminal
        {
            get => _id_Terminal;
            set => SetField(ref _id_Terminal, value);
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
        public string Cd_Terminal
        {
            get => _cd_Terminal;
            set => SetField(ref _cd_Terminal, value);
        }
        public string Ds_Terminal
        {
            get => _ds_Terminal;
            set => SetField(ref _ds_Terminal, value);
        }
        #endregion
    }
}