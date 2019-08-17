using MORM.Apresentacao.Controls;
using MORM.Infra.CrossCutting;
using System.Windows;
using System.Windows.Controls;

namespace MORM.Apresentacao.Views
{
    public static class AbstractViewCampoExtensions
    {
        public static void AddCampo(this UserControl userControl, 
            AbstractSource source, MetadataCampo campo, AbstractCampoTipo campoTipo)
        {
            campoTipo = campoTipo.GetCampoSubTipo(campo);

            var abstractCampo = new AbstractCampo(source, campoTipo, campo);
            abstractCampo.Margin = new Thickness(0, 0, 0, 10);
            userControl.AddPainel(abstractCampo);
        }

        private static AbstractCampoTipo GetCampoSubTipo(this AbstractCampoTipo tipo, MetadataCampo campo)
        {
            switch (tipo)
            {
                case AbstractCampoTipo.Individual:
                    return tipo.GetCampoSubTipoIndividual(campo);
                case AbstractCampoTipo.Intervalo:
                    return tipo.GetCampoSubTipoIntervalo(campo);
            }

            return tipo;
        }

        private static AbstractCampoTipo GetCampoSubTipoIndividual(this AbstractCampoTipo tipo, MetadataCampo campo)
        {
            if (campo.IsValores())
                return AbstractCampoTipo.IndividualComTipagem;
            else if (campo.IsClasse() && !campo.IsKey())
                return AbstractCampoTipo.IndividualComPesquisaEDescricao;
            else
                return tipo;
        }

        private static AbstractCampoTipo GetCampoSubTipoIntervalo(this AbstractCampoTipo tipo, MetadataCampo campo)
        {
            if (campo.IsValores())
                return AbstractCampoTipo.IntervaloComSelecao;
            else if (campo.IsClasse())
                return AbstractCampoTipo.IntervaloComPesquisa;
            else
                return tipo;
        }
    }
}