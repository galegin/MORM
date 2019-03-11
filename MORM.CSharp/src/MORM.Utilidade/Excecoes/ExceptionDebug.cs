using System;

namespace MORM.Utilidade.Excecoes
{
    public class ExceptionDebug : Exception
    {
        public ExceptionDebug(string message) : base(message)
        {
        }
    }
}