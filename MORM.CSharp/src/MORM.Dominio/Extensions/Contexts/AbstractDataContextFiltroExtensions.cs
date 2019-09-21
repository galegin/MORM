using MORM.Dominio.Interfaces;
using System.Configuration;

namespace MORM.Dominio.Extensions
{
    public static class AbstractDataContextFiltroExtensions
    {
        private static bool _inFiltroPadrao =
            ConfigurationManager.AppSettings[nameof(_inFiltroPadrao)] == "true";
        private static bool _inValorPadrao =
            ConfigurationManager.AppSettings[nameof(_inValorPadrao)] == "true";

        public static void SetarFiltroPadrao(this IAmbiente ambiente, object obj)
        {
            if (!_inFiltroPadrao)
                return;

            var filtroPadroes = obj.GetType().GetFiltroPadroes();

            foreach (var filtroPadrao in filtroPadroes)
            {
                var valor = ambiente.GetValor(filtroPadrao);
                if (valor != null)
                    filtroPadrao.Prop.SetValue(obj, valor);
            }
        }

        public static void SetarValorPadrao(this IAmbiente ambiente, object obj)
        {
            if (!_inValorPadrao)
                return;

            var valorPadroes = obj.GetType().GetValorPadroes();

            foreach (var valorPadrao in valorPadroes)
            {
                var valor = ambiente.GetValor(valorPadrao);
                if (valor != null)
                    valorPadrao.Prop.SetValue(obj, valor);
            }
        }
    }
}