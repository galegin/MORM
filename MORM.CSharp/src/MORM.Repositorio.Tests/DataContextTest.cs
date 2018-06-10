using Microsoft.VisualStudio.TestTools.UnitTesting;
using MORM.Repositorio.Context;
using MORM.Repositorio.Interfaces;
using MORM.Repositorio.Migrations;
using MORM.Repositorio.Tests.Servicos;
using MORM.Repositorio.SqLite;
using MORM.Repositorio.Tests.Models;
using MORM.Utilidade.Entidades;
using MORM.Utilidade.Interfaces;
using MORM.Utilidade.Tipagens;
using System;

namespace MORM.Repositorio.Tests
{
    
    [TestClass]
    public class DataContextTest
    {
        static DataContextTest()
        {
            DataContextConnection.SetConnectionFactory(TipoDatabase.SqLite, new SqLiteHelper());
        }

        public DataContextTest()
        {
            Ambiente =  new Ambiente();
            DataContext = new DataContext(Ambiente);
        }

        public IAmbiente Ambiente { get; }
        public IDataContext DataContext { get; }

        [TestMethod]
        public void DbContextTest_Migracao()
        {
            var arquivo = GetType().Assembly.Location;

            MigracaoContexto.Gerar(DataContext, arquivo);
        }

        [TestMethod]
        public void DbContextTest_Conexao()
        {
            var testeService = new TesteService(Ambiente);

            var teste = testeService.ConsultarF((f) => $"{nameof(f.Codigo)} = 1");
        }

        [TestMethod]
        public void DbContextTest_Gravacao()
        {
            var teste = new TesteModel
            {
                Codigo = 1,
                Descricao = "Teste",
                Data = DateTime.Now,
                Numero = 2,
                Ativo = true,
                Valor = 3,
            };

            var testeService = new TesteService(Ambiente);

            testeService.Salvar(teste);
        }

        [TestMethod]
        public void DbContextTest_Exclusao()
        {
            var teste = new TesteModel { Codigo = 1 };

            var testeService = new TesteService(Ambiente);

            testeService.Excluir(teste);
        }
    }
}