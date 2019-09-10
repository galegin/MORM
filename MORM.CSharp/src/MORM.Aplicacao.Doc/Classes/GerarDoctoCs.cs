using MORM.Dominio.Atributos;
using MORM.CrossCutting;

namespace MORM.Aplicacao.Doc
{
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