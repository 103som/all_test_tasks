using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace CodeGenerator
{
    [Generator]
    public class CodeGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var download =
$@"
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary2
{{
    public partial class Vault<T>
    {{
        static partial void Download(Vault<T> vault)
        {{
            DirectoryInfo di = new DirectoryInfo(Vault<T>.path);
            foreach(var fi in di.GetFiles()) {{
                using (FileStream fs = File.OpenRead(fi.ToString()))
                {{
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    string str = Encoding.Default.GetString(buffer);

                    vault.AddNode(JsonSerializer.Deserialize<Node<T>>(str));
                }}
            }}
        }}
        static partial void Download(int pos, Vault<T> vault)
        {{
            DirectoryInfo di = new DirectoryInfo(Vault<T>.path);
            var files = di.GetFiles();
            if (pos >= files.Count())
                throw new ArgumentOutOfRangeException();

            using (FileStream fs = File.OpenRead(files[pos].ToString()))
            {{
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                string str = Encoding.Default.GetString(buffer);

                vault.AddNode(JsonSerializer.Deserialize<Node<T>>(str));
            }}
        }}
    }}
}}";
            context.AddSource($"Vault.cs", download);
        }
        public void Initialize(GeneratorInitializationContext context) { }
    }
}