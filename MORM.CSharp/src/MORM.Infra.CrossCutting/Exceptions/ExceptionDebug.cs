using System;

namespace MORM.Infra.CrossCutting
{
    public class ExceptionDebug : Exception
    {
        public ExceptionDebug(string message) : base(message)
        {
        }
    }
}