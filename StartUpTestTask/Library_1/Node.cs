using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_1
{
    public class Node
    {
        /// <summary>
        /// Ключ-имя.
        /// </summary>
        public string? Name { get; set; } = null;

        /// <summary>
        /// Внутренние данные.
        /// </summary>
        public string? Text { get; set; } = null;

        /// <summary>
        /// Стандартный конструктор для Node.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="text"></param>
        public Node(string name, string text)
        {
            Name = name;
            Text = text;
        }

        /// <summary>
        /// Сохраняет Node в файл.
        /// </summary>
        /// <param name="path"> Место, куда нужно сохранить.</param>
        public void Save(string path) => File.WriteAllText(Path.GetFullPath(Path.Combine(path, $"{this.Name}.node")), this.Text);
    }
}
