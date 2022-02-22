using System;

namespace Z2
{
    delegate void Changing(); //делегат

    class EventClass
    {
        public event Changing ChangeName; //объявление события

        public void OnChange() //событие
        {
            if (ChangeName != null)
            {
                ChangeName();
            }
        }
    }

    class WriteInf
    {
        public void PrintName1() //обработчик события
        {
            Console.WriteLine("Название изменилось!");
        }
        public void PrintName2() //обработчик события
        {
            Console.WriteLine("Название не изменилось!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string nameAuto = "VOLKSWAGEN";
            EventClass ev = new EventClass();
            WriteInf wr = new WriteInf();

            Console.WriteLine("Название автомобиля: {0}", nameAuto);

            Console.WriteLine("Изменить название автомобиля? Y - да; Остальные символы - нет");
            ConsoleKeyInfo cki;
            cki = Console.ReadKey(true);
            if (cki.Key == ConsoleKey.Y)
            {
                Console.Write("Введите новое название: ");
                string newName = Console.ReadLine();
                nameAuto = newName;
                ev.ChangeName += new Changing(wr.PrintName1); //добавление обработчика события
                ev.OnChange(); //запуск события
            }
            else
            {
                ev.ChangeName += new Changing(wr.PrintName2); //добавление обработчика события
                ev.OnChange(); //запуск события
            }

            Console.WriteLine("Название автомобиля: {0}", nameAuto);
        }
    }
}
