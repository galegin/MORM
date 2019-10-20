using System;

namespace MORM.CrossCutting
{
    public enum FilterTipo
    {
        Expressao,
        Clausula,
        Filtro,
        Model
    }

    public class FilterObjeto
    {
        #region propriedades
        public FilterTipo Tipo { get; set; }
        public Type ElementType { get; set; }
        public string Valor { get; set; }
        #endregion

        #region construtores
        public FilterObjeto() { }
        public FilterObjeto(FilterTipo tipo, Type elementType, object valor)
        {
            Tipo = tipo;
            ElementType = elementType;
            Valor = tipo.GetValor(valor);
        }
        #endregion
    }

    public static class FilterObjetoExtensions
    {
        public static Type GetTypeObjeto(this object filtro)
        {
            return (filtro is FilterObjeto) 
                ? (filtro as FilterObjeto).ElementType
                : filtro.GetType()
                ;
        }

        public static object GetFiltroObjeto(this object filtro)
        {
            return (filtro is FilterObjeto)
                ? (filtro as FilterObjeto)?.GetObjeto()
                : filtro
                ;
        }

        public static object GetObjeto(this FilterTipo tipo, Type elementType, string valor)
        {
            switch (tipo)
            {
                case FilterTipo.Expressao:
                case FilterTipo.Clausula:
                    return valor.GetObjetoExpressao(elementType);
                case FilterTipo.Filtro:
                case FilterTipo.Model:
                    return valor.GetObjectFromJson(elementType);
            }

            return null;
        }

        private static object GetObjetoExpressao(this string valor, Type elementType)
        {
            var objeto = Activator.CreateInstance(elementType);
            var campoDes = elementType.GetCampoDes();
            if (!string.IsNullOrWhiteSpace(valor))
                objeto.SetInstancePropOrField(campoDes, $"%{valor.Replace(" ", "%")}%");
            return objeto;
        }

        public static string GetValor(this FilterTipo tipo, object valor)
        {
            switch (tipo)
            {
                case FilterTipo.Expressao:
                case FilterTipo.Clausula:
                    return valor as string;
                case FilterTipo.Filtro:
                case FilterTipo.Model:
                    return valor?.GetJson();
            }

            return null;
        }

        public static FilterObjeto GetFilterObjeto(this object value)
        {
            return (value as string)?.GetObjectFromJson<FilterObjeto>();
        }

        public static object GetObjeto(this FilterObjeto filter)
        {
            return filter.Tipo.GetObjeto(filter.ElementType, filter.Valor);
        }

        public static TObject GetObjeto<TObject>(this FilterObjeto filter) where TObject : class
        {
            return filter.Tipo.GetObjeto(filter.ElementType, filter.Valor) as TObject;
        }
    }
}