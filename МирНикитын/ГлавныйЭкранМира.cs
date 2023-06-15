using ConsoleApp30.Содержимое_Мира;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Библиотека;
using НикитынаБиблиотека.ForConsol;

namespace ConsoleApp30
{

    public class ГлавныйЭкранМира : ГлавныйЭкран
    {
        int КаждыеДесять = 0;
      //  РандомИЦвета рандом = new РандомИЦвета();
        Мир? мир;
        public Мир? Мир{get => мир; set=>SetValue(ref мир, value);}

        TextConsole ВремяПрошло;
        TextConsole ВремяСейчас;
        Компановка ТериторияМира;
        public ГлавныйЭкранМира() : base()
        {
            


          
            ВремяПрошло = new TextConsole(this) { Положение = new Координата(30, 0) };
            ВремяСейчас = new TextConsole(this) { Положение = new Координата(0, 0) };

           
    
            Консоль.КнопкаКлавиатурыНажата += Консоль_КнопкаКлавиатурыНажата;
            
        }
        protected override void ИзменилосьСвойство(string PropertyName)
        {
            base.ИзменилосьСвойство(PropertyName);
            if(PropertyName== nameof(Мир) && Мир!=null)
            {
                Мир.PropertyChanged += Мир_PropertyChanged;
                ТериторияМира = new Компановка(this) { Положение = new Координата(0, 1), Размер= Мир.Размер, ЦветФона= ConsoleColor.Gray };
                if (Мир.MyUnit != null)
                {
                    TextConsole юнит = new TextConsole(){ Положение = Мир.MyUnit.Положение, ЦветФона = ConsoleColor.Blue, Text=" " };
                    ТериторияМира.ДобавитьРебёнка(юнит);
                    Мир.MyUnit.PropertyChanged += MyUnit_PropertyChanged;

                    void MyUnit_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
                    {
                        if(e.PropertyName== nameof(Unit.Положение) && sender is Unit unit)
                        {
                            юнит.Положение = unit.Положение;
                        }

                    }

                }
            }

           
        }

       

        private void Мир_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Мир.ВремяПрошло) && sender is Мир мир && ВремяПрошло != null)
            {
                
                if (мир.ВремяПрошло.TotalSeconds > КаждыеДесять)
                {
                    int РандомЦифра = РандомИЦвета.РандомЦифри(1,13);// Рандом
                    ConsoleColor цвет = РандомИЦвета.Цвета(РандомЦифра);// Тут рандом цифра стает цветом
                    ВремяПрошло.ЦветТекста = цвет;// Текст покрасился в рандом цветом
                    КаждыеДесять = КаждыеДесять + 10;// Это число задержка как цвета меняются
                }     
               ВремяПрошло.Text = $"{e.PropertyName}: {мир.ВремяПрошло}";

            }
            if (e.PropertyName == nameof(Мир.ТекущееВремя) && sender is Мир мир2 && ВремяСейчас != null)
            {
                
                ВремяСейчас.Text = $"{e.PropertyName}: {мир2.ТекущееВремя.ToLongTimeString()}";

            }
        }

       

        private void Консоль_КнопкаКлавиатурыНажата(object? sender, НикитынаБиблиотека.ForConsol.Клавиатура.KeyboardRecord e)
        {
            if(e.ConsoleKey == ConsoleKey.C)
            {
                int РандомЦифра = РандомИЦвета.РандомЦифри(1, 13);
                ConsoleColor цвет = РандомИЦвета.Цвета(РандомЦифра);
                ВремяПрошло.ЦветТекста = цвет;
            }
        }
    }
}
