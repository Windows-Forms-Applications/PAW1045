using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem3_paw
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();
            Student s2 = new Student(123, 'M', 23, "Gigel",
                new int[3] { 7, 8, 10 });
            Student s3 = (Student)s2.Clone();
            Console.WriteLine(s1);
            s2 = s2 + 10;
            s2 += 5;
            s2++;
            Console.WriteLine("Media lui s2 este: " + (float)s2);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
            s2.SpuneAnNastere();
            Console.WriteLine("A 2-a nota a lui s2 este: " + s2[1]);
            s2[5] = 5;
            Console.WriteLine(s2);

            List<Student> listaStud = new List<Student>();
            listaStud.Add(s3);
            listaStud.Add(s2);
            listaStud.Add(s1);
            listaStud.Sort();
            foreach (Student s in listaStud)
                Console.WriteLine(s);

            Form1 frm = new Form1();
            frm.ShowDialog();
        }
    }
}
