using MORM.CrossCutting;
using System;

namespace MORM.Apresentacao.WSist
{
    [SVC("GrupoEmpresa")]
    public class GrupoEmpresaModel : AbstractModel
    {
        #region variaveis
        private int _id_GrupoEmpresa;
        private string _u_Version;
        private int _cd_Operador;
        private DateTime _dt_Cadastro;
        private string _cd_GrupoEmpresa;
        private string _nm_GrupoEmpresa;
        #endregion
        
        #region propriedades
        public int Id_GrupoEmpresa
        {
            get => _id_GrupoEmpresa;
            set => SetField(ref _id_GrupoEmpresa, value);
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
        public string Cd_GrupoEmpresa
        {
            get => _cd_GrupoEmpresa;
            set => SetField(ref _cd_GrupoEmpresa, value);
        }
        public string Nm_GrupoEmpresa
        {
            get => _nm_GrupoEmpresa;
            set => SetField(ref _nm_GrupoEmpresa, value);
        }
        #endregion
    }
}