using System;

namespace MORM.Infra.CrossCutting
{
    public class ExceptionErro : Exception
    {
        public ExceptionErro(string message) : base(message)
        {
        }
    }
}