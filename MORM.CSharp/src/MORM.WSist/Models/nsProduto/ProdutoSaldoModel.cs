using MORM.Apresentacao.Models;
using MORM.Dominio.Atributos;
using System;

namespace MORM.Apresentacao.Models
{
    [SVC("ProdutoSaldo")]
    public class ProdutoSaldoModel : AbstractModel
    {
        #region variaveis
        private int _id_ProdutoSaldo;
        private string _u_Version;
        private int _cd_Operador;
        private DateTime _dt_Cadastro;
        private int _id_Empresa;
        private int _id_Produto;
        private int _id_TipoSaldo;
        private DateTime _dt_Saldo;
        private double _qt_Saldo;
        private double _vl_Saldo;
        #endregion
        
        #region propriedades
        public int Id_ProdutoSaldo
        {
            get => _id_ProdutoSaldo;
            set => SetField(ref _id_ProdutoSaldo, value);
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
        public int Id_TipoSaldo
        {
            get => _id_TipoSaldo;
            set => SetField(ref _id_TipoSaldo, value);
        }
        public DateTime Dt_Saldo
        {
            get => _dt_Saldo;
            set => SetField(ref _dt_Saldo, value);
        }
        public double Qt_Saldo
        {
            get => _qt_Saldo;
            set => SetField(ref _qt_Saldo, value);
        }
        public double Vl_Saldo
        {
            get => _vl_Saldo;
            set => SetField(ref _vl_Saldo, value);
        }
        #endregion
    }
}