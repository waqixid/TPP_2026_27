

class Program
{
    static void Main()
    {
        Console.Write("Начальный баланс пользователя: ");
        double moneys = double.Parse(Console.ReadLine());
        byte n = 1;
        int i=0;
   
        string[] history = new string[100];
        
        while (n != 0 && n!=5)
        {
            Console.WriteLine("1.  Показать баланс");
            Console.WriteLine("2.  Пополнить счёт");
            Console.WriteLine("3.  Снять деньги");
            Console.WriteLine("4.  Показать историю операций");
            Console.WriteLine("5.  Выйти");
            n = byte.Parse(Console.ReadLine());
            switch(n)
            {
                case 1: 
                    PrintBalance(moneys);
                    break;
                case 2:
                    moneys+=AddMoneys(ref history, ref i);
                break;

                case 3:
                    moneys-=SubtractMoneys(moneys, ref history, ref i);
                break;

                case 4:
                    PrintHistory(history);
                break;

            }
    }
    }
    static void PrintBalance(double moneys, string optCurrency = "₽")
    {
        Console.WriteLine($"Текущий баланс: {moneys} {optCurrency}");
    }
    static double AddMoneys(ref string[] history, ref int i)
    {
        Console.WriteLine("Введите сумму для пополнения счета");
        double adds = double.Parse(Console.ReadLine());
        if (adds > 0)
        {
            Console.WriteLine("Выполнено");
            CheckHistory(ref history, i);
            history[i]=$"Пополнен счет на сумму {adds}";
            i++;
            return adds;
            
        }
        else
        {
            Console.WriteLine("Сумма некорректна");
            CheckHistory(ref history, i);
            history[i]=$"Попытка пополнить счет на сумму {adds}";
            i++;
            return 0;
        }
    }

    static double SubtractMoneys(double moneys, ref string[] history, ref int i)
    {
        Console.WriteLine("Введите сумму для снятия денег со счета");
        double mins = double.Parse(Console.ReadLine());
        if (mins > 0 && mins <= moneys)
        {
            Console.WriteLine("Выполнено");
            CheckHistory(ref history, i);
            history[i]=$"Со счета снята сумма {mins}";
            i++;
            return mins;
            
        }
        else
        {
            Console.WriteLine("Сумма некорректна");
            CheckHistory(ref history, i);
            history[i]=$"Попытка снять со счета сумму {mins}";
            i++;
            return 0;
        }
    }

    static void PrintHistory(string[] history)
    {
        for(int i=0; i<history.Length; i++)
        {
            if (history[i]==null) break;
            Console.WriteLine(history[i]);

        }
    }

    static void CheckHistory(ref string[] history, int i)
    {
        if (i == history.Length - 1)
            {
                Array.Clear(history);
            }
    }
}