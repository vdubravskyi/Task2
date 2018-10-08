using System;
using System.Collections.Generic;

/*Написати програму для визначення кількості 2N-значних “щасливих” квитків, в яких сума
перших N цифр дорівнює сумі других N цифр.N - довільне натуральне число.*/

class MyClass
{

    static void Main()
    {
        int N;

        Console.Write("Enter N: ");
        //Введення
        try
        {
            N = int.Parse(Console.ReadLine());
            if (N <= 0)
                throw new Exception();
        }
        catch (Exception)
        {
            Console.WriteLine("N must be > 0 and digit");
            N = int.Parse(Console.ReadLine());
        }
        Console.WriteLine();

        Console.Write("A number of lucky tickets(first algorithm): ");
        Console.WriteLine(Variant1(N));

        Console.Write("A number of lucky tickets(first algorithm): ");
        Console.WriteLine(Variant2(N));

        Console.WriteLine();

    }
    //Метод, який реалізовує перший алгоритм
    static int Variant1(int N)
    {
        string str = "";
        long min, max;
        int firstPart = 0, secondPart = 0, count = 0, n = N * 2;

        min = NumberOfOperations(N, out max);

        for (long i = min; i <= max; i++, firstPart = 0, secondPart = 0, str = "")
        {
            str += i;
            for (int j = 0; j < n; j++)
            {
                if (j < N)
                    firstPart += str[j] - 48;//Сумування першої частини (str[j] повертає код цифри у таблиці ASCII(код 0 - 48)
                else
                    secondPart += str[j] - 48;//Сумування другої частини
            }
            if (firstPart == secondPart)
                count++;
        }
        return count;
    }
    //Метод, який реалізовує другий алгоритм
    static int Variant2(int N)
    {
        long min, max;
        int count = 0, n = N * 2;
        long firstPart = 0, secondPart = 0;

        min = NumberOfOperations(N, out max);

        for (long i = min, h; i <= max; i++, firstPart = 0, secondPart = 0)
        {
            h = i;
            for (int j = 0; j < n; j++)
            {
                if (j < N)
                    firstPart += h % 10;//Сумування першої частини
                else
                    secondPart += h % 10;//Сумування другої частини
                h = h / 10;//перехід на попередню цифру номера
            }
            if (firstPart == secondPart)
                count++;
        }

        return count;
    }
    //Метод, який визначає найменший і найбільший номер квитка, залежно від к-сті цифр в його номері 
    static long NumberOfOperations(int N, out long max)
    {
        long min = 10;
        max = 99;

        for (int i = 1; i < N; i++)
        {
            min *= 100;
            max = max * 100 + 99;
        }

        return min;
    }
}