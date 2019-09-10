using System;

namespace MORM.CrossCutting
{
    public class ExceptionDebug : Exception
    {
        public ExceptionDebug(string message) : base(message)
        {
        }
    }
}