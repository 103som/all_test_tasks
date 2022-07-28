using System;
using System.Globalization;

class Program
{
    static readonly IFormatProvider _ifp = CultureInfo.InvariantCulture;
    
    /// <summary>
    /// Возможное решение, при котором требуется слегка поменять реализацию main.(При этом будет работать не только с параметрами типа int,
    /// а также с произвольными числовыми параметрами(которые мы определим внутри класса)).
    /// Нужно в main поменять строку на : string result = new Number<int>(someValue1) + someValue2.ToString(_ifp);
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /*
    class Number<T>
    {
        readonly T _number;

        static Number()
        {
            // В c# пока что нет встроенного ограничения на оператор сложения, поэтому вместо использования
            // (where: ) - искусствено ограничим количество возможно используемых типов.
            if (typeof(T) != typeof(int) &&
                typeof(T) != typeof(long) &&
                typeof(T) != typeof(ulong) &&
                typeof(T) != typeof(uint) &&
                typeof(T) != typeof(double))
                throw new NotSupportedException(
                    "Bounds<> can be instantiated only with types int, long, uint, ulong, double.");
        }
        public Number(T number)
        {
            _number = number;
        }

        public override string ToString()
        {
            uint b = 5;
            b.ToString((_ifp));
            return ((dynamic)_number).ToString(_ifp);
        }
        
        public static Number<T> operator +(Number<T> n1, T n2)
        {
            return new Number<T>((dynamic)n1._number + n2);
        }
    }
    */
    
    /// <summary>
    /// Без каких-либо изменений в других местах, просто и по делу.
    /// </summary>
    class Number
    {
        readonly int _number;

        public Number(int number)
        {
            _number = number;
        }

        public override string ToString()
        {
            return _number.ToString(_ifp);
        }
        
        public static Number operator +(Number n1, int n2)
        {
            return new Number(n1._number + n2);
        }
    }
    
    
    static void Main(string[] args)
    {
        int someValue1 = 10;
        int someValue2 = 5;

        string result = new Number(someValue1) + someValue2.ToString(_ifp);
        Console.WriteLine(result);
        Console.ReadKey();
    }
}