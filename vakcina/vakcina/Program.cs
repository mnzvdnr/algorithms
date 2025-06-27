using System;
using System.Collections.Generic;

namespace vakcina
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Введите кол-во копонентов");
            int n =int.Parse(Console.ReadLine()); //   кол-во компонентов 
            int[] lab1 = new int[n]; //время изготовления компонента в первой лаболатории
            Console.WriteLine("Введите время изготовления компонентов в первой лаболатории через 'Enter'");
            for (int i = 0; i < n; i++)
            {
                lab1[i] = int.Parse(Console.ReadLine());
            }
            int[] lab2 = new int[n]; //время изготовления компонента во второй лаболатории
            Console.WriteLine("Введите время изготовления компонентов во второй лаболатории через 'Enter'");
            for (int i = 0; i < n; i++)
            {
                lab2[i] = int.Parse(Console.ReadLine());
            }
            int[] t12 = new int[n-1]; //время перевоза компонента из первой лаболатории во вторую без учёта первого компонента
            Console.WriteLine("Введите время перевозки компонентов с первой лаболатории во вторую без учёта первого компонента через 'Enter'");
            for (int i = 0; i < n-1; i++)
            {
                t12[i] = int.Parse(Console.ReadLine());
            }
            int[] t21 = new int[n-1]; //время перевоза компонента из второй лаболатории в первую без учёта первого компонента
            Console.WriteLine("Введите время перевозки компонентов со второй лаболатории в первую без учёта первого компонента через 'Enter'");
            for (int i = 0; i < n-1; i++)
            {
                t21[i] = int.Parse(Console.ReadLine());
            }
            int[,] C = new int[2, n];
            int[,] argC = new int[2, n];
            C[0, 0] = lab1[0];
            C[1, 0] = lab2[0];
            argC[0, 0] = 1;
            argC[1, 0] = 2;
            for (int i = 0; i < n-1; i++)
            {
                if (C[0, i] + lab1[i + 1] <= C[0, i] + t21[i] + lab2[i + 1])
                {
                    C[0, i + 1] = C[0,i]+ lab1[i + 1];
                    argC[0, i+1] = 1;
                }
                else
                {
                    C[0, i + 1] = C[0, i] + t21[i] + lab2[i + 1];
                    argC[0, i + 1] = 2;
                }
            }
            for (int i = 0; i < n - 1; i++)
            {
                if (C[1,i] + lab2[i + 1] <= C[1,i] + t12[i] + lab1[i + 1])
                {
                    C[1, i + 1] = C[1, i] + lab2[i + 1];
                    argC[1, i + 1] = 2;
                }
                else
                {
                    C[1, i + 1] = C[1, i] + t12[i] + lab1[i + 1];
                    argC[1, i + 1] = 1;
                }
            }
            int c1=0;
            int c2=0;
            for(int i =0; i<n;i++)
            {
                 c1= c1 + C[0, i];
                 c2 = c2 + C[1, i];
            }
            if(c1<c2)
            {
                Console.WriteLine("минимальное время изготовление вакцины = " + c1);
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("компоненот№" + (i + 1) + " будет изготовлен в " + argC[0, i] + " лаболатории");
                }
            }
            if (c1 > c2)
            {
                Console.WriteLine("минимальное время изготовление вакцины = " + c2);
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("компоненот№" + (i + 1) + " будет изготовлен в " + argC[1, i] + " лаболатории");
                }
            }
            if (c1 == c2)
            {
                Console.WriteLine("минимальное время изготовление вакцины = " + c2);
                Console.WriteLine("минимальное время изготовления вакцины не зависит от того, с какой лаболатории начнётся изготовление вакцины");
                Console.WriteLine("возможны два варианта");
                Console.WriteLine("первый вариант:");
                for(int i =0; i<n; i++)
                {
                    Console.WriteLine("компоненот№" + (i + 1) + " будет изготовлен в " + argC[0, i] + " лаболатории");
                }
                Console.WriteLine("второй вариант:");
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("компоненот№" + (i + 1) + " будет изготовлен в " + argC[1, i] + " лаболатории");
                }

            }



        }
    }
}
