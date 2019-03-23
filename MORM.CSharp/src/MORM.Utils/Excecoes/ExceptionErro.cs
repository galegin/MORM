using System;

namespace MORM.Utils.Excecoes
{
    public class ExceptionErro : Exception
    {
        public ExceptionErro(string message) : base(message)
        {
        }
    }
}