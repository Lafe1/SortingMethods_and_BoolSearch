using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sortings
{
    class Program
    {
        static void Line(int[] arr, int start, int end, int a)
        {
            //Линейный поиск
            for (int i = start; i < end; i++)
            {
                if (a == arr[i])
                {
                    Console.WriteLine("Это " + i + " элемент");
                    break;
                }
            }
        }

        static void Bin(int[] arr, int start, int end, int a)
        {
            //Двоичный поиск
            while (start < end)
            {
                int mid = start + (end - start) / 2;
                if (a <= arr[mid]) end = mid;
                else start = mid + 1;
            }
            if(arr[end]==a)
            Console.WriteLine("Это " + end + " элемент");
        }

        static void SelectionSort(int[] arr, int start, int end)
        {
            //сортировка выборкой
            int temp, min;

            for (int i = 0; i < end - 1; i++)
            {
                min = i;

                for (int j = i + 1; j < end; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    temp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = temp;
                }
            }
        }

        static void InsertSort(int[] arr, int start, int end)
        {
            //Сортировка вставками
            int newElement, location;
            for (int i = (start+1); i < end; i++)
            {
                newElement = arr[i];
                location = i - 1;
                while (location >= 0 && arr[location] > newElement)
                {
                    arr[location + 1] = arr[location];
                    location = location - 1;
                }
                arr[location + 1] = newElement;
            }
        }

        static void Bool(int[] arr, int start, int end)
        {
            //пузырька
            int temp;
            for (int i = start; i < end; i++)
                for (int j = start; j < end; j++)
                {
                    if (arr[i] < arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
        }

        static void Partition(int[] arr, int start, int end)
        {
            //быстрая сортировка
            int temp;
            int p = arr[start+(end - start)/ 2];
            int i = start, j = end;
            while(i<=j)
            {
                while (arr[i] < p && i <= end) ++i;
                while (arr[j] > p && j >= start) --j;
                if(i<=j)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    ++i;
                    --j;
                }
            }
            if (j > start) Partition(arr, start, j);
            if (i < end) Partition(arr, i, end);

        }


        static void Main(string[] args)
        {
            Console.WriteLine("Введите кол-во элементов массива:");
            int n=int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите " + i + " элемент массива:");
                arr[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Ввыберите метод сортировки: ");
            Console.WriteLine("1. Метод пузырька; ");
            Console.WriteLine("2. Метод выборки; ");
            Console.WriteLine("3. Метод вставок; ");
            Console.WriteLine("4. Метод быстрой сортировки. ");
            int num1= int.Parse(Console.ReadLine());
            switch (num1)
            {
                case 1:
                    Bool(arr, 0, n);
                    break;
                case 2:
                    SelectionSort(arr, 0, n);
                    break;
                case 3:
                    InsertSort(arr, 0, n);
                    break;
                case 4:
                    Partition(arr, 0, n-1);
                    break;
            }
            Console.WriteLine("Отсортированный массив:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.WriteLine("Ввыберите метод поиска: ");
            Console.WriteLine("1. Линейный поиск; ");
            Console.WriteLine("2. Двоичный поиск. ");
            int num2= int.Parse(Console.ReadLine());
            Console.WriteLine("Введите нужный элемент:");
            int a = int.Parse(Console.ReadLine());
            switch (num2)
            {
                case 1:
                    Line(arr, 0, n, a);
                    break;

                case 2:
                    Bin(arr, 0, n, a);
                    break;
            }

            Console.ReadKey();
        }
    }
}
