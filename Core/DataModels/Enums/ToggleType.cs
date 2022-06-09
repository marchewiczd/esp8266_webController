using System.ComponentModel;
using System.Runtime.InteropServices;
using Core.Attributes;

namespace Core.DataModels.Enums;

public enum ToggleType
{
    [ParameterName("toggle")]
    Toggle,
    
    [ParameterName("on")]
    On,
    
    [ParameterName("off")]
    Off
}