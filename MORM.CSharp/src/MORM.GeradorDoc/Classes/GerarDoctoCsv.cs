using MORM.Utilidade.Atributos;
using MORM.Utilidade.Extensoes;

namespace MORM.GeradorDoc
{
    /// <summary>
    /// criado por MFGALEGO em 16/08/2018 11:41:30
    /// classe GerarDoctoCsv.cs
    /// funcao  geracao dicionario formato csv
    /// </summary>
    internal class GerarDoctoCsv : GerarDocto
    {
        public GerarDoctoCsv()
        {
            Formato = ".csv";
        }

        protected override string GerarValor(CampoAttribute campo, bool isTitulo = false)
        {
            if (isTitulo)
            {
                return
                    "Atributo" + ";" +
                    "TipoData" + ";" +
                    "Tipo";
            }
            else
            {
                var typeProp = campo.DataType.GetTypeNullable();

                return
                    campo.Atributo + ";" +
                    typeProp.Name + ";" +
                    campo.Tipo.ToString();
            }
        }
    }
}