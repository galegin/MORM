﻿using System;

namespace MORM.CrossCutting
{
    public static class Check
    {
        #region metodos
        /// <summary>
        /// Verifica se o valor do tipo String não é nulo ou Vazio e, caso contrário, 
        /// é um ArgumentNullException ou ArgumentException.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public static string NotEmpty(string value, string paramName)
        {
            return !string.IsNullOrWhiteSpace(value) ? value
                : throw new ArgumentNullException(paramName);
        }

        /// <summary>
        /// Verifica se o valor do tipo T não é nulo e gera uma ArgumentNullException.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public static T NotNull<T>(T value, string paramName)
        {
            return value != null ? value
                : throw new ArgumentNullException(paramName);
        }

        /// <summary>
        /// Verifica se a condição é verdadeira e lança uma ArgumentOutOfRangeException
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        public static void That(bool condition, string paramName, string message)
        {
            var value = condition ? throw new ArgumentOutOfRangeException(paramName, message) 
                : string.Empty;
        }

        /// <summary>
        /// Verifica se o predicado é avaliado como true e lança uma ArgumentOutOfRangeException
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        public static void That(Func<bool> predicate, string paramName, string message)
        {
            var value  = predicate.Invoke() ? throw new ArgumentOutOfRangeException(paramName, message) 
                : string.Empty;
        }
        #endregion
    }
}