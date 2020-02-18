using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem1_paw
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti numele: ");
            string nume = Console.ReadLine();
            Console.WriteLine("Numele este {0} ", nume);

            int[] v1 = { 1, 2, 3, 4 };

            //shallow copy
            int[] v2 = v1;
            v1[1] = 20;
            for (int i = 0; i < v2.Length; i++)
                Console.WriteLine(v2[i]);

            //deep copy
            int[] v3 = new int[v1.Length];
            for (int i = 0; i < v1.Length; i++)
                v3[i] = v1[i];
            v1[1] = 50;
            for (int i = 0; i < v3.Length; i++)
                Console.WriteLine(v3[i]);

            int[] v4 = (int[])v1.Clone();
            v1[1] = 100;
            for (int i = 0; i < v4.Length; i++)
                Console.WriteLine(v4[i]);

            //matrici
            int[,] m1 = new int[3, 4] {{1, 2, 3, 4}, {5, 6, 7, 8}, {9, 10, 11, 12}};
            for (int i = 0; i < m1.GetLength(0); i++)
            {
                for (int j = 0; j < m1.GetLength(1); j++)
                    Console.Write("{0} ", m1[i, j]);
                Console.WriteLine();
            }

            int[][] m2 = new int[2][];
            m2[0] = new int[3] { 10, 20, 30 };
            m2[1] = new int[4] { 40, 50, 60, 70 };
            for (int i = 0; i < m2.Length; i++)
            {
                for (int j = 0; j < m2[i].Length; j++)
                    Console.Write("{0} ", m2[i][j]);
                Console.WriteLine();
            }

            Student s1 = new Student();
            Student s2 = new Student(123, "Gigel", 23, 9.5f);
            Student s3 = new Student(s2);
            s3.Nume = "Dorel";
            Console.WriteLine(s3.Nume);
            s1.afisare();
            s2.afisare();
            s3.afisare();

            Student[] vs = new Student[3] { s1, s2, s3 };
            for (int i = 0; i < vs.Length; i++)
                Console.WriteLine(vs[i].ToString());
        }
    }
}
