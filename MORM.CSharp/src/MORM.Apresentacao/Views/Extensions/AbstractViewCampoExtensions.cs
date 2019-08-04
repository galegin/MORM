using MORM.Apresentacao.Controls;
using MORM.Apresentacao.ViewsModel;
using System.Windows;
using System.Windows.Controls;

namespace MORM.Apresentacao.Views
{
    public static class AbstractViewCampoExtensions
    {
        public static void AddCampo(this UserControl userControl, 
            IAbstractViewModel vm, string nomeBinding, MetadataCampo campo, AbstractCampoTipo campoTipo)
        {
            campoTipo = campoTipo.GetCampoSubTipo(campo);

            var abstractCampo = new AbstractCampo(vm, nomeBinding, campoTipo, campo);
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
            if (campo.Prop.IsValoresCampo())
                return AbstractCampoTipo.IndividualComTipagem;
            else if (campo.Prop.IsClasseCampo() && !campo.Tipo.IsKey())
                return AbstractCampoTipo.IndividualComPesquisaEDescricao;
            else
                return tipo;
        }

        private static AbstractCampoTipo GetCampoSubTipoIntervalo(this AbstractCampoTipo tipo, MetadataCampo campo)
        {
            if (campo.Prop.IsValoresCampo())
                return AbstractCampoTipo.IntervaloComSelecao;
            else if (campo.Prop.IsClasseCampo())
                return AbstractCampoTipo.IntervaloComPesquisa;
            else
                return tipo;
        }
    }
}