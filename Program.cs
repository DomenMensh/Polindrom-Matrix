using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = -1;
            do
            {
                Console.WriteLine("1 Оределить является ли СЛОВО полиндромом\n2 Оределить является ли ПРЕДЛОЖЕНИЕ полиндромом\n3 Вычисление определителя в квадратной матрице\n4 Для выхода нажмите 0");
                if (int.TryParse(Console.ReadLine(), out i))
                {
                    switch (i)
                    {
                        case 1:
                            Word();
                            break;
                        case 2:
                            Sentence();
                            break;
                        case 3:
                            Matrix();
                            break;
                        case 0:
                            break;
                        default:
                            Console.WriteLine("Ошибка");
                            break;
                    }
                }                
            } while (i!=0);
        }
        static void Word()
        {
            Console.WriteLine("Введите СЛОВО для проверки является ли оно полиндромом");
            string str = Console.ReadLine().ToLower();
            List<char> ar = str.ToList();
            //ar.ForEach(x => Console.Write(x + "; "));

            bool b = true;
            for (int i = 0; i < ar.Count / 2; i++)
            {
                if (ar[i] != ar[ar.Count - 1 - i])
                {
                    b = false;
                    break;
                }
            }
            if (b == true)
                Console.WriteLine("Полиндром");
            else Console.WriteLine("Не полиндром");
        }
        static void Sentence()
        {
            Console.WriteLine("Введите ПРЕДЛОЖЕНИЕ для проверки является ли оно полиндромом");
            string str = Console.ReadLine().ToLower();

            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if (Char.IsLetter(c))
                    sb.Append(c);
            }

            str = sb.ToString();
            List<char> ar = str.ToList();
            //ar.ForEach(x => Console.Write(x + ""));

            bool b = true;
            for (int i = 0; i < ar.Count / 2; i++)
            {
                if (ar[i] != ar[ar.Count - 1 - i])
                {
                    b = false;
                    break;
                }
            }
            if (b == true)
                Console.WriteLine("Полиндром");
            else Console.WriteLine("Не полиндром");
        }
        static void Matrix()
        {
            int n = 0;
            do
            {
                Console.WriteLine("Введите размерность матрицы (от 2), для выхода нажмите 0");
                if (int.TryParse(Console.ReadLine(), out n) && n > 1)
                {
                    int[,] Matrix = new int[n, n];
                    //заполнение матрицы рандомными числами
                    Random random = new Random();
                    int rand;
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            rand = random.Next(0, 9);
                            Matrix[i, j] = rand;
                        }
                    }
                    //Вывод матрицы на консоль
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            Console.Write(Matrix[i, j] + "\t");
                        }
                        Console.WriteLine();
                    }

                    switch (n)
                    {
                        case 0:
                            break;
                        case 2:
                            double det = Matrix[0, 0] * Matrix[1, 1] - Matrix[0, 1] * Matrix[1, 0];
                            Console.WriteLine($"Определитель матрицы 2-го порядка равен: {det}");                                                    
                            break;
                        case 3:
                            det = Matrix[0, 0] * Matrix[1, 1] * Matrix[2, 2] + Matrix[2, 0] * Matrix[0, 1] * Matrix[1, 2] + Matrix[1, 0] * Matrix[2, 1] * Matrix[0, 2] - Matrix[2, 0] * Matrix[1, 1] * Matrix[0, 2] - Matrix[1, 0] * Matrix[0, 1] * Matrix[2, 2] - Matrix[0, 0] * Matrix[1, 2] * Matrix[2, 1];
                            Console.WriteLine($"Определитель матрицы 3-го порядка равен: {det}");
                            break;
                        default:
                            det = Matrix[0, 0];
                            Console.WriteLine($"Определитель матрицы {n}-го порядка равен: {det}");
                            break;                                                
                    }
                }
            } while (n != 0);
        }
    }
}
