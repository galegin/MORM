using MORM.Apresentacao.Models;
using MORM.Infra.CrossCutting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MORM.Apresentacao.Controls
{
    public class AbstractCampoFiltro : AbstractModel
    {
        #region variaveis
        private AbstractCampoTipo _tipo;
        #endregion

        #region propriedades
        public AbstractCampoTipo Tipo
        {
            get => _tipo;
            set => SetField(ref _tipo, value);
        }
        #endregion
    }

    public class AbstractCampoFiltro<TFiltro> : AbstractCampoFiltro
    {
        #region variaveis
        private TFiltro _valor;
        private TFiltro _valorIni;
        private TFiltro _valorFin;
        private IList _valorSel;
        private string _valorDes;
        private string[] _valoresNulos = { "0" };
        #endregion

        #region propriedades
        public TFiltro Valor
        {
            get => _valor;
            set => SetField(ref _valor, value);
        }
        public TFiltro ValorIni
        {
            get => _valorIni;
            set
            {
                SetField(ref _valorIni, value);
                ValorDes = GetValorDes();
            }
        }
        public TFiltro ValorFin
        {
            get => _valorFin;
            set
            {
                SetField(ref _valorFin, value);
                ValorDes = GetValorDes();
            }
        }
        public IList ValorSel
        {
            get => _valorSel;
            set
            {
                SetField(ref _valorSel, value);
                ValorDes = GetValorDes();
            }
        }
        public string ValorDes
        {
            get => _valorDes;
            set => SetField(ref _valorDes, value);
        }
        #endregion

        #region construtores
        public AbstractCampoFiltro()
        {
            ValorSel = new List<TFiltro>();
        }
        #endregion

        #region metodos
        private bool IsValor(object valor)
        {
            var stValor = $"{valor}";
            return !string.IsNullOrWhiteSpace(stValor) && !_valoresNulos.Contains(stValor);
        }
        private string GetValorDes()
        {
            return Tipo.IsSelecao() ? GetValorSel() 
                : Tipo.IsInter() ? GetValorInt()
                : null
                ;
        }
        private string GetValorInt()
        {
            var isValorIni = IsValor($"{ValorIni}");
            var isValorFin = IsValor($"{ValorFin}");
            return isValorIni && isValorFin ? $">={ValorIni}&<={ValorFin}"
                : isValorIni ? $">={ValorIni}"
                : isValorFin ? $"<={ValorFin}"
                : null
                ;
        }
        private string GetValorSel()
        {
            var retorno = new List<string>();
            foreach(var valor in ValorSel)
                retorno.Add(valor.ToString());
            return retorno.Any() ? string.Join(",", retorno)
                : null
                ;
        }
        #endregion
    }

    public static class AbstractCampoFiltroExtensions
    {
        public static AbstractCampoFiltro GetCampoFiltro(this Type type)
        {
            return TypeForConvert.GetObjectFor(typeof(AbstractCampoFiltro<>), type) as AbstractCampoFiltro;
        }
    }
}