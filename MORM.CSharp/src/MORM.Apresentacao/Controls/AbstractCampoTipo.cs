using MORM.Dominio.Extensions;

namespace MORM.Apresentacao.Controls
{
    public enum AbstractCampoTipo
    {
        // Manutenção
        Individual,
        IndividualComDescricao,
        IndividualComPesquisa,
        IndividualComPesquisaEDescricao,
        IndividualComSelecao,
        IndividualComTipagem,

        // Filtro
        Intervalo,
        IntervaloComDescricao,
        IntervaloComPesquisa,
        IntervaloComPesquisaEDescricao,
        IntervaloComSelecao,
        IntervaloComTipagem,
    }

    public static class AbstractCampoTipoExtensions
    {
        public static bool IsDescr(this AbstractCampoTipo tipo)
        {
            return tipo.In(
                AbstractCampoTipo.IndividualComDescricao,
                AbstractCampoTipo.IndividualComPesquisaEDescricao,
                AbstractCampoTipo.IntervaloComDescricao,
                AbstractCampoTipo.IntervaloComPesquisaEDescricao);
        }

        public static bool IsIndiv(this AbstractCampoTipo tipo)
        {
            return tipo.In(
                AbstractCampoTipo.Individual,
                AbstractCampoTipo.IndividualComDescricao,
                AbstractCampoTipo.IndividualComPesquisa,
                AbstractCampoTipo.IndividualComPesquisaEDescricao);
        }

        public static bool IsInter(this AbstractCampoTipo tipo)
        {
            return tipo.In(
                AbstractCampoTipo.Intervalo,
                AbstractCampoTipo.IntervaloComDescricao,
                AbstractCampoTipo.IntervaloComPesquisa,
                AbstractCampoTipo.IntervaloComPesquisaEDescricao);
        }

        public static bool IsPesq(this AbstractCampoTipo tipo)
        {
            return tipo.In(
                AbstractCampoTipo.IndividualComPesquisa,
                AbstractCampoTipo.IndividualComPesquisaEDescricao,
                AbstractCampoTipo.IntervaloComPesquisa,
                AbstractCampoTipo.IntervaloComPesquisaEDescricao);
        }

        public static bool IsSelecao(this AbstractCampoTipo tipo)
        {
            return tipo.In(
                AbstractCampoTipo.IndividualComSelecao,
                AbstractCampoTipo.IntervaloComSelecao);
        }

        public static bool IsTipagem(this AbstractCampoTipo tipo)
        {
            return tipo.In(
                AbstractCampoTipo.IndividualComTipagem,
                AbstractCampoTipo.IntervaloComTipagem);
        }
    }
}