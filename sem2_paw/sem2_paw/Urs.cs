using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem2_paw
{
    class Urs : Animal
    {
        private string specie;
        private bool areCoada;

        public Urs()
            : base()
        {
            specie = "polar";
            areCoada = false;
        }

        public Urs(int v, string n, float g, string s, bool are)
            : base(v, n, g)
        {
            specie = s;
            areCoada = are;
        }

        public override string ToString()
        {
            return base.ToString() + " specia "+specie+
                " si are coada "+areCoada;
        }
    }
}
