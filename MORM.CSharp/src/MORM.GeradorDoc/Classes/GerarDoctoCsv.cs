using MORM.Dominio.Atributos;
using MORM.Dominio.Extensoes;

namespace MORM.GeradorDoc
{
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