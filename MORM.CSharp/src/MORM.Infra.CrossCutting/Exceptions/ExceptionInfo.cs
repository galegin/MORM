using System;

namespace MORM.Infra.CrossCutting
{
    public class ExceptionInfo : Exception
    {
        public ExceptionInfo(string message) : base(message)
        {
        }
    }
}