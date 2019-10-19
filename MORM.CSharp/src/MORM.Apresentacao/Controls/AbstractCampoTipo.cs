using MORM.CrossCutting;
using System;

namespace MORM.Apresentacao
{
    public class AbstractCampoFlagAttribute : Attribute
    {
        public bool IsIndividual { get; }
        public bool IsIntervalo { get; }
        public bool IsDescricao { get; }
        public bool IsPesquisa { get; }
        public bool IsSelecao { get; }
        public bool IsTipagem { get; }

        public AbstractCampoFlagAttribute(
            bool isIndividual = false, 
            bool isIntervalo = false, 
            bool isDescricao = false, 
            bool isPesquisa = false, 
            bool isSelecao = false, 
            bool isTipagem = false)
        {
            IsIndividual = isIndividual;
            IsIntervalo = isIntervalo;
            IsDescricao = isDescricao;
            IsPesquisa = isPesquisa;
            IsSelecao = isSelecao;
            IsTipagem = isTipagem;
        }
    }

    public enum AbstractCampoTipo
    {
        // Manutenção
        [AbstractCampoFlag(isIndividual: true)]
        Individual,
        [AbstractCampoFlag(isIndividual: true, isDescricao: true)]
        IndividualComDescricao,
        [AbstractCampoFlag(isIndividual: true, isPesquisa: true)]
        IndividualComPesquisa,
        [AbstractCampoFlag(isIndividual: true, isDescricao: true, isPesquisa: true)]
        IndividualComPesquisaEDescricao,
        [AbstractCampoFlag(isIndividual: true, isSelecao: true)]
        IndividualComSelecao,
        [AbstractCampoFlag(isIndividual: true, isTipagem: true)]
        IndividualComTipagem,

        // Filtro
        [AbstractCampoFlag(isIntervalo: true)]
        Intervalo,
        [AbstractCampoFlag(isIntervalo: true, isDescricao: true)]
        IntervaloComDescricao,
        [AbstractCampoFlag(isIntervalo: true, isPesquisa: true)]
        IntervaloComPesquisa,
        [AbstractCampoFlag(isIntervalo: true, isDescricao: true, isPesquisa: true)]
        IntervaloComPesquisaEDescricao,
        [AbstractCampoFlag(isIntervalo: true, isSelecao: true)]
        IntervaloComSelecao,
        [AbstractCampoFlag(isIntervalo: true, isTipagem: true)]
        IntervaloComTipagem,
    }

    public static class AbstractCampoTipoExtensions
    {
        public static AbstractCampoFlagAttribute GetAbstractViewTipo(this AbstractCampoTipo tipo) =>
            tipo.GetAtributeAttr<AbstractCampoTipo, AbstractCampoFlagAttribute>();
        public static bool IsDescr(this AbstractCampoTipo tipo) =>
            tipo.GetAbstractViewTipo().IsDescricao;
        public static bool IsIndiv(this AbstractCampoTipo tipo) =>
            tipo.GetAbstractViewTipo().IsIndividual;
        public static bool IsInter(this AbstractCampoTipo tipo) =>
            tipo.GetAbstractViewTipo().IsIntervalo;
        public static bool IsPesq(this AbstractCampoTipo tipo) =>
            tipo.GetAbstractViewTipo().IsPesquisa;
        public static bool IsSelecao(this AbstractCampoTipo tipo) =>
            tipo.GetAbstractViewTipo().IsSelecao;
        public static bool IsTipagem(this AbstractCampoTipo tipo) =>
            tipo.GetAbstractViewTipo().IsTipagem;
    }
}