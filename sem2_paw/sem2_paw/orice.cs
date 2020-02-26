using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem2_paw
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal a1 = new Animal();
            Animal a2 = new Animal(12, "Grivei", 14.5f);
            Animal a3 = new Animal(a2);
            a3.Nume = "Azorel";
            Console.WriteLine(a3.Nume);

            Console.WriteLine(a1.ToString());
            Console.WriteLine(a2);
            Console.WriteLine(a3);

            Animal a4 = (Animal)a3.Clone();
            a4.Varsta = 9;
            Console.WriteLine(a4);

            Urs u1 = new Urs(15, "Balloo", 200, "grizzly", true);
            Console.WriteLine(u1);

            Leu l1 = new Leu(10, "Simba", 60, "bej", true);
            Console.WriteLine(l1);

            Zoo z1 = new Zoo();
            z1.ListaAnimale.Add(a1);
            z1.ListaAnimale.Add(a2);
            z1.ListaAnimale.Add(a3);
            z1.ListaAnimale.Add(a4);
            z1.ListaAnimale.Add(u1);
            z1.ListaAnimale.Add(l1);
            Console.WriteLine(z1);

            Zoo z2 = (Zoo)z1.Clone();
            z2.Denumire = "Baneasa";
            foreach (Animal a in z2.ListaAnimale)
                a.Nume += " de Bucuresti";
            z1.ListaAnimale.Sort();
            Console.WriteLine(z1);
            z2.ListaAnimale.Sort();
            Console.WriteLine(z2);
            Console.WriteLine("-----------------");
            Console.WriteLine(z2[3]);
        }
    }
}
