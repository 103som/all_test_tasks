using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ClassLibrary3
{
    public partial class Vault<T> : IEnumerable<Node<T>>
    {
        /// <summary>
        /// Список всех записей.
        /// </summary>
        Dictionary<string, Node<T>> nodes = new Dictionary<string, Node<T>>();

        /// <summary>
        /// Путь к директории со всеми Node.
        /// </summary>
        public static string? path { get; } = null;

        /// <summary>
        /// Создание директории со всеми Nodes(происходит один раз при создании Vault).
        /// </summary>
        static Vault()
        {
            path = Path.GetFullPath(Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"..\..\..\..\"));
            path = Path.GetFullPath(Path.Combine(path, "ClassLibrary3", "nodes"));
            Directory.CreateDirectory(path);
        }

        /// <summary>
        /// Добавление Node.
        /// </summary>
        /// <param name="node"></param>
        public void AddNode(Node<T> node) => nodes.Add(node.Name, node);

        public Node<T>? this[string name]
        {
            get => nodes[name];
        }

        /// <summary>
        /// Сохранение Node в файл.
        /// </summary>
        public void Save()
        {
            foreach (var node in nodes)
                node.Value.Save(path);
        }

        /// <summary>
        /// Загрузка всех файлов Node в Vault.
        /// </summary>
        /// <param name="vault"></param>
        static partial void Download(Vault<T> vault);

        /// <summary>
        /// Загрузка всех файлов Node в Vault.
        /// </summary>
        /// <param name="vault"></param>
        public void Download() => Download(this);

        /// <summary>
        /// Загрузка конкретного файла Node в Vault.
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="vault"></param>
        static partial void Download(int pos, Vault<T> vault);

        /// <summary>
        /// Загрузка конкретного файла Node в Vault.
        /// </summary>
        /// <param name="pos"> Индекс файла, который нужно загрузить.</param>
        public void Download(int pos) => Download(pos, this);

        /// <summary>
        /// Проход по массиву в foreach(нужен для тестирования).
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Node<T>> GetEnumerator()
        {
            foreach(var node in nodes)
                yield return node.Value;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
