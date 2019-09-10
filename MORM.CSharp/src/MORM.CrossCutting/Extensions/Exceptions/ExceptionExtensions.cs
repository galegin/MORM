using System;
using System.Collections.Generic;
using System.Linq;

namespace MORM.CrossCutting
{
    public static class ExceptionExtensions
    {
        #region Metodos
        public static string GetMensagemInnerExpcetion(this Exception ex,
            bool isOnlyFirst = false, bool isOnlyLast = false, bool isStackTrace = true)
        {
            var exceptions = new List<string>();

            while (ex != null)
            {
                var stackTrace = isStackTrace ? $" / Trace : {ex.StackTrace}" : string.Empty;
                exceptions.Add($"{ex.Message}{stackTrace}");
                ex = ex.InnerException;
            }

            if ((isOnlyFirst || isOnlyLast) && exceptions.Count > 0)
                exceptions = new List<string>
                {
                    isOnlyFirst ? exceptions.FirstOrDefault() :
                    isOnlyLast ? exceptions.LastOrDefault() : null
                };

            return string.Join("\n", exceptions);
        }
        #endregion
    }
}