using System;
using System.IO;

/// <summary>
/// Реализую 2 способа решения поставленной задачи.
/// 1 способ состоит в том, чтобы переопределить WriteLine, для его реализации я написал простенький класс,
/// в котором собственно все переопределил.
/// 2 способ состоит в том, чтобы просто поменять поток вывода на созданный новый файл и записывать в него,
/// это ведь не противоречит условию?
/// </summary>
class Program
{
    /// <summary>
    /// Тестирование кода.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        TransformToElephant();
        Console.WriteLine("Муха");
        // Some code....
    }
    
    /// <summary>
    /// Клас для переопределения WriteLine. (Способ 1)
    /// </summary>
    public class StringRedirect : StringWriter
    {
        /// <summary>
        ///  Поток вывода.
        /// </summary>
        private static readonly StreamWriter Stream;

        static StringRedirect()
        {
            Stream = new StreamWriter(Console.OpenStandardOutput());
            Stream.AutoFlush = true;
        }

        /// <summary>
        /// Переопределение WriteLine.
        /// </summary>
        /// <param name="curStr"> Выводимая строка.</param>
        public override void WriteLine(string curStr)
        {
            if (curStr == "Муха")
                Stream.WriteLine("Слон");
            else
                Stream.WriteLine(curStr);
        }
    };
    
    /// <summary>
    /// Способ 1) Идея в том, чтобы переопределить метод Writeline.
    /// </summary>
    static void TransformToElephant()
    {
        StringRedirect sw = new StringRedirect();
        Console.SetOut(sw);
    }

    /// <summary>
    /// Способ 2) Идея в том, чтобы сменить поток вывода из консоли в созданный файл.
    /// </summary>
    static void TransformToElephant2()
    {
        Console.WriteLine("Слон");
        
        FileStream fs = new FileStream("Test.txt", FileMode.Create);
        TextWriter tmp = Console.Out;
        StreamWriter sw = new StreamWriter(fs);
        
        Console.SetOut(sw);
    }
}