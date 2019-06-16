using MORM.Apresentacao.Models;
using MORM.Dominio.Atributos;
using System;

namespace MORM.Apresentacao.Models
{
    [SVC("Empresa")]
    public class EmpresaModel : AbstractModel
    {
        #region variaveis
        private int _id_Empresa;
        private string _u_Version;
        private int _cd_Operador;
        private DateTime _dt_Cadastro;
        private int _id_GrupoEmpresa;
        private string _cd_Empresa;
        private string _ds_Empresa;
        #endregion
        
        #region propriedades
        public int Id_Empresa
        {
            get => _id_Empresa;
            set => SetField(ref _id_Empresa, value);
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
        public int Id_GrupoEmpresa
        {
            get => _id_GrupoEmpresa;
            set => SetField(ref _id_GrupoEmpresa, value);
        }
        public string Cd_Empresa
        {
            get => _cd_Empresa;
            set => SetField(ref _cd_Empresa, value);
        }
        public string Ds_Empresa
        {
            get => _ds_Empresa;
            set => SetField(ref _ds_Empresa, value);
        }
        #endregion
    }
}