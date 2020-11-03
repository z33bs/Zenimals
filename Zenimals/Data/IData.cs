using System.Collections.Generic;
using Zenimals.Models;

namespace Zenimals.Data
{
    public interface IData
    {
        IList<Animal> Data { get; }
    }
}