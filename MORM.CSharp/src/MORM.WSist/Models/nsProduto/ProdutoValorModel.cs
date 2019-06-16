using MORM.Apresentacao.Models;
using MORM.Dominio.Atributos;
using System;

namespace MORM.Apresentacao.Models
{
    [SVC("ProdutoValor")]
    public class ProdutoValorModel : AbstractModel
    {
        #region variaveis
        private int _id_ProdutoValor;
        private string _u_Version;
        private int _cd_Operador;
        private DateTime _dt_Cadastro;
        private int _id_Empresa;
        private int _id_Produto;
        private int _id_TipoValor;
        private DateTime _dt_Valor;
        private double _vl_Produto;
        #endregion
        
        #region propriedades
        public int Id_ProdutoValor
        {
            get => _id_ProdutoValor;
            set => SetField(ref _id_ProdutoValor, value);
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
        public int Id_Empresa
        {
            get => _id_Empresa;
            set => SetField(ref _id_Empresa, value);
        }
        public int Id_Produto
        {
            get => _id_Produto;
            set => SetField(ref _id_Produto, value);
        }
        public int Id_TipoValor
        {
            get => _id_TipoValor;
            set => SetField(ref _id_TipoValor, value);
        }
        public DateTime Dt_Valor
        {
            get => _dt_Valor;
            set => SetField(ref _dt_Valor, value);
        }
        public double Vl_Produto
        {
            get => _vl_Produto;
            set => SetField(ref _vl_Produto, value);
        }
        #endregion
    }
}