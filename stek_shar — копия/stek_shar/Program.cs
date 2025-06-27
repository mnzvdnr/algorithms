using System;



namespace stek_shar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество этажей ");
            long n = long.Parse(Console.ReadLine());//кол-во этажей
            Console.WriteLine("Введите количество шаров");
            long k = long.Parse(Console.ReadLine());//кол-во шаров
            long C = 0;//кол-во попыток которое потребуется
            long k0 = 0; //кол-во шаров которое потребуется
            k = (long)Math.Log(n + 1, 2);
            long[,] c = new long[n+1, k+1]; //матрица строки-попытки(изначально кол-во этажей); столбцы - шары 
            for (long i = 0; i < k; i++)
            {
                c[0, i] = 1;
            }
            for (long i = 1; i < n; i++)
            {
                c[i, 0] = i+1 ;
            }
            for (long i = 1; i < n; i++)
            {
                for (long j = 1; j < k; j++)
                {
                    c[i, j] = c[i - 1, j - 1] + 1 + c[i - 1, j];

                }
            }
            for (long i = 0; i < n; i++)
            {
                for (long j = 0; j < k; j++)
                {
                    if (c[i, j] >= n)
                    {
                        C = i+1 ;//номер строки - количество попыток которое потребуется
                        k0 = j+1; //номер столбца кол-во шаров которое потребуется
                        break;
                    }
                }
                if (C > 0)
                    break;
            }
            for (long i = 0; i < n; i++)
            {
                Console.WriteLine();
                for (long j = 0; j < k0; j++)
                {
                    Console.Write(c[i, j] + " ");
                }
            }
            Console.WriteLine("количество попыток, которое понадобиться в худшем случае при оптимальном решении = " + C);
            Console.WriteLine("количество шаров, которое потребуется = " + k0);
            int z = 1;
            long nk = c[C-2, k0-2] + 1;// откуда начинать юросать 
            long nk0 = nk;
            long C0=C;
            long k00=k0;
            while (C!=0)
            { 
                string proverka;
                Console.WriteLine("Попытка №" + z + " из" + C + "попыток");
                Console.WriteLine("начинайте кидать с " + nk0);
                Console.WriteLine("Шар разбился ?");
                C0 = C0 - 1; //строки
                k00 = k00 - 1; //столбцы
                proverka = Console.ReadLine();
                if (proverka=="да")
                {
                    if(k00==1)
                    {
                        Console.WriteLine("У вас остался один шар. Начинайте кидать с первого этажа до тех пор пока шар не разобъётся, у вас осталось " + C0 + " попыток и " + (nk0 - 1) + "этажа(-ей)");
                        break;
                    }

                    nk0 = c[C0 - 2, k00 - 2] + 1;
                    z++;
                }
                long l;
                if (proverka == "нет")
                {
                    z++;
                    l = n - nk0;
                    if (k00 == 1)
                    {
                        Console.WriteLine("У вас остался один шар. Начинайте кидать с " +(nk0+1)+ " этажа до тех пор пока шар не разобъётся, у вас осталось " + C0 + " попыток и " + l + "этажа(-ей)");
                        break;
                    }
                    C0 = 0;
                    for (long i = 0; i < l; i++)
                    {
                        for (long j = 0; j < k0; j++)
                        {
                            
                            if (c[i, j] >= l)
                            {
                                C0 = i;//номер строки - количество попыток которое потребуется
                                k00 = j; //номер столбца кол-во шаров которое потребуется
                                break;
                            }
                        }
                        if (C0 > 0)
                            break;
                    }
                    nk0= c[C0-1, k00-1]+1+nk0;
                }

                    



            }
             

        }
    }
}
