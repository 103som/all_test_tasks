using System;

static class Program
{
    /// <summary>
    /// Идея в том, чтобы воспользоваться ограниченеим по максимальному значению(просто создать массив на maxValue). А для экономии памти также использовать yield return.
    /// </summary>
    /// <param name="inputStream"></param>
    /// <param name="sortFactor"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
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