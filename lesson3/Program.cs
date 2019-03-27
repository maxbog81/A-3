using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

//Богатов Максим
//1.Попробовать оптимизировать пузырьковую сортировку.Сравнить количество операций сравнения оптимизированной и неоптимизированной программы.
//Написать функции сортировки, которые возвращают количество операций.

namespace lesson3
{
    class Program
    {
        //Создание массива
        static int[] MyArray(int n, int min, int max)
        {
            int[] array = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                array[i] = rnd.Next(min, max);
            return array;
        }

        static void swap(ref int a, ref int b)
        {
            //int t = a;
            //a = b;
            //b = t;
            a = a ^ b;
            b = b ^ a;
            a = a ^ b;            
        }

        /* Поменять элементы местами */
        static void ShakerSwap(int[] myint, int i, int j) //swap функция обмена
        {
            int t = myint[i];
            myint[i] = myint[j];
            myint[j] = t;
        }

        //  Сортируем методом пузырька
        static long BubbleSort(int[] myarray)
        {
            long count = 0;
            for (int i = 0; i < myarray.Length; i++)
            {
                count++;
                for (int j = 0; j < myarray.Length - 1; j++)
                    if (myarray[j] > myarray[j + 1])//Сравниваем соседние элементы
                    {
                        //  Обмениваем элементы местами
                        //int t = a[j];
                        //a[j] = a[j + 1];
                        //a[j + 1] = t;
                        swap(ref myarray[j], ref myarray[j + 1]);
                        count++;

                    }
            }
            return count;
        }

        // Шейкер-сортировка
        static long ShakerSort(int[] myarray)
        {
            int left = 0, //левая граница
                right = myarray.Length - 1, //правая граница
                count = 0;

            while (left <= right)
            {
                for (int i = left; i < right; i++)  //Сдвигаем к концу массива "тяжелые элементы"
                {
                    count++;
                    if (myarray[i] > myarray[i + 1])
                    {
                        ShakerSwap(myarray, i, i + 1); //swap функция обмена
                    }
                }
                right--;// уменьшаем правую границу

                for (int i = right; i > left; i--) //Сдвигаем к началу массива "легкие элементы"
                {
                    count++;
                    if (myarray[i - 1] > myarray[i])
                    {
                        ShakerSwap(myarray, i - 1, i);//swap функция обмена
                    }
                }
                left++; // увеличиваем левую границу
            }
            return count;
        }

        static void Print(int[] myarray)
        {
            foreach (int el in myarray)
                Console.Write("{0,4}", el);
        }


        static void Main(string[] args)
        {
            //1.Попробовать оптимизировать пузырьковую сортировку.Сравнить количество операций сравнения оптимизированной и неоптимизированной программы.
            //Написать функции сортировки, которые возвращают количество операций.
            int[] a= MyArray(10, 0, 100);
            long count = 0;
            Console.WriteLine("Сортировка пузырьком\n");
            Console.WriteLine("Массив до сортировки:");
            Print(a);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            count=BubbleSort(a);
            stopwatch.Stop();            
            Console.WriteLine("\nМассив после сортировки:");
            Print(a);
            Console.WriteLine($"\nКол-во операций:{count} Время в миллисекундах:{stopwatch.ElapsedMilliseconds}");

            //2. *Реализовать шейкерную сортировку.
            a = MyArray(10, 0, 100);
            Console.WriteLine("\nШейкерная сортировка\n");
            Console.WriteLine("Массив до сортировки:");
            Print(a);
            stopwatch.Start();
            count = ShakerSort(a);
            stopwatch.Stop();
            Console.WriteLine("\nМассив после сортировки:");
            Print(a);
            Console.WriteLine($"\nКол-во операций:{count} Время в миллисекундах:{stopwatch.ElapsedMilliseconds}");
            Console.ReadKey();



        }
    }
}
