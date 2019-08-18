using MORM.Infra.CrossCutting;
using System;
using System.Configuration;

namespace MORM.Apresentacao.Views
{
    public class AbstractViewTipoAttribute : Attribute
    {
        public string Descricao { get; }
        public bool IsConsulta { get; }
        public bool IsCadastro { get; }
        public bool IsFiltro { get; }
        public bool IsRelatorio { get; }

        public AbstractViewTipoAttribute(string descricao,
            bool isConsulta = false, 
            bool isCadastro = false, 
            bool isFiltro = false,
            bool isRelatorio = false)
        {
            Descricao = descricao;
            IsConsulta = isConsulta;
            IsCadastro = isCadastro;
            IsFiltro = isFiltro;
            IsRelatorio = isRelatorio;
        }
    }

    public enum AbstractViewTipo
    {
        [AbstractViewTipo("Consulta", isConsulta: true)]
        Consulta,
        [AbstractViewTipo("Consulta/Relatório", isConsulta: true, isRelatorio: true)]
        ConsultaRelatorio,

        [AbstractViewTipo("Filtro", isFiltro: true)]
        Filtro,
        [AbstractViewTipo("Filtro/Lista", isConsulta: true, isCadastro: true, isFiltro: true)]
        FiltroLista,
        [AbstractViewTipo("Filtro/Lista/Manutenção", isConsulta: true, isCadastro: true, isFiltro: true)]
        FiltroListaManutencao,

        [AbstractViewTipo("Lista", isConsulta: true)]
        Lista,
        [AbstractViewTipo("Lista/Manutenção", isConsulta: true, isCadastro: true)]
        ListaManutencao,

        [AbstractViewTipo("Manutenção", isCadastro: true)]
        Manutencao,

        [AbstractViewTipo("Relatório", isRelatorio: true)]
        Relatorio,
    }

    public static class AbstractViewTipoExtensions
    {
        public static AbstractViewTipo GetAbstractViewTipo(this string value)
        {
            Enum.TryParse(value, true, out AbstractViewTipo tipo);
            return tipo;
        }

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
        public static bool IsRelatorio(this AbstractViewTipo tipo) =>
            tipo.GetAbstractViewTipo().IsRelatorio;

        public static AbstractViewTipo GetAbstractViewTipoPadrao(this AbstractViewTipo tipoDef)
        {
            var tipo = ConfigurationManager.AppSettings[nameof(AbstractViewTipo)];
            if (!string.IsNullOrWhiteSpace(tipo))
                return tipo.GetAbstractViewTipo();
            return tipoDef;
        }
    }
}