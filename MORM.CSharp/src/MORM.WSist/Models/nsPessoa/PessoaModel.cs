using MORM.Apresentacao.Models;
using MORM.Dominio.Atributos;
using System;

namespace MORM.Apresentacao.Models
{
    [SVC("Pessoa")]
    public class PessoaModel : AbstractModel
    {
        #region variaveis
        private int _id_Pessoa;
        private string _u_Version;
        private int _cd_Operador;
        private DateTime _dt_Cadastro;
        private string _nm_Pessoa;
        private string _tp_Pessoa;
        private int _tp_Documento;
        private string _nr_Documento;
        private int _tp_Inscricao;
        private string _nr_Inscricao;
        private int _tp_RegimeTributario;
        #endregion
        
        #region propriedades
        public int Id_Pessoa
        {
            get => _id_Pessoa;
            set => SetField(ref _id_Pessoa, value);
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
        public string Nm_Pessoa
        {
            get => _nm_Pessoa;
            set => SetField(ref _nm_Pessoa, value);
        }
        public string Tp_Pessoa
        {
            get => _tp_Pessoa;
            set => SetField(ref _tp_Pessoa, value);
        }
        public int Tp_Documento
        {
            get => _tp_Documento;
            set => SetField(ref _tp_Documento, value);
        }
        public string Nr_Documento
        {
            get => _nr_Documento;
            set => SetField(ref _nr_Documento, value);
        }
        public int Tp_Inscricao
        {
            get => _tp_Inscricao;
            set => SetField(ref _tp_Inscricao, value);
        }
        public string Nr_Inscricao
        {
            get => _nr_Inscricao;
            set => SetField(ref _nr_Inscricao, value);
        }
        public int Tp_RegimeTributario
        {
            get => _tp_RegimeTributario;
            set => SetField(ref _tp_RegimeTributario, value);
        }
        #endregion
    }
}