using System;

namespace BubbleSortTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n==============================================");
                Console.WriteLine("    Практическая работа: Сортировка массивов");
                Console.WriteLine("==============================================");
                Console.WriteLine("1. Задание 1: Сортировка по возрастанию");
                Console.WriteLine("2. Задание 2: Сортировка по убыванию");
                Console.WriteLine("3. Задание 3: Сортировка + вывод мин. и макс.");
                Console.WriteLine("4. Задание 4: Метод BubbleSort (на месте)");
                Console.WriteLine("5. Выполнить все задания по порядку");
                Console.WriteLine("0. Выход");
                Console.WriteLine("==============================================");
                Console.Write("Выберите пункт меню (0-5): ");

                string? choice = Console.ReadLine()?.Trim();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        RunTask1();
                        break;
                    case "2":
                        RunTask2();
                        break;
                    case "3":
                        RunTask3();
                        break;
                    case "4":
                        RunTask4();
                        break;
                    case "5":
                        RunTask1();
                        Console.WriteLine();
                        RunTask2();
                        Console.WriteLine();
                        RunTask3();
                        Console.WriteLine();
                        RunTask4();
                        break;
                    case "0":
                        Console.WriteLine("Завершение работы программы.");
                        return;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        /// <summary>
        /// Вспомогательный метод для считывания массива с консоли.
        /// </summary>
        static int[] ReadArray()
        {
            Console.Write("Введите размер массива (n) и его элементы через пробел: ");
            while (true)
            {
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.Write("Ввод не должен быть пустым. Попробуйте снова: ");
                    continue;
                }

                string[] parts = input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0)
                {
                    Console.Write("Элементы не найдены. Попробуйте снова: ");
                    continue;
                }

                if (!int.TryParse(parts[0], out int n) || n <= 0)
                {
                    Console.Write("Первое число должно быть положительным целым размером массива (n). Попробуйте снова: ");
                    continue;
                }

                int[] array = new int[n];
                int count = 0;

                for (int i = 1; i < parts.Length && count < n; i++)
                {
                    if (int.TryParse(parts[i], out int val))
                    {
                        array[count++] = val;
                    }
                }

                while (count < n)
                {
                    Console.Write($"Введите оставшиеся элементы ({n - count} шт.): ");
                    string? extraInput = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(extraInput)) continue;

                    string[] extraParts = extraInput.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var part in extraParts)
                    {
                        if (count < n && int.TryParse(part, out int val))
                        {
                            array[count++] = val;
                        }
                    }
                }

                return array;
            }
        }

        /// <summary>
        /// Вывод массива в консоль.
        /// </summary>
        static void PrintArray(int[] array)
        {
            Console.WriteLine(string.Join(" ", array));
        }

        /// <summary>
        /// Статический метод пузырьковой сортировки по возрастанию "на месте".
        /// </summary>
        static void BubbleSort(int[] a)
        {
            int n = a.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Статический метод пузырьковой сортировки по убыванию "на месте".
        /// </summary>
        static void BubbleSortDescending(int[] a)
        {
            int n = a.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (a[j] < a[j + 1])
                    {
                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Задание 1: Сортировка по возрастанию.
        /// </summary>
        static void RunTask1()
        {
            Console.WriteLine("--- Задание 1: Сортировка по возрастанию ---");
            int[] array = ReadArray();

            // Алгоритм пузырьковой сортировки по возрастанию
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            Console.Write("Отсортированный массив по возрастанию: ");
            PrintArray(array);
        }

        /// <summary>
        /// Задание 2: Сортировка по убыванию.
        /// </summary>
        static void RunTask2()
        {
            Console.WriteLine("--- Задание 2: Сортировка по убыванию ---");
            int[] array = ReadArray();

            // Алгоритм пузырьковой сортировки по убыванию (условие сравнения a[j] < a[j + 1])
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            Console.Write("Отсортированный массив по убыванию: ");
            PrintArray(array);
        }

        /// <summary>
        /// Задание 3: Сортировка по возрастанию + вывод минимального и максимального элементов.
        /// </summary>
        static void RunTask3()
        {
            Console.WriteLine("--- Задание 3: Сортировка + вывод мин. и макс. ---");
            int[] array = ReadArray();

            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            Console.Write("Отсортированный массив: ");
            PrintArray(array);
            Console.WriteLine($"Минимальный элемент (первый): {array[0]}");
            Console.WriteLine($"Максимальный элемент (последний): {array[n - 1]}");
        }

        /// <summary>
        /// Задание 4: Сортировка через отдельный метод BubbleSort(int[] a).
        /// </summary>
        static void RunTask4()
        {
            Console.WriteLine("--- Задание 4: Использование метода static void BubbleSort(int[] a) ---");
            int[] array = ReadArray();

            // Вызов отдельного метода, изменяющего массив "на месте"
            BubbleSort(array);

            Console.Write("Результат работы метода BubbleSort: ");
            PrintArray(array);
        }
    }
}
