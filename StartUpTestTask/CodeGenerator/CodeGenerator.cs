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

namespace Library_1
{{
    public partial class Vault
    {{
        static partial void Download(Vault vault)
        {{
            DirectoryInfo di = new DirectoryInfo(Vault.path);

            foreach(var fi in di.GetFiles())
                vault.AddNode(new Node(di.Name, di.ToString()));
        }}

        static partial void Download(int pos, Vault vault)
        {{
            DirectoryInfo di = new DirectoryInfo(Vault.path);

            var files = di.GetFiles();

            if (pos >= files.Count())
                throw new ArgumentOutOfRangeException();

            vault.AddNode(new Node(files[pos].Name, files[pos].ToString()));
        }}
    }}
}}";
            context.AddSource($"Vault.cs", download);
        }
        public void Initialize(GeneratorInitializationContext context) { }
    }
}