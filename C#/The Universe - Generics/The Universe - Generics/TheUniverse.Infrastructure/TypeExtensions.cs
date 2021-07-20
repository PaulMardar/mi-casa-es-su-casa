using System;
using System.Linq;

namespace iQuest.TheUniverse.Infrastructure
{
    internal static class TypeExtensions
    {
        public static bool ImplementsInterface(this Type type, Type implementedInterface)
        {
            if (implementedInterface.IsGenericType)
            {
                return type.GetInterfaces()
                    .Where(x => x.IsGenericType)
                    .Select(x => x.GetGenericTypeDefinition())
                    .Contains(implementedInterface);
            }
            else
            {
                return implementedInterface.IsAssignableFrom(type);
            }
        }
    }
}