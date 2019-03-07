using System;
using System.Linq;

using static System.Reflection.BindingFlags;

namespace SwitchTest.Arrangement
{
    public static class Utilites
    {
        public static bool HasImplicitConversionWith(this Type baseType, Type targetType)
        {
            return baseType.GetMethods(Public | NonPublic | Static)
                .Where(mi => mi.Name == "op_Implicit" && mi.ReturnType == targetType)
                .Select(mi => mi.GetParameters().FirstOrDefault())
                .All(pi => pi != null && pi.ParameterType == baseType);
        }
    }
}
