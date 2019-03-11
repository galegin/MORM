using System;

namespace MORM.Utilidade.Utils
{
    /// <summary>
    /// criado por MFGALEGO em 24/05/2018 14:53:58
    /// classe VariavelAmbiente.cs
    /// funcao variavel de ambiente
    /// </summary>
    public class VariavelAmbiente
    {
        public static void Setar(string nome, string valor)
        {
            Environment.SetEnvironmentVariable(nome, valor);
        }

        public static string Pegar(string nome)
        {
            return Environment.GetEnvironmentVariable(nome);
        }

        public static void SetarAppSetting(string nome, string valor)
        {
            if (!string.IsNullOrEmpty(valor))
                if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(nome)))
                    Environment.SetEnvironmentVariable(nome, valor);
        }
    }
}