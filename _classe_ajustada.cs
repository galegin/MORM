using System;

namespace Projeto
{
    public class Teste : AbstractModel
    {
        #region constantes

        #endregion

        #region variaveis
        private int _codigo;
        private string _descricao;
        private int _numero;
        private decimal _valor;
        private DateTime _data;
        #endregion

        #region propriedades
        public int Codigo
        {
            get => _codigo;
            set => SetField(ref _codigo, value);
        }
        public string Descricao
        {
            get => _descricao;
            set => SetField(ref _descricao, value);
        }
        public int Numero
        {
            get => _numero;
            set => SetField(ref _numero, value);
        }
        public decimal Valor
        {
            get => _valor;
            set => SetField(ref _valor, value);
        }
        public DateTime Data
        {
            get => _data;
            set => SetField(ref _data, value);
        }
        #endregion

        #region comandos

        #endregion

        #region construtores
        public Teste()
        {
        }
        #endregion

        #region metodos

        #endregion
    }
}