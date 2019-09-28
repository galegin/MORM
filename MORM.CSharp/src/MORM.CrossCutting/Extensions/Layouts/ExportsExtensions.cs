using System.Collections.Generic;

namespace MORM.CrossCutting
{
    public static class ExportsExtensions
    {
        #region metodos
        public static string GetExport<TObject>(this IList<TObject> lista, string arquivo)
        {
            if (string.IsNullOrWhiteSpace(arquivo))
                return null;

            var exporstTipo = arquivo.GetExportsTipo();

            switch (exporstTipo)
            {
                case ExportsTipo.Csv:
                    return lista.GetCsv();
                case ExportsTipo.Edi:
                    return lista.GetEdi();
                case ExportsTipo.Json:
                    return lista.GetJsonFromObject(); // GetJson();
                case ExportsTipo.Sped:
                    return lista.GetSped();
                case ExportsTipo.Xml:
                    return lista.GetXml();
                case ExportsTipo.Zip:
                    return lista.GetExport("arquivo.json")?.GetZip();
            }

            return null;
        }
        public static IList<TObject> GetListaFromExport<TObject>(this string value, string arquivo)
        {
            if (string.IsNullOrWhiteSpace(arquivo))
                return null;

            var exporstTipo = arquivo.GetExportsTipo();
                       
            switch (exporstTipo)
            {
                case ExportsTipo.Csv:
                    return value.GetListaFromCsv<TObject>();
                case ExportsTipo.Edi:
                    return value.GetListaFromEdi<TObject>();
                case ExportsTipo.Json:
                    return value.GetListaFromJson<TObject>();
                case ExportsTipo.Sped:
                    return value.GetListaFromSped<TObject>();
                case ExportsTipo.Xml:
                    return value.GetObjectFromJson<IList<TObject>>(); // GetListaFromXml<TObject>();
                case ExportsTipo.Zip:
                    return value.GetStringFromZip()?.GetListaFromJson<TObject>();
            }

            return null;
        }
        #endregion
    }
}