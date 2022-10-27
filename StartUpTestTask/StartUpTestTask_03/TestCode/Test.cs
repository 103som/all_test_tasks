using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary3;

namespace TestCode
{
    public class Test
    {
        Vault<int> val = new Vault<int>();

        /// <summary>
        /// Вывод всех Nodes.
        /// </summary>
        public void PrintNodes()
        {
            foreach (var node in val)
                Console.WriteLine(node.Name + ' ' + node.Text + ' ' + node.Data);
        }

        /// <summary>
        /// Проверка создания Nodes.
        /// </summary>
        public void CreateNodes()
        {
            val = new Vault<int>();
            for (int i = 0; i < 5; ++i)
                val.AddNode(new Node<int>("node" + i.ToString(), "testing element number : " + i.ToString(), i));
        }

        /// <summary>
        /// Проверка сохранения Nodes.
        /// </summary>
        public void SaveNodes()
        {
            val = new Vault<int>();
            this.CreateNodes();

            val.Save();
        }

        /// <summary>
        /// Проверка поиска Nodes по индексам.
        /// </summary>
        public void FindNodes()
        {
            val = new Vault<int>();
            this.CreateNodes();

            for (int i = 0; i < 5; ++i)
                Console.WriteLine(val["node" + i.ToString()].Text + ' ' + val["node" + i.ToString()].Data);
        }

        /// <summary>
        /// Проверка загрузки Nodes по индексам.
        /// </summary>
        public void DownloadNodesByIndexes()
        {
            SaveNodes();
            Vault<int> buf = new Vault<int>();
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
            Vault<int> buf = new Vault<int>();
            buf.Download();

            PrintNodes();
        }
    }
}