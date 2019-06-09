﻿using System;

namespace MORM.Utils.Classes
{
    public static class TypeForConvert
    {
        public static TGen GetTypeFor<TGen>(this TGen gen, params Type[] types)
        {
            var genericType = typeof(TGen);
            var specificType = genericType.MakeGenericType(types);
            var genericObj = (TGen)Activator.CreateInstance(specificType);
            return genericObj;
        }
    }
}