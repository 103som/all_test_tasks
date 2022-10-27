using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Library_1;

namespace TestCode
{
    public class Test
    {
        Vault val = new Vault();

        /// <summary>
        /// Вывод всех Nodes.
        /// </summary>
        public void PrintNodes()
        {
            foreach (var node in val)
                Console.WriteLine(node.Name + ' ' + node.Text);
        }

        /// <summary>
        /// Проверка создания Nodes.
        /// </summary>
        public void CreateNodes()
        {
            val = new Vault();
            for (int i = 0; i < 5; ++i)
                val.AddNode(new Node("node" + i.ToString(), "testing element number : " + i.ToString()));
        }

        /// <summary>
        /// Проверка сохранения Nodes.
        /// </summary>
        public void SaveNodes()
        {
            val = new Vault();
            this.CreateNodes();

            val.Save();
        }

        /// <summary>
        /// Проверка поиска Nodes по индексам.
        /// </summary>
        public void FindNodes()
        {
            val = new Vault();
            this.CreateNodes();

            for (int i = 0; i < 5; ++i)
                Console.WriteLine(val["node" + i.ToString()].Text);
        }

        /// <summary>
        /// Проверка загрузки Nodes по индексам.
        /// </summary>
        public void DownloadNodesByIndexes()
        {
            SaveNodes();
            Vault buf = new Vault();
            for (int i = 0; i < 5; ++i)
                buf.Download(i);

            PrintNodes();
        }

        /// <summary>
        /// Проверка первоначальной загрузки всех Nodes.
        /// </summary>
        public void DownloadNodes()
        {
            SaveNodes();
            Vault buf = new Vault();
            buf.Download();

            PrintNodes();
        }
    }
}
