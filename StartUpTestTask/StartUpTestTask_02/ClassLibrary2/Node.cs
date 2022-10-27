using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace ClassLibrary2
{
    [Serializable]
    public class Node<T>
    {
        /// <summary>
        /// Ключ-имя.
        /// </summary>
        public string? Name { get; set; } = null;

        /// <summary>
        /// Внутренние данные.
        /// </summary>
        public string? Text { get; set; } = null;

        public T? Data { get; set; } = default(T);

        /// <summary>
        /// Стандартный конструктор для Node.
        /// </summary>
        /// <param name="name">
        /// </param>
        /// <param name="text"></param>
        public Node(string name, string text, T data)
        {
            Name = name;
            Text = text;
            Data = data;
        }

        /// <summary>
        /// Сохраняет Node в json файл.
        /// </summary>
        /// <param name="path"> Место, куда нужно сохранить.</param>
        public void Save(string path)
        {
            using (FileStream fs = new FileStream(Path.GetFullPath(Path.Combine(path, $"{this.Name}.json")), FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize<Node<T>>(fs, this);
            }
        }
    }
}
