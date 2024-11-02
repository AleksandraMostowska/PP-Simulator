using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Animals
{

    private string _description = "Unknown";
    public required string Description 
    { 
        get => _description; 
        init
        {
            _description = Validator.Shortener(value, 3, 15, '#');

            //value = value.Trim();

            //if (value.Length > 15) value = value[..15].Trim();

            //if (value.Length < 3) value = value.PadRight(3, '#');

            //if (char.IsLower(value[0])) value = char.ToUpper(value[0]) + value[1..];

            //_description = value;
            
        }
    }
    public uint Size { get; set; } = 3;

    public virtual string Info => $"{Description} <{Size}>";

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
}
