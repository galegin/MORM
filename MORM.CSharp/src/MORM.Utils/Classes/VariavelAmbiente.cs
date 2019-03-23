using System;

namespace MORM.Utils.Classes
{
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