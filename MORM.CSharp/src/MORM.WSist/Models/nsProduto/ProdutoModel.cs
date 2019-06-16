using MORM.Apresentacao.Models;
using MORM.Dominio.Atributos;
using System;

namespace MORM.Apresentacao.Models
{
    [SVC("Produto")]
    public class ProdutoModel : AbstractModel
    {
        #region variaveis
        private int _id_Produto;
        private string _u_Version;
        private int _cd_Operador;
        private DateTime _dt_Cadastro;
        private string _cd_Produto;
        private string _ds_Produto;
        private string _cd_Especie;
        private string _cd_Ncm;
        private string _cd_Cst;
        private bool _in_FabrPropria;
        private bool _in_Arredonda;
        #endregion
        
        #region propriedades
        public int Id_Produto
        {
            get => _id_Produto;
            set => SetField(ref _id_Produto, value);
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
        public string Cd_Produto
        {
            get => _cd_Produto;
            set => SetField(ref _cd_Produto, value);
        }
        public string Ds_Produto
        {
            get => _ds_Produto;
            set => SetField(ref _ds_Produto, value);
        }
        public string Cd_Especie
        {
            get => _cd_Especie;
            set => SetField(ref _cd_Especie, value);
        }
        public string Cd_Ncm
        {
            get => _cd_Ncm;
            set => SetField(ref _cd_Ncm, value);
        }
        public string Cd_Cst
        {
            get => _cd_Cst;
            set => SetField(ref _cd_Cst, value);
        }
        public bool In_FabrPropria
        {
            get => _in_FabrPropria;
            set => SetField(ref _in_FabrPropria, value);
        }
        public bool In_Arredonda
        {
            get => _in_Arredonda;
            set => SetField(ref _in_Arredonda, value);
        }
        #endregion
    }
}