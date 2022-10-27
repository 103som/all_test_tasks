﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections;

namespace Library_1
{
    public partial class Vault : IEnumerable<Node>
    {
        /// <summary>
        /// Список всех записей.
        /// </summary>
        private List<Node> nodes = new List<Node>();

        /// <summary>
        /// Путь к директории со всеми Node.
        /// </summary>
        public static string? path { get; } = null;

        /// <summary>
        /// Создание директории со всеми Nodes(происходит один раз при создании Vault).
        /// </summary>
        static Vault() {
            path = Path.GetFullPath(Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"..\..\..\..\"));
            path = Path.GetFullPath(Path.Combine(path, "Library_1", "nodes"));
            Directory.CreateDirectory(path);
        }

        /// <summary>
        /// Добавление Node.
        /// </summary>
        /// <param name="node"></param>
        public void AddNode(Node node) => nodes.Add(node);

        public Node? this[string name]
        {
            get => nodes.Find((Node node) => node.Name == name);
        }

        /// <summary>
        /// Сохранение Node в файл.
        /// </summary>
        public void Save()
        {
            foreach (Node node in nodes)
                node.Save(path);
        }

        /// <summary>
        /// Загрузка всех файлов Node в Vault.
        /// </summary>
        /// <param name="vault"></param>
        static partial void Download(Vault vault);

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
        static partial void Download(int pos, Vault vault);

        /// <summary>
        /// Загрузка конкретного файла Node в Vault.
        /// </summary>
        /// <param name="pos"> Индекс файла, который нужно загрузить.</param>
        public void Download(int pos) => Download(pos, this);

        /// <summary>
        /// Проход по массиву в foreach(нужен для тестирования).
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Node> GetEnumerator()
        {
            for (int i = 0; i < nodes.Count; ++i)
                yield return nodes[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
