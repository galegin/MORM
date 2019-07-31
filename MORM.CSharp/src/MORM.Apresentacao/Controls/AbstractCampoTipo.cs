using MORM.Dominio.Extensions;

namespace MORM.Apresentacao.Controls
{
    public enum AbstractCampoTipo
    {
        Individual,
        IndividualComDescricao,
        IndividualComPesquisa,
        IndividualComPesquisaEDescricao,
        Intervalo,
        IntervaloComDescricao,
        IntervaloComPesquisa,
        IntervaloComPesquisaEDescricao,
        Selecao,
        Tipagem,
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
                AbstractCampoTipo.Selecao);
        }

        public static bool IsTipagem(this AbstractCampoTipo tipo)
        {
            return tipo.In(
                AbstractCampoTipo.Tipagem);
        }

        public static AbstractCampoTipo GetCampoTipoFiltro(this string campo)
        {
            var preFixo = campo.GetLista('_').GetParte(0);
            switch (preFixo)
            {
                case "Cd_":
                    return AbstractCampoTipo.Selecao;
                case "Tp_":
                    return AbstractCampoTipo.Tipagem;
                default:
                    return AbstractCampoTipo.Intervalo;
            }
        }
    }
}