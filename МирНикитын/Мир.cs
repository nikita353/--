using ConsoleApp30.Содержимое_Мира;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Библиотека;
using НикитынаБиблиотека;

namespace ConsoleApp30
{
    public class Мир: Base
    {
      public  Размер Размер { get; private set; }

        DateTime Начало;
        DateTime текущееВремя;
        public DateTime ТекущееВремя{ get => текущееВремя; private set => SetValue(ref текущееВремя, value); }

        TimeSpan времяПрошло;
       public TimeSpan ВремяПрошло { get => времяПрошло; private set => SetValue(ref времяПрошло, value); }

       public Unit? MyUnit { get; private set; }

        Timer? таймер;
        public Мир():base()
        {
            Начало = DateTime.Now;
            таймер = new Timer(ТмкВремени,null,100,100);
            MyUnit = new Unit() { Положение= new Координата(3,5) };
            Консоль.КнопкаКлавиатурыОтжата += Консоль_КнопкаКлавиатурыОтжата;

            Размер = new Размер(50, 15);
        }

        private void Консоль_КнопкаКлавиатурыОтжата(object? sender, НикитынаБиблиотека.ForConsol.Клавиатура.KeyboardRecord e)
        {


            if(e.ConsoleKey== ConsoleKey.P)
            {
                if (таймер != null)
                {
                    таймер.Dispose();
                    таймер = null;
                }
                else
                {
                    таймер = new Timer(ТмкВремени, null, 100, 100);
                }

            }
            
        }
        object Работает = new object();
        void ТмкВремени(object? parm)
        {
            if (Monitor.TryEnter(Работает))
            {
                ГлавныйЦик();
                Monitor.Exit(Работает);
            }
            


        }

        void ГлавныйЦик()
        {
            ВремяПрошло = DateTime.Now - Начало;
            ТекущееВремя = DateTime.Now;
        }


    }
}
