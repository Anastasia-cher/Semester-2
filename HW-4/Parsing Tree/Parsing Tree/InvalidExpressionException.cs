using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingTree;

public class InvalidExpressionException : Exception
{
    internal InvalidExpressionException(string message) 
        : base(message) { }
}
