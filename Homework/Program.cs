// Выполнил Чернышев Денис
// Все задачи + полностью дополнительное 3 задние выполнено

using System;

namespace Homework
{
    #region Стуктура для комплексных чисел
    struct Complex
    {
        public double im;
        public double re;
        // Сложение двух комплексных чисел
        public Complex Plus(Complex x)
        {
            Complex y;
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }
        // Вычитание двух комплексных чисел
        public Complex Subtraction(Complex x)
        {
            Complex y;
            y.im = im - x.im;
            y.re = re - x.re;
            return y;
        }
        // Произведения двух комплексных чисел
        public Complex Multi(Complex x)
        {
            Complex y;
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }
        public string ToString()
        {
            return re + "+" + im + "i";
        }
    }
    #endregion
    #region Класс для комплексных чисел
    class ComplexClass
    {
        private double re;
        private double im;

        public double Re
        {
            get
            {
                return re;
            }

            set
            {
                re = value;
            }
        }

        public double Im
        {
            get
            {
                return im;
            }

            set
            {
                if (value == 0)
                {
                    throw new Exception("На ноль делить нельзя!");
                }
                im = value;
            }
        }

        public ComplexClass()
        {

        }

        public ComplexClass(double newRe, double newIm)
        {
            if (newIm == 0)
            {
                throw new Exception("На ноль делить нельзя!");
            }

            im = newIm;
            re = newRe;

        }

        public ComplexClass Plus(ComplexClass complex)
        {
            return new ComplexClass(re + complex.re, im + complex.im);
        }
        public ComplexClass Subtraction(ComplexClass complex)
        {
            return new ComplexClass(complex.re - re, complex.im - im);
        }
        public ComplexClass Multi(ComplexClass complex)
        {
            return new ComplexClass(re * complex.re - im * complex.im, re * complex.im + im * complex.re);
        }
        public override string ToString()
        {
            base.ToString();
            return $"{re} + {im}i";
        }
    }
    #endregion
    class Fractions
    {
        private int numerator;
        private int denominator;

        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }
        public int Denominator
        {
            get { return denominator; }
            set { numerator = value; }
        }
        public decimal getDecimalFraction()             //Возвращаю десятичную дробь числа
        {
            return (decimal)numerator / (decimal)denominator;
        }

        public Fractions()
        {

        }
        public Fractions(int newNum, int newDenum)
        {
            if (newDenum == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен 0");          //Проверка, чтобы знаменатель не равнялся 0. 
            }

            numerator = newNum;
            denominator = newDenum;
        }

        public Fractions Plus(Fractions fractions)
        {
            if (fractions.denominator != denominator)           //привожу дроби к общему знаменателю
            {
                numerator *= fractions.denominator;
                fractions.numerator *= denominator;
                
                denominator *= fractions.denominator;
                fractions.denominator = denominator;
            }
            return new Fractions(numerator + fractions.numerator, denominator);
        }
        public Fractions Subtraction(Fractions fractions)
        {
            if (fractions.denominator != denominator)           //привожу дроби к общему знаменателю
            {
                numerator *= fractions.denominator;
                fractions.numerator *= denominator;

                denominator *= fractions.denominator;
                fractions.denominator = denominator;
            }
            return new Fractions(numerator - fractions.numerator, denominator);
        }
        public Fractions Multi(Fractions fractions)
        {
            return new Fractions(numerator * fractions.numerator, denominator * fractions.denominator);
        }
        public Fractions Share(Fractions fractions)
        {
            return new Fractions(denominator * fractions.numerator, numerator * fractions.denominator);
        }

        public override string ToString()           //Привожу дроби к упрощеному виду 10/100 == 1/10
        {
            int flag = 10;
            while (flag != 1)           
            {
                if (numerator % flag == 0 && denominator % flag == 0)
                {
                    numerator /= flag;
                    denominator /= flag;
                }
                else
                    flag--;
            }
            return $"{numerator}/{denominator}";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            #region Task1() Работа с комплексными числами
            int flag = 0;
            while (flag != 1)
            {
                Console.Clear();
                Console.WriteLine("Работа с комплексными числами. Введите число. Для выхода введите любое число кроме 1 и 2.");
                Console.WriteLine("=================================================");
                Console.WriteLine("| 1. Работа с комплексными числами через структуру");
                Console.WriteLine("| 2. Работа с комплексными числами через класс");
                Console.WriteLine("=================================================");
                Console.WriteLine();
                int m = int.Parse(Console.ReadLine());
                switch (m)
                {
                    case 1:
                        Complex();
                        break;
                    case 2:
                        ComplexClass();
                        break;
                    default:
                        Console.WriteLine("Конец программы");
                        Console.WriteLine("Нажмите любую клавишу...");
                        Console.ReadKey();
                        flag++;
                        break;
                }
            }

            Console.Clear();
            #endregion 
            Task2();    //С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). Требуется подсчитать сумму всех нечётных положительных чисел.
            Task3();    //Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. Предусмотреть методы сложения, вычитания, умножения и деления дробей.
        }

        private static void Task3()
        {
            Console.WriteLine("Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. Предусмотреть методы сложения, вычитания, умножения и деления дробей.");
            Console.WriteLine();
            Fractions fractions01 = new Fractions(1,9);
            Fractions fractions02 = new Fractions(-2, 10);

            Fractions fractions03 = fractions02.Plus(fractions01);
            Console.WriteLine($"Результат сложения дробных чисел {fractions01} и {fractions02} : {fractions03}");

            Fractions fractions04 = fractions02.Subtraction(fractions01);
            Console.WriteLine($"Результат вычитания дробных чисел {fractions01} и {fractions02} : {fractions04}");

            Fractions fractions05 = fractions02.Multi(fractions01);
            Console.WriteLine($"Результат умножения дробных чисел {fractions01} и {fractions02} : {fractions05}");

            Fractions fractions06 = fractions02.Share(fractions01);
            Console.WriteLine($"Результат деления дробных чисел {fractions01} и {fractions02} : {fractions06}");
            Console.WriteLine("Нажмите любую клвишу...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Введите числитель и знаменатель через enter...");

            int num = int.Parse(Console.ReadLine());
            int denum = int.Parse(Console.ReadLine());
            Fractions dec = new Fractions(num, denum);
            Console.WriteLine($"Десятичная дробь числа = {dec.getDecimalFraction()};");

            Console.ReadLine();
        }

        private static void Task2()
        {
            Console.WriteLine("С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). Требуется подсчитать сумму всех нечётных положительных чисел.");
            Console.WriteLine();
            int sum = 0;
            Console.WriteLine("Введите числа по почереди, через enter...");
            do
            {
                string input = Console.ReadLine();

                bool result = int.TryParse(input, out var number);
                if (result == true && number != 0)
                {
                    if (number > 0 && number%2 == 1)
                        sum += number;
                }
                else
                    break;
            } while (true);

            Console.WriteLine($"Сумма нечётных положительных чисел = {sum}");
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void ComplexClass()
        {
            ComplexClass complex01 = new ComplexClass(0, 5);
            ComplexClass complex02 = new ComplexClass(-2, 4);

            ComplexClass complex03 = complex02.Plus(complex01);
            Console.WriteLine($"Результат сложения комплексных чисел {complex01} и {complex02} : {complex03}");

            ComplexClass complex04 = complex02.Subtraction(complex01);
            Console.WriteLine($"Результат вычитания комплексных чисел {complex01} и {complex02} : {complex04}");

            ComplexClass complex05 = complex02.Multi(complex01);
            Console.WriteLine($"Результат умножения комплексных чисел {complex01} и {complex02} : {complex05}");

            Console.ReadLine();
        }

        private static void Complex()
        {
            Complex complex1;
            complex1.re = 0;
            complex1.im = 5;

            Complex complex2;
            complex2.re = -2;
            complex2.im = 4;

            Complex result = complex1.Plus(complex2);
            Console.WriteLine($"Сложение: {result.ToString()}");

            result = complex1.Multi(complex2);
            Console.WriteLine($"Умножение: {result.ToString()}");

            result = complex1.Subtraction(complex2);
            Console.WriteLine($"Вычитание: {result.ToString()}");

            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
