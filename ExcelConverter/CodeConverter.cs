using System;
using System.IO;
using System.Collections.Generic;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;

namespace ExcelConverter
{
    public class CodeConverter
    {
        private Dictionary<string, Type> ToType = new Dictionary<string, Type>()
        {
            {"int" , typeof(int)},
            {"float" , typeof(float)},
            {"string" , typeof(string)}
        };

        private CodeCompileUnit codeCompileUnit;
        private CodeNamespace codeNamespace;
        private CodeTypeDeclaration codeClass;
        private string filePath;

        public CodeConverter(string namespaceName, string path) 
        {
            string className = path.Substring(path.LastIndexOf('\\') + 1);
            className = className.Substring(0, className.LastIndexOf('.'));

            filePath = path;
            codeCompileUnit = new CodeCompileUnit();
            codeNamespace = new CodeNamespace(namespaceName);
            codeNamespace.Imports.Add(new CodeNamespaceImport("System"));
            codeClass = new CodeTypeDeclaration(className);
            codeClass.IsClass = true;
            codeClass.TypeAttributes = TypeAttributes.Public;
            codeNamespace.Types.Add(codeClass);
            codeCompileUnit.Namespaces.Add(codeNamespace);
        }

        public void ToCsCodeFile(List<List<string>> data)
        {
            for (int i = 0; i < data[0].Count; i++)
            {
                CodeMemberField codeField = new CodeMemberField();
                codeField.Attributes = MemberAttributes.Public;
                codeField.Name = data[0][i];
                codeField.Type = new CodeTypeReference(ToType[data[1][i]]);
                codeClass.Members.Add(codeField);
            }

            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";

            using (StreamWriter codeWriter = new StreamWriter(filePath))
            {
                provider.GenerateCodeFromCompileUnit(codeCompileUnit, codeWriter, options);
            }
        }
    }
}
