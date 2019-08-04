using MORM.Apresentacao.Models;
using System;
using System.Collections;

namespace MORM.Apresentacao.Controls
{
    public enum CampoDefTipo
    {
        Texto,
        Combo,
        Lista
    }

    public class CampoDef : AbstractModel
    {
        #region variaveis
        private CampoDefTipo _tipo;
        private string _codigo;
        private string _descricao;
        private int _tamanho;
        private int _precisao;
        private bool _isExibir;
        private object _valor;
        private IList _valores; // valores para combo
        private Type _classe; // classe para extrangeira
        #endregion

        #region propriedades
        public CampoDefTipo Tipo { get => _tipo; set => SetField(ref _tipo, value); }
        public string Codigo { get => _codigo; set => SetField(ref _codigo, value); }
        public string Descricao { get => _descricao; set => SetField(ref _descricao, value); }
        public int Tamanho { get => _tamanho; set => SetField(ref _tamanho, value); }
        public int Precisao { get => _precisao; set => SetField(ref _precisao, value); }
        public bool IsExibir { get => _isExibir; set => SetField(ref _isExibir, value); }
        public object Valor { get => _valor; set => SetField(ref _valor, value); }
        public IList Valores { get => _valores; set => SetField(ref _valores, value); }
        public Type Classe { get => _classe; set => SetField(ref _classe, value); }
        #endregion

        #region comandos
        #endregion

        #region construtores
        #endregion

        #region metodos
        #endregion
    }
}