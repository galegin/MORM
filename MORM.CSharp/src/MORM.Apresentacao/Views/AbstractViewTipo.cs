using MORM.Infra.CrossCutting;
using System;

namespace MORM.Apresentacao.Views
{
    public class AbstractViewTipoAttribute : Attribute
    {
        public string Descricao { get; }
        public bool IsConsulta { get; }
        public bool IsCadastro { get; }
        public bool IsFiltro { get; }

        public AbstractViewTipoAttribute(string descricao,
            bool isConsulta = false, 
            bool isCadastro = false, 
            bool isFiltro = false)
        {
            Descricao = descricao;
            IsConsulta = isConsulta;
            IsCadastro = isCadastro;
            IsFiltro = isFiltro;
        }
    }

    public enum AbstractViewTipo
    {
        [AbstractViewTipo("Lista", isConsulta: true)]
        Lista,
        [AbstractViewTipo("Lista/Manutenção", isConsulta: true, isCadastro: true)]
        ListaManutencao,
        [AbstractViewTipo("Manutenção", isCadastro: true)]
        Manutencao,
        [AbstractViewTipo("Filtro", isFiltro: true)]
        Filtro,
        [AbstractViewTipo("Filtro/Lista", isConsulta: true, isCadastro: true, isFiltro: true)]
        FiltroLista,
        [AbstractViewTipo("Filtro/Lista/Manutenção", isConsulta: true, isCadastro: true, isFiltro: true)]
        FiltroListaManutencao,
    }

    public static class AbstractViewTipoExtensions
    {
        public static AbstractViewTipoAttribute GetAbstractViewTipo(this AbstractViewTipo tipo) =>
            tipo.GetAtributeAttr<AbstractViewTipo, AbstractViewTipoAttribute>();
        public static string GetDescricao(this AbstractViewTipo tipo) =>
            tipo.GetAbstractViewTipo().Descricao;
        public static bool IsConsulta(this AbstractViewTipo tipo) =>
            tipo.GetAbstractViewTipo().IsConsulta;
        public static bool IsCadastro(this AbstractViewTipo tipo) =>
            tipo.GetAbstractViewTipo().IsCadastro;
        public static bool IsFiltro(this AbstractViewTipo tipo) =>
            tipo.GetAbstractViewTipo().IsFiltro;
    }
}