using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
//Выполнил Шаронов В.А.
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
        public static void RadixSorting(int[] arr, int range, int n)
        {
            ArrayList[] lists = new ArrayList[range];
            for (int i = 0; i < range; ++i)
                lists[i] = new ArrayList();
            for (int step = 0; step < n; ++step)
            {
                for (int i = 0; i < arr.Length; ++i)
                {
                    int a = (arr[i] % (int)Math.Pow(range, step + 1)) /
                                                  (int)Math.Pow(range, step);
                    lists[a].Add(arr[i]);
                }
                int k = 0;
                for (int i = 0; i < range; ++i)
                {
                    for (int j = 0; j < lists[i].Count; ++j)
                    {
                        arr[k++] = (int)lists[i][j];                                                                                                                                                            //Выполнил Шаронов В.А.
                    }
                }
                for (int i = 0; i < range; ++i)
                    lists[i].Clear();
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

        static void ShellSort(int[] arr)
        {
            //Шелла

            //Выполнил Шаронов В.А.
            int j;
            int step = arr.Length / 2;
            while (step > 0)
            {
                for (int i = 0; i < (arr.Length - step); i++)
                {
                    j = i;
                    while ((j >= 0) && (arr[j] > arr[j + step]))
                    {
                        int tmp = arr[j];
                        arr[j] = arr[j + step];
                        arr[j + step] = tmp;
                        j -= step;
                    }
                }
                step = step / 2;
            }
        }

        static int add2pyramid(int[] arr, int i, int N)
        {
            int imax;
            int buf;
            if ((2 * i + 2) < N)
            {
                if (arr[2 * i + 1] < arr[2 * i + 2]) imax = 2 * i + 2;
                else imax = 2 * i + 1;
            }
            else imax = 2 * i + 1;
            if (imax >= N) return i;
            if (arr[i] < arr[imax])
            {
                buf = arr[i];
                arr[i] = arr[imax];
                arr[imax] = buf;
                if (imax < N / 2) i = imax;
            }
            return i;
        }

        static void Pyramid_Sort(int[] arr, int end)
        {
            //построение пирамиды
            for (int i = end / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = add2pyramid(arr, i, end);
                if (prev_i != i) ++i;
            }

            //сортировка
            int buf;
            for (int k = end - 1; k > 0; --k)
            {
                buf = arr[0];
                arr[0] = arr[k];
                arr[k] = buf;
                int i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = add2pyramid(arr, i, k);
                }
            }
        }

        static void BucketSort(int[] arr)
        {
            // Предварительная проверка элементов исходного массива
            //
            //Выполнил Шаронов В.А.

            if (arr == null || arr.Length < 2)
                return;

            // Поиск элементов с максимальным и минимальным значениями
            //

            int maxValue = arr[0];
            int minValue = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > maxValue)
                    maxValue = arr[i];

                if (arr[i] < minValue)
                    minValue = arr[i];
            }

            // Создание временного массива "карманов" в количестве,
            // достаточном для хранения всех возможных элементов,
            // чьи значения лежат в диапазоне между minValue и maxValue.
            //Выполнил Шаронов В.А.
            // Т.е. для каждого элемента массива выделяется "карман" List<int>.
            // При заполнении данных "карманов" элементы исходного не отсортированного массива
            // будут размещаться в порядке возрастания собственных значений "слева направо".
            //

            List<int>[] bucket = new List<int>[maxValue - minValue + 1];

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }

            // Занесение значений в пакеты
            //

            for (int i = 0; i < arr.Length; i++)
            {
                bucket[arr[i] - minValue].Add(arr[i]);
            }

            // Восстановление элементов в исходный массив
            //Выполнил Шаронов В.А.
            // из карманов в порядке возрастания значений
            //

            int position = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        arr[position] = bucket[i][j];
                        position++;
                    }
                }
            }
        }

        static void BucketSortRepead(int[] arr)
        {
            // Предварительная проверка элементов исходного массива
            //

            if (arr == null || arr.Length < 2)
                return;

            // Поиск элементов с максимальным и минимальным значениями
            //

            int maxValue = arr[0];
            int minValue = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > maxValue)
                    maxValue = arr[i];

                if (arr[i] < minValue)
                    minValue = arr[i];
            }

            // Создание временного массива "карманов" в количестве,
            // достаточном для хранения всех возможных элементов,
            // чьи значения лежат в диапазоне между minValue и maxValue.
            //Выполнил Шаронов В.А.
            // Т.е. для каждого элемента массива выделяется "карман" List<int>.
            // При заполнении данных "карманов" элементы исходного не отсортированного массива
            // будут размещаться в порядке возрастания собственных значений "слева направо".
            //

            List<int>[] bucket = new List<int>[maxValue - minValue + 1];

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }

            // Занесение значений в пакеты
            //

            for (int i = 0; i < arr.Length; i++)
            {
                bucket[arr[i] - minValue].Add(arr[i]);
            }

            // Восстановление элементов в исходный массив
            //Выполнил Шаронов В.А.
            // из карманов в порядке возрастания значений
            //

            int position = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        arr[position] = bucket[i][j];
                        position++;
                    }
                }
            }
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
            Console.WriteLine("Выберите метод сортировки: ");
            Console.WriteLine("1. Метод пузырька; ");
            Console.WriteLine("2. Метод выборки; ");
            Console.WriteLine("3. Метод вставок; ");
            Console.WriteLine("4. Метод быстрой сортировки;");
            Console.WriteLine("5. Метод Шелла;");
            Console.WriteLine("6. Метод пирамидальной сортировки;");
            Console.WriteLine("7. Метод карманной сортировки;");
            Console.WriteLine("8. Метод поразрядной сортировки;");
            Console.WriteLine("9. Метод карманной с повт. ключами сортировки;");
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
                case 5:
                    ShellSort(arr);
                    break;
                case 6:
                    Pyramid_Sort(arr, n);
                    break;
                case 7:
                    BucketSort(arr);
                    break;
                case 8:
                    RadixSorting(arr, 2, n);
                    break;
                case 9:
                    BucketSortRepead(arr);
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
