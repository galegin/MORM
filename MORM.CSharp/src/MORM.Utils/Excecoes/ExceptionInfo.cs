using System;

namespace MORM.Utils.Excecoes
{
    public class ExceptionInfo : Exception
    {
        public ExceptionInfo(string message) : base(message)
        {
        }
    }
}