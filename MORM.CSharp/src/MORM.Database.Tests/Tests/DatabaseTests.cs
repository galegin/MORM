﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MORM.Database.Tests;
using MORM.CrossCutting;

namespace MORM.Repositorio.Tests
{
    [TestClass]
    public class DatabaseTests : BaseTests
    {
        private IAmbiente _ambiente;

        [TestInitialize]
        public void DatabaseTests_Initialize()
        {
            _ambiente = Resolve<IAmbiente>();
        }

        [TestCleanup]
        public void DatabaseTests_Cleanup()
        {
            _ambiente = null;
        }

        [TestMethod]
        public void DatabaseTests_Conexao()
        {
            var connection = _ambiente.GetConnection();
            connection.Open();
        }

        [TestMethod]
        public void DatabaseTests_Consulta()
        {
            var connection = _ambiente.GetConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "select * from _MIGRACAO";
            command.ExecuteReader();
        }
    }
}