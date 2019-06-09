namespace MORM.Dominio.Extensoes
{
    public static class SplitExtensions
    {
        public static string GetSplit(this string str, int index, char sep = '.')
        {
            var lista = str.Split(sep);
            return lista.Length >= index ? lista[index - 1] : null;
        }

        public static string GetParte(this string[] partes, int index)
        {
            if (index == -1)
                index = partes.Length - 1;
            return index < partes.Length ? partes[index] : null;
        }

        public static string[] GetLista(this string conteudo, char separador)
        {
            return
                conteudo.Contains(separador.ToString()) ?
                conteudo.Split(separador) : new string[] { conteudo };
        }
    }
}