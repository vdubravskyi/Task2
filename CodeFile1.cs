using System;
using System.Collections.Generic;

/*Написати програму для визначення кількості 2N-значних “щасливих” квитків, в яких сума
перших N цифр дорівнює сумі других N цифр.N - довільне натуральне число.*/
delegate int Func(int i);

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

        /* Console.Write("Number of hapy tickets(the first algorithm): ");
         Console.WriteLine(Variant1(N));

         Console.Write("Number of hapy tickets(the second algorithm): ");
         Console.WriteLine(Variant2(N));*/

        //Console.Write("Number of happy tickets(the third algorithm): ");
        //Console.WriteLine(Variant3(N));
        Console.Write("Number of happy tickets(the fourth algorithm): ");
        Console.WriteLine(Variant4(N));

        Console.WriteLine();

    }

    //Метод, який реалізовує перший алгоритм
    static long Variant1(int N)
    {
        string str = "";
        long min, max;
        long firstPart = 0, secondPart = 0, count = 0, n = N * 2;

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
    //Метод, який реалізовує третій алгоритм
    public static long Variant3(int N)
    {
        long count = 0;
        int n = (int)Math.Pow(10, N);//Змінна, яка містить в собі кількість можливих цифр в половині номера квитка
        string str = "";
        string[] g = new string[N];
        long[] amounts = new long[n];//У цьому масиві я зберігаю всі суми цифр чисел від 0 до n - 1

        for (int i = 0; i < n; i++)
        {
            str += i;
            for (short j = 0; j < str.Length; j++)
                amounts[i] += str[j] - 48; //Звертаюсь на пряму до кодів символів
            str = "";
        }

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                if (amounts[i] == amounts[j])
                    count++;
        return count;
    }
   //Метод, який реалізовує четвертий алгоритм (найшвидший)
   static long Variant4(int N)
    {
        int[] counts = new int[N * 9 + 1];
        long n =(long) Math.Pow(10, N);
        long count = 0;

        Func sum = x =>
        {
            int amount = 0;
            while (x != 0)
            {
                amount += x % 10;
                x = x / 10;
            }
            return amount;
        };

        for (int i = 0; i <= N * 9; i++)
            counts[i] = 0;

        for (int i = 0; i < n; i++)
            counts[sum(i)]++;

        for (int i = 0; i <= N * 9; i++)
            count += (counts[i] * counts[i]);
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