using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem2_paw
{
    class Leu: Animal 
    {
        private string culoare;
        private bool areCoama;

        public Leu()
            : base()
        {
            culoare = "alb";
            areCoama = true;
        }

        public Leu(int v, string n, float g, string c, bool are)
            : base(v, n, g)
        {
            culoare = c;
            areCoama = are;
        }

        public override string ToString()
        {
            return base.ToString() + " culoare "+culoare+
                " si are coama "+areCoama;
        }
    }
}
