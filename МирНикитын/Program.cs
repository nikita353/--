using ConsoleApp30;
using Библиотека;
using НикитынаБиблиотека.ForConsol;

class Program
{


   static ГлавныйЭкран? Главный ;
    public static void Main(string[] args)
    {
    

        Главный = ГлавныйЭкран.Создать<ГлавныйЭкранМира>();
        if(Главный is ГлавныйЭкранМира главный)
        {
            главный.Мир = new Мир();
        }


        Консоль.КонецПрограмы();
    }
}