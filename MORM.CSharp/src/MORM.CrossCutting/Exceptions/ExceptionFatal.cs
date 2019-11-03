using System;

namespace MORM.CrossCutting
{
    public class ExceptionFatal : Exception
    {
        public ExceptionFatal(string message) : base(message)
        {
        }
    }
}