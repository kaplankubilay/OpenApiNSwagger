using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    /// <summary>
    /// dönüş tipi olmayan "void" ler için kullanılacak interface
    /// </summary>
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
