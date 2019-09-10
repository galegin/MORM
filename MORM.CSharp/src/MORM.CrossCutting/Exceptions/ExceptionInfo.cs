using System;

namespace MORM.CrossCutting
{
    public class ExceptionInfo : Exception
    {
        public ExceptionInfo(string message) : base(message)
        {
        }
    }
}