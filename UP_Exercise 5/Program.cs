using System;

namespace UP_Exercise_5
{
    delegate void Function();
    delegate int Operation(int a, int b);
    class First
    {
        private string str = "";
        public string Str { get { return str; } set { str = value; } }
        public void fun1()
        {
            Console.WriteLine("Работает функция fun1");
            str += "1";
        }
        public void fun2()
        {
            Console.WriteLine("Работает функция fun2");
            str += "2";
        }
        public void fun3()
        {
            Console.WriteLine("Работает функция fun3");
            str += "3";
        }
        public void fun5()
        {
            Console.WriteLine("Работает функция fun5");
            str += "5";
        }
        public void Report()
        {
            Console.WriteLine($"Работает функция Report. Итоговое значение str = {str}");
        }
    }
    class Second
    {
        public static int IntOperation(Operation op, int a, int b) => op(a, b);
    }
    class Program
    {
        static void Example(First fst, Function func)
        {
            Console.WriteLine("Работает функция Example");
            func += fst.fun5;
            func += fst.Report;
            func.Invoke();
        }
        public static int Add(int a, int b) => a + b;
        static void Main(string[] args)
        {
            Console.WriteLine("Создаётся два класса - First и Programm" +
                "\nВ классе First создано закрытое поле str и функции: fun1, fun2, fun3, fun4, Report" +
                "\nВ классе Programm рассмотрены способы добавления методов в делегат" +
                "\n\n");
            First fst = new First();
            Function fct = fst.Report;
            Function fct_sec = fst.Report;
            Console.WriteLine("\nСозданы и вызваны делегаты fct и fct_sec с методом Report\n");
            fct();
            fct_sec();
            Console.WriteLine("\n");

            Console.WriteLine("\nНачальная строка: ####, в делегат fct добавлены функции fun1, fun2, Report\n");
            fst.Str = "####";
            fct = fst.fun1;
            fct += fst.fun2;
            fct += fst.Report;
            fct();
            Console.WriteLine("\nИз делегата fct удалена функция fun2\n");
            fct -= fst.fun2;
            fct();
            Console.WriteLine("\n");

            Console.WriteLine("\nНачальная строка: ***, в делегат fct_sec добавлены функции fun2, Report, fun3, Report\n");
            fst.Str = "***";
            fct_sec = fst.fun2;
            fct_sec += fst.Report;
            fct_sec += fst.fun3;
            fct_sec += fst.Report;
            fct_sec();
            Console.WriteLine("\n");

            Console.WriteLine("\nНачальная строка: ~~~, в делегат fct добавлен делегат fct_sec\n");
            fst.Str = "~~~";
            fct += fct_sec;
            fct();
            Console.WriteLine("\n");

            Console.WriteLine("\nНачальная строка: $$$, в делегат fct добавлен метод Report, а затем экземпляр класса First и этот делегат передаются в метод Example\n");
            fst.Str = "$$$";
            fct = fst.Report;
            fct();
            Example(fst, fct);
            Console.WriteLine("\n");

            Console.WriteLine("\nСоздаётся класс Second, в котором создаётся метод IntOperation, на вход это метод получает делегат типа Operation и два числа" +
                "\nСоздаём метод Add и передаём этот делегат с числами 4 и 5 в этот метод\n");
            Operation op = Add;
            Console.WriteLine($"Результат: {Second.IntOperation(op, 4, 5)}\n");
        }
    }
}
