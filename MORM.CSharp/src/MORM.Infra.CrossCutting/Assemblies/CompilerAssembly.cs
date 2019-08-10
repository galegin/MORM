using System;
using System.CodeDom.Compiler;
using System.Linq;
using System.Reflection;

namespace MORM.Infra.CrossCutting
{
    public class CompilerAssembly
    {
        #region variaveis
        private const string _blocoClasse = @"using System;
using System.Reflecton;
using MORM.Apresentacao.Models;
//using {uso};

namespace {nomeEspaco}
{
    public class {nomeClasse}Filtro //: {nomeClasse}
    {
        #region variaveis
{variaveis}
        #endregion 

        #region propriedades
{propriedades}
        #endregion 
    }
}";

        private const string _blocoVariavel = @"
        private {tip} _{cod}Ini;
        private {tip} _{cod}Fin;
        private {tip} _{cod}Des;
        private {tip} _{cod}Sel;";

        private const string _blocoPropriedade = @"
        public {tip} {cod}Ini { get => _{cod}Ini; set => SetField(ref _{cod}Ini, value); }
        public {tip} {cod}Fin { get => _{cod}Fin; set => SetField(ref _{cod}Fin, value); }
        public {tip} {cod}Des { get => _{cod}Des; set => SetField(ref _{cod}Des, value); }
        public {tip} {cod}Sel { get => _{cod}Sel; set => SetField(ref _{cod}Sel, value); }";
        #endregion

        #region metodos

        #region metodos publicos
        public static Type GetClasse(Type type)
        {
            var provider = CodeDomProvider.CreateProvider("C#");

            var parameters = new CompilerParameters();
            parameters.GenerateInMemory = true;
            parameters.ReferencedAssemblies.Add(@"System.dll");
            parameters.ReferencedAssemblies.Add(@"MORM.Apresentacao.dll");

            var nameAssemblyType = type.Assembly.GetName().Name + ".dll";
            parameters.ReferencedAssemblies.Add(nameAssemblyType);
            
            //parameters.ReferencedAssemblies.Add(@"System.Net.dll");

            parameters.IncludeDebugInformation = false;

            var blocoClasse = GetBlocoClasse(type);

            var results = provider.CompileAssemblyFromSource(parameters,
                new string[] { blocoClasse });

            var newAssembly = results.CompiledAssembly;

            var nomeClasse = GetNomeClasse(type);

            var newType = newAssembly.GetType(nomeClasse);

            //// create an instance
            //object instance = newAssembly.CreateInstance(nomeClasse);
            //
            //// object parameter
            //object someObject = null;
            //
            //// call method returning bool and taking one string and one object
            //var retorno = (bool)newAssembly
            //    .GetType(nomeClasse)
            //    .GetMethod("TestB")
            //    .Invoke(instance, new object[] { "Hallo", someObject });

            return newType;
        }
        #endregion

        #region metodos privados
        private static string GetNomeEspaco(Type type) =>
            $"MORM.Apresentacao.Filtro";
        private static string GetNomeClasse(Type type) =>
            $"{type.Name}";
        private static string GetNomeClasseComEspaco(Type type) =>
            $"{GetNomeEspaco(type)}.{GetNomeClasse(type)}Filtro";

        private static string GetBlocoClasse(Type type)
        {
            return _blocoClasse
                .Replace("{uso}", type.Namespace)
                .Replace("{nomeEspaco}", GetNomeEspaco(type))
                .Replace("{nomeClasse}", GetNomeClasse(type))
                .Replace("{variaveis}", GetBlocoVariaveis(type.GetProperties()))
                .Replace("{propriedades}", GetBlocoPropriedades(type.GetProperties()))
                ;
        }

        private static string GetBlocoVariaveis(PropertyInfo[] props) =>
            GetBlocoConteudo(props, _blocoVariavel);
        private static string GetBlocoPropriedades(PropertyInfo[] props) =>
            GetBlocoConteudo(props, _blocoPropriedade);

        private static string GetBlocoConteudo(PropertyInfo[] props, string conteudo)
        {
            var retorno = props
                .ToList()
                .ConvertAll(prop =>
                    conteudo
                        .Replace("{tip}", prop.PropertyType.ToString())
                        .Replace("{cod}", prop.Name)
                );

            return string.Join("\n", retorno);
        }
        #endregion

        #endregion
    }
}