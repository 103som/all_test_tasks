using System;
using System.Collections.Generic;
static class Program
{
    /// <summary>
    /// Идея в том, чтобы воспользоваться ограниченеим по максимальному значению(просто создать массив на maxValue).
    /// А для экономии памяти также использовать yield return.
    /// Решение оптимально.(Можно не подключать using System.Collections.Generic и использовать вместо List<int> массив int[],
    /// но я предпочитаю использовать List<int>, т.к. это удобнее и практичнее).
    /// </summary>
    /// <param name="inputStream"> Входной поток.</param>
    /// <param name="sortFactor"> Фактор сортировки.</param>
    /// <param name="maxValue"> Максимальное значение в потоке.</param>
    /// <returns> Отсортированный поток чисел.</returns>
    static IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
    {
        var allPossibleValues = new List<int>(maxValue + 1);
        for (int i = 0; i < maxValue + 1; ++i)
            allPossibleValues.Add(0);

        int mnn = 0;
        foreach (var elem in inputStream)
        {
            ++allPossibleValues[elem];

            int mxx = elem - sortFactor;
            while (mnn < mxx)
            {
                while (allPossibleValues[mnn]-- > 0)
                    yield return mnn;

                ++mnn;
            }
        }

        while (mnn < allPossibleValues.Count)
        {
            while (allPossibleValues[mnn]-- > 0)
                yield return mnn;

            ++mnn;
        }
    }

    /// <summary>
    /// Тестировка кода.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        List<int> list = new List<int>() { 1, 5, 4, 3};
        var test = Sort(list, 5, 5);
        foreach (var elem in test)
            Console.WriteLine((elem));
    }
}