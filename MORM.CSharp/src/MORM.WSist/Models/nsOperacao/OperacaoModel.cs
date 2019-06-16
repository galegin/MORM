using MORM.Apresentacao.Models;
using MORM.Dominio.Atributos;
using System;

namespace MORM.Apresentacao.Models
{
    [SVC("Operacao")]
    public class OperacaoModel : AbstractModel
    {
        #region variaveis
        private int _id_Operacao;
        private string _u_Version;
        private int _cd_Operador;
        private DateTime _dt_Cadastro;
        private int _id_RegraFiscal;
        private string _cd_Operacao;
        private string _ds_Operacao;
        private int _tp_Operacao;
        private int _tp_Modalidade;
        private bool _in_GerarFinanceiro;
        private bool _in_GerarFiscal;
        private bool _in_GerarSaldo;
        #endregion
        
        #region propriedades
        public int Id_Operacao
        {
            get => _id_Operacao;
            set => SetField(ref _id_Operacao, value);
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
        public int Id_RegraFiscal
        {
            get => _id_RegraFiscal;
            set => SetField(ref _id_RegraFiscal, value);
        }
        public string Cd_Operacao
        {
            get => _cd_Operacao;
            set => SetField(ref _cd_Operacao, value);
        }
        public string Ds_Operacao
        {
            get => _ds_Operacao;
            set => SetField(ref _ds_Operacao, value);
        }
        public int Tp_Operacao
        {
            get => _tp_Operacao;
            set => SetField(ref _tp_Operacao, value);
        }
        public int Tp_Modalidade
        {
            get => _tp_Modalidade;
            set => SetField(ref _tp_Modalidade, value);
        }
        public bool In_GerarFinanceiro
        {
            get => _in_GerarFinanceiro;
            set => SetField(ref _in_GerarFinanceiro, value);
        }
        public bool In_GerarFiscal
        {
            get => _in_GerarFiscal;
            set => SetField(ref _in_GerarFiscal, value);
        }
        public bool In_GerarSaldo
        {
            get => _in_GerarSaldo;
            set => SetField(ref _in_GerarSaldo, value);
        }
        #endregion
    }
}