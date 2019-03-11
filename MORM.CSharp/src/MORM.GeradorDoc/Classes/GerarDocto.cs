using MORM.Utilidade.Atributos;
using MORM.Utilidade.Extensoes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MORM.GeradorDoc
{
    /// <summary>
    /// criado por MFGALEGO em 13/08/2018 18:17:41
    /// classe GerarDocto.cs
    /// funcao 
    /// </summary>
    internal abstract class GerarDocto
    {
        protected string Formato { get; set; }

        public void Gerar(string nome, Type type)
        {
            Console.Write(Formato + "... ");

            var conteudo = new List<string>();

            conteudo.Add(GerarClasse("Classe: " + nome, nome, type));

            File.WriteAllText("Arquivo\\_dicionario." + nome.ToLower() + Formato, string.Join("\r\n", conteudo));
        }

        protected virtual string GerarValor(CampoAttribute campo, bool isTitulo = false)
        {
            return null;
        }

        protected virtual string GerarCampo(Type type)
        {
            var conteudo = new List<string>();

            var campos = type.GetCampos();

            if (campos.Any())
            {
                conteudo.Add(GerarValor(campos.FirstOrDefault(), isTitulo: true));

                foreach (var campo in campos)
                {
                    conteudo.Add(GerarValor(campo));
                }
            }

            return string.Join("\r\n", conteudo);
        }

        protected virtual string GerarClasse(string nome, string nomeClasse, Type type)
        {
            var conteudo = new List<string>();

            // campos

            var campos = GerarCampo(type);

            if (!string.IsNullOrWhiteSpace(campos))
            {
                conteudo.Add(nome);
                conteudo.Add("");

                conteudo.Add(campos);
                conteudo.Add("");
            }

            // relacoes

            var relacoesGet = type.GetRelacoesGet();
            var relacoesSet = type.GetRelacoesSet();

            if (relacoesGet.Any())
            {
                foreach (var relacaoGet in relacoesGet)
                {
                    var gravacao = relacoesSet
                        .Any(x => x.OwnerProp.PropertyType == relacaoGet.OwnerProp.PropertyType);

                    var typeProp = relacaoGet.OwnerProp.PropertyType;

                    if (typeProp.Name.Contains("ICollection"))
                        typeProp = typeProp.GetGenericArguments().Single();

                    var nomeRelacao = 
                        "Relacao: " + nomeClasse + " -> " + relacaoGet.OwnerProp.Name + 
                        " " + (gravacao ? "[ Leitura / Gravacao ]" : "[ Leitura ]");

                    conteudo.Add(GerarClasse(nomeRelacao, relacaoGet.OwnerProp.Name, typeProp));
                }
            }

            return string.Join("\r\n", conteudo);
        }
    }
}