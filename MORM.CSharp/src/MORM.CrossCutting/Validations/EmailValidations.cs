using System;
using System.Text.RegularExpressions;

namespace MORM.CrossCutting
{
    public static class EmailValidations
    {
        #region constantes
        public const string EmailInvalido = "Email invalido";
        #endregion

        #region metodos
        public static void ValidarEmail(this string email)
        {
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            if (!rg.IsMatch(email))
                throw new Exception(EmailInvalido);
        }
        #endregion
    }
}