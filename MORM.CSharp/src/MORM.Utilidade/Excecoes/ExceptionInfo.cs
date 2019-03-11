using System;

namespace MORM.Utilidade.Excecoes
{
    public class ExceptionInfo : Exception
    {
        public ExceptionInfo(string message) : base(message)
        {
        }
    }
}