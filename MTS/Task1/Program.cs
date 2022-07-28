using System;
using System.Diagnostics; // Для 3 способа.

class Program
{
    static void Main(string[] args)
    {
        try
        {
            FailProcess();
        }
        catch {
            
        }
        
        Console.WriteLine("Failed to fail process!");
        Console.ReadKey();
    }

    /// <summary>
    /// 1 способ.
    /// </summary>
    static void FailProcess()
    {
        Environment.Exit(0);
    }
    
    /// <summary>
    /// 2 способ.(Вызывает падение).
    /// </summary>
    static void FailProcess2()
    {
        System.Environment.FailFast("Finish proccess");
    }
    
    /// <summary>
    /// 3 способ.(возможен при подлючении using System.Diagnostics;)
    /// </summary>
    static void FailProcess3()
    {
        Process.GetCurrentProcess().Kill();
    }
}