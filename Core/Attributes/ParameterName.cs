namespace Core.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class ParameterName : Attribute
{
    public ParameterName(string? name)
    {
        Name = name;
    }
    
    public string? Name { get; }
}