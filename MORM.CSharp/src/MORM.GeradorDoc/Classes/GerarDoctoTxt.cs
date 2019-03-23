using MORM.Dominio.Atributos;
using MORM.Dominio.Extensoes;

namespace MORM.GeradorDoc
{
    /// <summary>
    /// criado por MFGALEGO em 16/08/2018 11:41:23
    /// classe GerarDoctoTxt.cs
    /// funcao  geracao dicionario formato texto
    /// </summary>
    internal class GerarDoctoTxt : GerarDocto
    {
        public GerarDoctoTxt()
        {
            Formato = ".txt";
        }

        protected override string GerarValor(CampoAttribute campo, bool isTitulo = false)
        {
            const int LarAtributo = 20;
            const int LarTipoData = 10;
            const int LarTipo = 4;

            if (isTitulo)
            {
                return
                    "| " + "Atributo".PadRight(LarAtributo, ' ') +
                    "| " + "TipoData".PadRight(LarTipoData, ' ') +
                    "| " + "Tipo".PadRight(LarTipo, ' ') +
                    "|";
            }
            else
            {
                var typeProp = campo.DataType.GetTypeNullable();

                return
                    "| " + campo.Atributo.PadRight(LarAtributo, ' ') +
                    "| " + typeProp.Name.PadRight(LarTipoData, ' ') +
                    "| " + campo.Tipo.ToString().PadRight(LarTipo, ' ') +
                    "|";
            }
        }
    }
}