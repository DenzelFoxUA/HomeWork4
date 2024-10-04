using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    public static class Task4
    {
        public static void Run()
        {
            Console.WriteLine($"Matrix A");
            Matrix matrix_A = new Matrix(3,4,"A");
            Console.WriteLine(matrix_A);

            Console.WriteLine($"Matrix B");
            Matrix matrix_B = new Matrix(3, 4, "B");
            Console.WriteLine(matrix_B);

            var matrixC = matrix_A + matrix_B;
            Console.WriteLine(matrixC);

            var matrixD = matrix_A * 2;
            Console.WriteLine(matrixD);

            var matrixG = matrixC - matrixD;
            Console.WriteLine(matrixG);

            var matrixF = new Matrix(4,2,"F");
            Console.WriteLine(matrixF);

            var matrixE = matrix_A * matrixF;
            Console.WriteLine(matrixE);
        }
    }
}
