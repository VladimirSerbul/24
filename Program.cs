using System;
namespace ConsoleApplication22
{
    class Program
    {

        static void Main()
        {

            int n, m;
            int count = 0;
            Random rnd = new Random();

            try
            {
                Console.WriteLine("введите кол-во строк в массиве");
                n = Convert.ToInt32(Console.ReadLine());
                if (n <= 1)
                    throw new Exception("некорректно введены данные");
                Console.WriteLine("введите кол-во стобцов в массиве");
                m = Convert.ToInt32(Console.ReadLine());
                if (m <= 1)
                    throw new Exception("некорректно введены данные");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                p();
                return;
            }
            int[,] array = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                   array[i, j] = rnd.Next(1, 101);
                }
            }
            Console.WriteLine("исходный массив");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0,4}", array[i, j]);
                }
                Console.WriteLine();
            }

            for (int i = 0; i < n; i++)
            {
                int min = array[i, 0];
                int imin = 0;
                for (int j = 1; j < m; j++)
                {
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                        imin = j;
                    }
                }
                bool flag = true;
                for (int j = 0; j < m; j++)
                {
                    if (j != imin && array[i, j] == min)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    int max = array[0, imin];
                    for (int j = 1; j < n; j++)
                    {
                        if (array[j, imin] > max)
                        {
                            max = array[j, imin];
                        }
                    }
                    int b = 0;
                    for (int k = 0; k < n; k++)
                    {
                        if (array[k, imin] == max)
                            b++;
                    }
                    if (max == min && b == 1)
                    {
                        Console.WriteLine("седловая точка ({0}, {1})", i, imin);
                        count++;
                    }
                }


            }
            for (int i = 0; i < n; i++)
            {
                int max = array[i, 0];
                int imax = 0;
                for (int j = 1; j < m; j++)
                {
                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                        imax = j;
                    }
                }
                bool flag = true;
                for (int j = 0; j < m; j++)
                {
                    if (j != imax && array[i, j] == max)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    int min = array[0, imax];
                    for (int j = 1; j < n; j++)
                    {
                        if (array[j, imax] < min)
                        {
                            min = array[j, imax];
                        }
                    }
                    int b = 0;
                    for (int k = 0; k < n; k++)
                    {
                        if (array[k, imax] == min)
                            b++;
                    }
                    if (max == min && b == 1)
                    {
                        Console.WriteLine("седловая точка ({0}, {1})", i, imax);
                        count++;
                    }

                }
            }
            if (count == 0)
                Console.WriteLine("седловые точек нет");
            void p()
            {
                Console.WriteLine("повторить ввод если да то 1 нет то 0");
                string y = Convert.ToString(Console.ReadLine());
                if (y == "1")
                    Main();
                else
                    return;
            }
            p();
            return;
        }
    }

}

