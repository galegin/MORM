using MORM.Apresentacao.Models;
using MORM.Infra.CrossCutting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MORM.Apresentacao.Controls
{
    public class AbstractCampoFiltro : AbstractModel
    {
    }

    public class AbstractCampoFiltro<TFiltro> : AbstractCampoFiltro
    {
        #region variaveis
        private TFiltro _valor;
        private TFiltro _valorIni;
        private TFiltro _valorFin;
        private IList<TFiltro> _valorSel;
        private string _valorDes;
        #endregion

        #region propriedadeds
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
        public IList<TFiltro> ValorSel
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
        private string GetValorDes()
        {
            var isValorIni = !string.IsNullOrWhiteSpace($"{ValorIni}");
            var isValorFin = !string.IsNullOrWhiteSpace($"{ValorFin}");
            return ValorSel.Any() ? string.Join(", ", ValorSel) 
                : isValorIni && isValorFin ? $">={ValorIni}&<={ValorFin}"
                : isValorIni ? $">={ValorIni}"
                : isValorFin ? $"<={ValorFin}" 
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