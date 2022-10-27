using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// <para> Отсчитать несколько элементов с конца </para>
/// <example> new[] {1,2,3,4}.EnumerateFromTail(2) = (1, ), (2, ), (3, 1), (4, 0)</example>
/// </summary> 
/// <typeparam name="T"></typeparam>
/// <param name="enumerable"></param>
/// <param name="tailLength">Сколько элеметнов отсчитать с конца  (у последнего элемента tail = 0)</param>
/// <returns></returns>
static class Program
{
    /// <summary>
    /// "Считает" элементы с конца массива.
    /// </summary>
    /// <param name="enumerable"> Входной массив данных.</param>
    /// <param name="tailLength"> Длина отсчета.</param>
    /// <typeparam name="T"> Тип входных данных.</typeparam>
    /// <returns> Посчитанную коллекцию.</returns>
    public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)
    {
        // Возвращаем пустой List.
        if (tailLength == null || tailLength == null)
            return new List<(T item, int? tail)>();

        IList<(T item, int? tail)> elems = new List<(T item, int? tail)>();
        var totalSize = enumerable.Count();

        Int32? cnt = Math.Min((Int32)tailLength - 1, totalSize - 1), i = 0;
        foreach (var elem in enumerable)
        {
            if (tailLength + i < totalSize)
            {
                elems.Add((elem, null));
            }
            else
            {
                elems.Add((elem, cnt));
                --cnt;
            }

            ++i;
        }

        return elems;
    }

    /// <summary>
    /// Тестирование написанного кода на заданном примере.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        var a = new[] { 6, 2, 5, 4 }.EnumerateFromTail(2);
        foreach (var elem in a)
        {
            Console.WriteLine(elem);
        }
    }
}
