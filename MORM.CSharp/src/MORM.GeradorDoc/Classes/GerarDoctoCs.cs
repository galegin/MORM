using MORM.Utilidade.Atributos;
using MORM.Utilidade.Extensoes;

namespace MORM.GeradorDoc
{
    /// <summary>
    /// criado por MFGALEGO em 16/08/2018 11:41:44
    /// classe GerarDoctoCs.cs
    /// funcao geracao dicionario formato C#
    /// </summary>
    internal class GerarDoctoCs : GerarDocto
    {
        public GerarDoctoCs()
        {
            Formato = ".cs";
        }

        protected override string GerarValor(CampoAttribute campo, bool isTitulo = false)
        {
            if (isTitulo)
            {
                return string.Empty;
            }
            else
            {
                var typeProp = campo.DataType.GetTypeNullable();

                return
                    "public " +
                    typeProp.Name + (campo.Tipo == CampoTipo.Nul ? "?" : string.Empty) + " " +
                    campo.Atributo + " " +
                    "{ get; set; } ";
            }
        }
    }
}