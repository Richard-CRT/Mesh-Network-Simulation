using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTES_Mesh
{
    static class Utilities
    {
        private static Random random = new Random();

        public static int GenerateCommandId()
        {
            return Utilities.random.Next(0, 65536);
        }
    }
}
