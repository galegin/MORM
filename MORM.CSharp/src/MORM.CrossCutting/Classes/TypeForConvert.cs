﻿using System;

namespace MORM.CrossCutting
{
    public static class TypeForConvert
    {
        /// <summary>
        /// var objectFor = TypeForConvert.GetObjectFor(typeof(AbstractViewLista<>), classe) as AbstractViewLista;
        /// </summary>
        /// <param name="definition"></param>
        /// <param name="parameters"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static object GetObjectForArg(this Type definition, Type[] parameters, object[] args = null)
        {
            var specificType = definition.MakeGenericType(parameters);
            return Activator.CreateInstance(specificType, args);
        }

        /// <summary>
        /// var objectFor = TypeForConvert.GetObjectFor(typeof(AbstractViewLista<>), classe) as AbstractViewLista;
        /// </summary>
        /// <param name="definition"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static object GetObjectFor(this Type definition, params Type[] parameters)
        {
            return GetObjectForArg(definition, parameters);
        }

        /// <summary>
        /// var typeFor = TypeForConvert.GetTypeFor(typeof(AbstractViewLista<>), classe);
        /// </summary>
        /// <param name="definition"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Type GetTypeFor(this Type definition, params Type[] parameters)
        {
            var specificType = definition.MakeGenericType(parameters);
            return specificType;
        }
    }
}