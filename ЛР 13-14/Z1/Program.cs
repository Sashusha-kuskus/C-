using System;

namespace Z1
{
    class EventKeyArgs : EventArgs //аргументы для события
    {
        public ConsoleKeyInfo cki;
    }

    delegate void KeyHalder(object source, EventKeyArgs arg); //объявление делегата

    class KeyEvent //класс события
    {
        public event KeyHalder KeyPress; //объявление события

        public void OnPressKey(ConsoleKeyInfo ch) //событие
        {
            EventKeyArgs a = new EventKeyArgs();
            if (KeyPress != null)
            {
                a.cki = ch;
                KeyPress(this, a);
            }
        }
    }

    class WriteInf
    {
        public void WriteInfo(object source, EventKeyArgs arg) //обработчик события
        {
            Console.WriteLine("{0}, Символ: {1}", arg.cki.Key, arg.cki.KeyChar);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            KeyEvent ev = new KeyEvent();
            WriteInf wr = new WriteInf();
            ConsoleKeyInfo cki;
            string Str = "";
            ev.KeyPress += new KeyHalder(wr.WriteInfo); //добавление обработчика события

            Console.WriteLine("Введите несколько символов. \nДля останова нажмите F1.");
            do
            {
                Console.Write("Введите символ.");
                cki = Console.ReadKey(true);
                ev.OnPressKey(cki); //запуск события
                Str += cki.KeyChar;
            } while (cki.Key != ConsoleKey.F1);
        }
    }
}
