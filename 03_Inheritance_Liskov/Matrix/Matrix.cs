using System;

namespace _03_Inheritance_Liskov
{
    class Matrix<T> where T : IComparable, IFormattable
    {
        public T[,] matrix;
        public Matrix(T[,] matrix)
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
        public void Mult(Matrix<T> matrix2)
        {
            if (this.matrix.GetLength(1) == matrix2.matrix.GetLength(0))
            {
                Matrix<T> result = PrepareResultMatrix(this.matrix.GetLength(0), matrix2.matrix.GetLength(1));

                for (int i = 0; i < matrix.GetLength(0); i++)
                    for (int j = 0; j < matrix2.matrix.GetLength(1); j++)
                    {
                        dynamic s = 0;
                        for (int k = 0; k < this.matrix.GetLength(1); k++)
                        {
                            dynamic a = matrix[i, k];
                            dynamic b = matrix2.matrix[k, j];
                            s += a * b;
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
        public void Add(Matrix<T> matrix2)
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
                        result.matrix[i, j] = a + b;
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
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    class MatrixSquare<T> : Matrix<T> where T : IComparable, IFormattable
    {
        public MatrixSquare(T[,] matrix) : base(matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new Exception("This is not a square matrix");
            }
        }
        public bool IsDiagonal()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i != j)
                    {
                        dynamic temp = matrix[i, j];
                        if (temp != 0)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }


    }
}

