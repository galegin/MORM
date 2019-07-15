using MORM.Dominio.Atributos;
using MORM.Dominio.Tipagens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MORM.Dominio.Extensions
{
    public static class CreateCmdExtensions
    {
        public static string GetCreateCmd(this TipoDatabase tipo, Type type)
        {
            var tabela = type.GetTabela();
            var listaDeCampo = type.GetCampos();
            var campos = new List<string>();
            var keys = new List<string>();
            var column = new List<string>();

            foreach (var campo in listaDeCampo)
            {
                column.Clear();
                column.Add(campo.Nome);
                column.Add(tipo.GetDataType(campo));
                if (campo.Tipo != CampoTipo.Nul)
                    column.Add("Not Null");

                campos.Add(string.Join(" ", column));

                if (campo.Tipo == CampoTipo.Key)
                    keys.Add(campo.Nome);
            }

            return
                tipo.GetCreateTable(tabela.Nome, campos.ToArray(), keys.ToArray());
        }

        public static string[] GetListaAlterCmd(this TipoDatabase tipo, Type type)
        {
            var tabela = type.GetTabela();
            var listaDeCampo = type.GetCampos();
            var column = new List<string>();

            var listaDeAlterCmd = new List<string>();

            foreach (var campo in listaDeCampo)
            {
                column.Clear();
                column.Add(campo.Nome);
                column.Add(tipo.GetDataType(campo));
                if (campo.Tipo != CampoTipo.Nul)
                    column.Add("Not Null");

                listaDeAlterCmd.Add(tipo.GetAlterTable(tabela.Nome, column.ToArray()));
            }

            return listaDeAlterCmd.ToArray();
        }

        public static string[] GetListaDeDropForeignCmd(this TipoDatabase tipo, Type type)
        {
            var tabela = type.GetTabela();
            var listaDeRelacao = type.GetRelacoesGet();
            var foreigns = new List<string>();

            foreach (var relacao in listaDeRelacao)
            {
                var camposRel = RelacaoCampos.GetRelacaoCampos(relacao.Campos);

                string table = tabela.Nome;
                string tableRel = relacao.OwnerProp.PropertyType.GetTabela().Nome;

                var foreign = tipo.GetDropForeignKey(table, tableRel);
                if (!string.IsNullOrEmpty(foreign))
                    foreigns.Add(foreign);
            }

            return foreigns.ToArray();
        }

        public static string[] GetListaDeForeignCmd(this TipoDatabase tipo, Type type)
        {
            var tabela = type.GetTabela();
            var campos = type.GetCampos();
            var listaDeRelacao = type.GetRelacoesGet();
            var foreigns = new List<string>();

            foreach (var relacao in listaDeRelacao)
            {
                var camposProp = relacao.OwnerProp.PropertyType.GetCampos();
                var camposRel = RelacaoCampos.GetRelacaoCampos(relacao.Campos);

                string table = tabela.Nome;
                string[] fields = camposRel
                    .ConvertAll(x => campos.FirstOrDefault(c => c.Atributo == x.Atributo).Nome).ToArray();

                string tableRel = relacao.OwnerProp.PropertyType.GetTabela().Nome;
                string[] fieldsRel = camposRel
                    .ConvertAll(x => camposProp.FirstOrDefault(c => c.Atributo == x.AtributoRel).Nome).ToArray();

                var foreign = tipo.GetForeignKey(table, fields, tableRel, fieldsRel);
                if (!string.IsNullOrEmpty(foreign))
                    foreigns.Add(foreign);
            }

            return foreigns.ToArray();
        }
    }
}