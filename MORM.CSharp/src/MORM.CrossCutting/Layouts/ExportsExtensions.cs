using System;
using System.Collections;
using System.Collections.Generic;

namespace MORM.CrossCutting
{
    public abstract class Exports
    {
        public abstract string GetExport(IList lista, string arquivo);
        public abstract IList GetListaFromExport(string value, string arquivo);
    }

    public class Exports<TObject> : Exports where TObject : class
    {
        #region metodos
        public override string GetExport(IList lista, string arquivo)
        {
            if (string.IsNullOrWhiteSpace(arquivo))
                return null;

            var exporstTipo = arquivo.GetExportsTipo();

            switch (exporstTipo)
            {
                case ExportsTipo.Csv:
                    return (lista as IList<TObject>).GetCsv();
                case ExportsTipo.Edi:
                    return (lista as IList<TObject>).GetEdi();
                case ExportsTipo.Json:
                    return (lista as IList<TObject>).GetJson(); // GetJson();
                case ExportsTipo.Sped:
                    return (lista as IList<TObject>).GetSped();
                case ExportsTipo.Xml:
                    return lista.GetXml();
                case ExportsTipo.Zip:
                    return GetExport(lista, "arquivo.json")?.GetZip();
            }

            return null;
        }
        public override IList GetListaFromExport(string value, string arquivo)
        {
            if (string.IsNullOrWhiteSpace(arquivo))
                return null;

            var exporstTipo = arquivo.GetExportsTipo();
                       
            switch (exporstTipo)
            {
                case ExportsTipo.Csv:
                    return value.GetListaFromCsv<TObject>() as IList;
                case ExportsTipo.Edi:
                    return value.GetListaFromEdi<TObject>() as IList;
                case ExportsTipo.Json:
                    return value.GetListaFromJson<TObject>() as IList;
                case ExportsTipo.Sped:
                    return value.GetListaFromSped<TObject>() as IList;
                case ExportsTipo.Xml:
                    return value.GetObjectFromJson<IList<TObject>>() as IList; // GetListaFromXml<TObject>();
                case ExportsTipo.Zip:
                    return value.GetStringFromZip()?.GetListaFromJson<TObject>();
            }

            return null;
        }
        #endregion
    }

    public static class ExportsExtensions
    {
        public static Exports GetExports(this Type classe)
        {
            return TypeForConvert.GetObjectFor(typeof(Exports<>), classe) as Exports;
        }
    }
}