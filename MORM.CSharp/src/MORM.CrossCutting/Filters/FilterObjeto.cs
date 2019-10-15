namespace MORM.CrossCutting
{
    public class FilterObjeto
    {
        #region propriedades
        public FilterTipo Tipo { get; set; }
        public string Valor { get; set; }
        #endregion

        #region construtores
        public FilterObjeto() { }
        public FilterObjeto(FilterTipo tipo, object valor)
        {
            Tipo = tipo;
            Valor = tipo.GetValor(valor);
        }
        #endregion
    }

    public static class FilterObjetoExtensions
    {
        public static object GetObjeto<TObject>(this FilterTipo tipo, string valor)
        {
            switch (tipo)
            {
                case FilterTipo.Expressao:
                    return valor;
                case FilterTipo.Clausula:
                    return valor;
                case FilterTipo.Filtro:
                    return valor.GetObjectFromJson<TObject>();
                case FilterTipo.Model:
                    return valor.GetObjectFromJson<TObject>();
            }

            return null;
        }

        public static string GetValor(this FilterTipo tipo, object valor)
        {
            switch (tipo)
            {
                case FilterTipo.Expressao:
                    return valor as string;
                case FilterTipo.Clausula:
                    return valor as string;
                case FilterTipo.Filtro:
                    return valor?.GetJsonFromObject();
                case FilterTipo.Model:
                    return valor?.GetJsonFromObject();
            }

            return null;
        }

        public static FilterObjeto GetFilterObjeto(this object value)
        {
            return (value as string)?.GetObjectFromJson<FilterObjeto>();
        }

        public static object GetObjeto<TObject>(this FilterObjeto filter)
        {
            return filter.Tipo.GetObjeto<TObject>(filter.Valor);
        }
    }
}