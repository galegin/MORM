using MORM.Apresentacao.Models;
using MORM.Dominio.Atributos;
using System;

namespace MORM.Apresentacao.Models
{
    [SVC("Transacao")]
    public class TransacaoModel : AbstractModel
    {
        #region variaveis
        private int _id_Transacao;
        private string _u_Version;
        private int _cd_Operador;
        private DateTime _dt_Cadastro;
        private int _id_Empresa;
        private int _id_Pessoa;
        private int _id_Operacao;
        private int _tp_Situacao;
        private int _tp_Operacao;
        private int _tp_Modalidade;
        private DateTime _dt_Transacao;
        private string _nr_DocumentoNota;
        #endregion
        
        #region propriedades
        public int Id_Transacao
        {
            get => _id_Transacao;
            set => SetField(ref _id_Transacao, value);
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
        public int Id_Pessoa
        {
            get => _id_Pessoa;
            set => SetField(ref _id_Pessoa, value);
        }
        public int Id_Operacao
        {
            get => _id_Operacao;
            set => SetField(ref _id_Operacao, value);
        }
        public int Tp_Situacao
        {
            get => _tp_Situacao;
            set => SetField(ref _tp_Situacao, value);
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
        public DateTime Dt_Transacao
        {
            get => _dt_Transacao;
            set => SetField(ref _dt_Transacao, value);
        }
        public string Nr_DocumentoNota
        {
            get => _nr_DocumentoNota;
            set => SetField(ref _nr_DocumentoNota, value);
        }
        #endregion
    }
}