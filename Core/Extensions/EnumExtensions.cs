using Core.Attributes;

namespace Core.Extensions;

public static class EnumExtensions
{
    public static string GetParameterName(this Enum enumVal)
    {
        var type = enumVal.GetType();
        var memInfo = type.GetMember(enumVal.ToString());
        var attributes = memInfo[0].GetCustomAttributes(typeof(ParameterName), false);
        var name = (attributes[0] as ParameterName)?.Name;
        
        return name ?? string.Empty;
    }
}