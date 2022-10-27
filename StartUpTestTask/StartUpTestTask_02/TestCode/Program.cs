using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCode;

namespace StartUpTestTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            test.CreateNodes();
            Console.WriteLine();

            test.FindNodes();
            Console.WriteLine();

            test.SaveNodes();

            test.DownloadNodes();
            Console.WriteLine();

            test.DownloadNodesByIndexes();
        }
    }
}
