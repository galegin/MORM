﻿using System;
using System.Collections.Generic;

namespace MORM.CrossCutting
{
    public class MetodoExecute
    {
        public static object Execute(Type type, object objeto, string metodo, params object[] parametros)
        {
            var metodoInvoke = type.GetMethod(metodo);
            var metodoParameters = metodoInvoke.GetParameters();
            var metodoValues = new List<object>();

            int index = 0;
            foreach (var parameter in metodoParameters)
            {
                if (index >= parametros.Length)
                    metodoValues.Add(null);
                else if (parameter.ParameterType.IsInterface)
                    metodoValues.Add(parametros[index]);
                else if (parametros[index] is FilterObjeto)
                    metodoValues.Add(parametros[index]);
                else
                    metodoValues.Add(ObjetoMapper.GetObjetoRetorno(parameter.ParameterType, parametros[index]));
                index++;
            }

            return metodoInvoke?.Invoke(objeto, metodoValues.ToArray());;
        }
    }
}