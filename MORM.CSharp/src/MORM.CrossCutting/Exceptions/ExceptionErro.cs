using System;

namespace MORM.CrossCutting
{
    public class ExceptionErro : Exception
    {
        public ExceptionErro(string message) : base(message)
        {
        }
    }
}