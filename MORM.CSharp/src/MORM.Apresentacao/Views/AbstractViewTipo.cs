using MORM.Dominio.Extensions;
using System.ComponentModel;

namespace MORM.Apresentacao.Views
{
    public enum AbstractViewTipo
    {
        [Description("Lista")]
        Lista,
        [Description("Lista/Manutenção")]
        ListaManutencao,
        [Description("Manutenção")]
        Manutencao,
        [Description("Filtro")]
        Filtro,
    }

    public static class AbstractViewTipoExtensions
    {
        public static bool IsCadastro(this AbstractViewTipo tipo) =>
            tipo.In(AbstractViewTipo.ListaManutencao, AbstractViewTipo.Manutencao);
        public static bool IsConsulta(this AbstractViewTipo tipo) =>
            tipo.In(AbstractViewTipo.Lista, AbstractViewTipo.ListaManutencao);
        public static bool IsFiltro(this AbstractViewTipo tipo) =>
            tipo.In(AbstractViewTipo.Filtro);
        public static string GetDescription(this AbstractViewTipo tipo) =>
            tipo.GetAtributeAttr<AbstractViewTipo, DescriptionAttribute>().Description;
    }
}