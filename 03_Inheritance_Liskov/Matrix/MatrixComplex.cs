using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Inheritance_Liskov
{
    class MatrixComplex<T> where T : IComparable, IFormattable, new()
    {
        public T[,] matrix;
        public MatrixComplex(T[,] matrix)
        {
            this.matrix = matrix;
        }

        public T GetItem(int x, int y)
        {
            if (matrix.Length < x && matrix.GetLength(1) < y)
            {
                return matrix[x, y];
            }
            else
            {
                throw new Exception("Out of Range Index");
            }

        }
        private Matrix<T> PrepareResultMatrix(int width, int height)
        {
            T[,] array = new T[width, height];
            return new Matrix<T>(array);
        }
        public void Mult(MatrixComplex<T> matrix2)
        {
            if (this.matrix.GetLength(1) == matrix2.matrix.GetLength(0))
            {
                Matrix<T> result = PrepareResultMatrix(this.matrix.GetLength(0), matrix2.matrix.GetLength(1));

                for (int i = 0; i < matrix.GetLength(0); i++)
                    for (int j = 0; j < matrix2.matrix.GetLength(1); j++)
                    {               
                        dynamic s = new T();
                        s.Real = 0;
                        s.Imaginary = 0;
                        for (int k = 0; k < this.matrix.GetLength(1); k++)
                        {

                            dynamic a = matrix[i, k];
                            dynamic b = matrix2.matrix[k, j];
                            s.Real += a.Real * b.Real+ (b.Imaginary * a.Imaginary) * (-1);
                            s.Imaginary += a.Real * b.Imaginary + b.Real * a.Imaginary;
                        }
                        result.matrix[i, j] = s;
                    }
                this.matrix = result.matrix;
            }
            else
            {
                throw new Exception("Operation cannot be done");
            }
        }
        public void Add(MatrixComplex<T> matrix2)
        {
            if (matrix.GetLength(0) == matrix2.matrix.GetLength(0) && matrix.GetLength(1) == matrix2.matrix.GetLength(1))
            {
                Matrix<T> result = PrepareResultMatrix(matrix.GetLength(0), matrix.GetLength(1));
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        dynamic a = matrix[i, j];
                        dynamic b = matrix2.matrix[i, j];
                        a.Real += b.Real;
                        a.Imaginary += b.Imaginary;
                        result.matrix[i, j] = a;
                    }
                }
                this.matrix = result.matrix;
            }
            else
            {
                throw new Exception("Operation cannot be done");
            }
        }
        public void Display()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                    Console.Write("   ");
                }
                Console.WriteLine();
            }
        }
    }
}
