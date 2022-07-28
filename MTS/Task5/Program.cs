using System;

class Program
{
    static void Main(string[] args)
    {
        TransformToElephant();
        Console.WriteLine("Муха");
    }

    /// <summary>
    /// Идея в том, чтобы сменить поток вывода из консоли в созданный файл.
    /// </summary>
    static void TransformToElephant()
    {
        Console.WriteLine("Слон");
        
        FileStream fs = new FileStream("Test.txt", FileMode.Create);
        TextWriter tmp = Console.Out;
        StreamWriter sw = new StreamWriter(fs);
        
        Console.SetOut(sw);
    }
}