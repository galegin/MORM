using System;

namespace MORM.Utilidade.Excecoes
{
    public class ExceptionErro : Exception
    {
        public ExceptionErro(string message) : base(message)
        {
        }
    }
}