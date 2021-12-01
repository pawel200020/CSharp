using System;


namespace _03_Inheritance_Liskov
{
    class Program 
    {
        static Random rand = new();
        static public int Method(Rectangle r)
        {
            r.Width = 5;
            r.Height = 10;
            int area = r.GetArea();
            return area;
        }
        static void fillMatrix(double [,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = (double)(rand.Next(0, 90)/10);
                }
            }
        }
        static void fillComplexMatrix(Complex<double>[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = new Complex<double> { Real = (rand.Next(10, 99))/10, Imaginary = (rand.Next(10, 99)) / 10 };
                }
            }
        }
        static void Main(string[] args)
        {
            
            //3.1
            Rectangle r1 = new Rectangle { Width = 10, Height = 11 };
            Square s1 = new Square { Height = 11/*, Width =24*/};
            Console.WriteLine("Width: " + r1.Width + " Height: " + r1.Height + " Area: " + r1.GetArea());
            Console.WriteLine("Width: " + s1.Width + " Height: " + s1.Height + " Area: " + s1.GetArea());
            Console.WriteLine("-----------------------------------------------");
            ////3.2
            QueueComposition queue = new QueueComposition();
            //queue.Dequeue(); //wyjątek
            Console.WriteLine("Pushing to queue");
            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue((int)i);
            }
            Console.WriteLine("Dropping from queue");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(queue.Dequeue());
            }
            Console.WriteLine("-----------------------------------------------");
            ////3.3
            QueueCompositionArray q2 = new QueueCompositionArray();
            Console.WriteLine("Pushing to queue");
            for (int i = 0; i < 10; i++)
            {
                q2.Enqueue((int)i);
            }
            Console.WriteLine("Dropping from queue");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(q2.Dequeue());
            }
            Console.WriteLine("-----------------------------------------------");
            //3.4
            Complex<double> complexType = new Complex<double> {Real=14, Imaginary=22 };
            Console.WriteLine(complexType);
            Console.WriteLine("-----------------------------------------------");
            //3.5
            int _a_width = 6;
            int _a_height = 2;
            int _b_width = 2;
            int _b_height = 6;
            int _c_width = 6;
            int _c_height = 6;
            int _d_width = 5;
            int _d_height = 8;
            int _e_width = 5;
            int _e_height = 8;

            double[,] a = new double[_a_width, _a_height];           
            double[,] b = new double[_b_width, _b_height];
            double[,] c = new double[_c_width, _c_height];
            double[,] d = new double[_d_width, _d_height];
            double[,] e = new double[_e_width, _e_height];

            fillMatrix(a);
            fillMatrix(b);
            fillMatrix(c);
            fillMatrix(d);
            fillMatrix(e);

            Matrix<double> matrix1 = new Matrix<double>(a);
            Matrix<double> matrix2 = new Matrix<double>(b);

            Console.WriteLine();
            matrix1.Display();
            Console.WriteLine();
            matrix2.Display();
            Console.WriteLine();

            matrix1.Mult(matrix2);
            matrix1.Display();
            Console.WriteLine("-----------------------------------------------");
            Matrix<double> matrix3 = new Matrix<double>(d);
            Matrix<double> matrix4 = new Matrix<double>(e);

            Console.WriteLine();
            matrix3.Display();
            Console.WriteLine();
            matrix4.Display();
            Console.WriteLine();

            matrix3.Add(matrix4);
            matrix3.Display();

            MatrixSquare<double> square = new MatrixSquare<double>(c);
            Console.WriteLine(square.IsDiagonal());
            Console.WriteLine("-----------------------------------------------");
            //3.6

            Complex<double>[,] array1 = new Complex<double>[6, 6];
            Complex<double>[,] array2 = new Complex<double>[6, 6];

            fillComplexMatrix(array1);
            fillComplexMatrix(array2);

            MatrixComplex<Complex<double>> matrixComplex = new MatrixComplex<Complex<double>>(array1);
            MatrixComplex<Complex<double>> matrixComplex2 = new MatrixComplex<Complex<double>>(array2);

            Console.WriteLine();
            matrixComplex.Display();
            Console.WriteLine();
            matrixComplex2.Display();
            Console.WriteLine();

            matrixComplex.Add(matrixComplex2);
            matrixComplex.Display();
            Console.WriteLine();
            matrixComplex.Mult(matrixComplex2);
            matrixComplex.Display();
            Console.WriteLine("-----------------------------------------------");
        }
    }
}
