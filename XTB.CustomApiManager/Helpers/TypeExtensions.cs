using System;

public static class TypeExtensions
{
    public static bool IsAnonymousType(this Type type)
    {
        return type.Name.Contains("AnonymousType");
    }

    public static bool IsNumeric(this Type type)
    {
        return type == typeof(int) || type == typeof(double) || type == typeof(float) ||
               type == typeof(decimal) || type == typeof(long) || type == typeof(short) ||
               type == typeof(byte) || type == typeof(uint) || type == typeof(ulong) ||
               type == typeof(ushort) || type == typeof(sbyte);
    }
}