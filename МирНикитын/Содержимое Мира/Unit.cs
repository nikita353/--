using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Библиотека;
using НикитынаБиблиотека;

namespace ConsoleApp30.Содержимое_Мира
{
    public class Unit : Base
    {
        Координата положение;
        public Координата Положение {  get=> положение; set=>SetValue(ref положение, value); }
        public Unit():base()
        {
            Консоль.КнопкаКлавиатурыОтжата += Консоль_КнопкаКлавиатурыОтжата;
        }

        private void Консоль_КнопкаКлавиатурыОтжата(object? sender, НикитынаБиблиотека.ForConsol.Клавиатура.KeyboardRecord e)
        {
            if(e.ConsoleKey== ConsoleKey.UpArrow && Положение.Верх>0)
            {
                Положение = new Координата(Положение.Лево, Положение.Верх - 1);
            }
            if (e.ConsoleKey == ConsoleKey.DownArrow)
            {
                Положение = new Координата(Положение.Лево, Положение.Верх + 1);
            }
            if (e.ConsoleKey == ConsoleKey.LeftArrow && Положение.Лево>0)
            {
                Положение = new Координата(Положение.Лево-1, Положение.Верх );
            }
            if (e.ConsoleKey == ConsoleKey.RightArrow)
            {
                Положение = new Координата(Положение.Лево+1, Положение.Верх );
            }
        }
    }
}
