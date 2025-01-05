using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezh
{
    public interface IColorTransformer
    {
        int Transform(int[] population, int targetColor);
    }
}
