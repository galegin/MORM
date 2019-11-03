using MORM.Apresentacao.Report;
using MORM.CrossCutting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace MORM.Apresentacao
{
    public static class DataGridRelatorio
    {
        public static IRelatorio GetRelatorio(this DataGrid dataGrid,
            string cabecalho = null,
            string titulo = null,
            string rodape = null,
            IList<IRelatorioCampo> quebras = null,
            RelatorioSaida? saida = null,
            RelatorioFormato? formato = null,
            string nomeArquivo = null,
            string nomeImpressora = null,
            IRelatorioEmailServidor emailServidor = null,
            IList<IRelatorioEmail> emails = null)
        {
            var largura = dataGrid.GetLargura(formato);

            IList<IRelatorioParte> partes = new List<IRelatorioParte>()
            {
                //dataGrid.GetCabecalho(cabecalho),
                //dataGrid.GetTitulo(titulo),
                //dataGrid.GetCorpo(),
                //dataGrid.GetRodape(rodape),
            };

            if (cabecalho != null)
                partes.Add(dataGrid.GetCabecalho(cabecalho));
            if (titulo != null)
                partes.Add(dataGrid.GetTitulo(cabecalho));

            var listaDeObjeto = dataGrid.GetListaDeObjeto();
            if (quebras?.Any() == true)
            {
                var partesQuebra = dataGrid.GetQuebras(quebras, listaDeObjeto);
                foreach (var parteQuebra in partesQuebra)
                    partes.Add(parteQuebra);
            }
            else
            {
                partes.Add(dataGrid.GetCorpo(listaDeObjeto));
            }

            if (rodape != null)
                partes.Add(dataGrid.GetRodape(rodape));

            IRelatorio relatorio = new Relatorio(
                titulo: titulo,
                partes: partes,
                saida: saida,
                formato: formato,
                largura: largura,
                nomeArquivo: nomeArquivo,
                nomeImpressora: nomeImpressora,
                emailServidor: emailServidor,
                emails: emails);

            return relatorio;
        }

        //-- cabecalho

        private static IRelatorioParte GetCabecalho(this DataGrid dataGrid, string cabecalho)
        {
            var parte = new RelatorioParte
            {
                Tipo = RelatorioParteTipo.Cabecalho,
                Campos = new List<IRelatorioCampo>
                {
                    new RelatorioCampo(nameof(RelatorioParteTipo.Cabecalho), alinhamento: RelatorioAlinhamento.Centro)
                },
                Objeto = new { Cabecalho = cabecalho },
            };

            return parte;
        }

        //-- titulo

        private static IRelatorioParte GetTitulo(this DataGrid dataGrid, string titulo)
        {
            var parte = new RelatorioParte
            {
                Tipo = RelatorioParteTipo.Titulo,
                Campos = new List<IRelatorioCampo>
                {
                    new RelatorioCampo(nameof(RelatorioParteTipo.Titulo), alinhamento: RelatorioAlinhamento.Centro)
                },
                Objeto = new { Titulo = titulo },
            };

            return parte;
        }

        //-- rodape

        private static IRelatorioParte GetRodape(this DataGrid dataGrid, string rodape)
        {
            var parte = new RelatorioParte
            {
                Tipo = RelatorioParteTipo.Rodape,
                Campos = new List<IRelatorioCampo>
                {
                    new RelatorioCampo(nameof(RelatorioParteTipo.Rodape), alinhamento: RelatorioAlinhamento.Centro)
                },
                Objeto = new { Rodape = rodape },
            };

            return parte;
        }

        //-- quebras

        private static IList<IRelatorioParte> GetQuebras(this DataGrid dataGrid, IList<IRelatorioCampo> quebras,
            IList<object> listaDeObjetoPar)
        {
            IList<IRelatorioParte> relatorioPartes = new List<IRelatorioParte>();

            IList<object> listaDeObjetoAnt = null;
            object objetoAnt = null;

            foreach (var objeto in listaDeObjetoPar)
            {
                if (objetoAnt == null || !quebras.CompareObjeto(objeto, objetoAnt))
                {
                    if (objetoAnt != null)
                    {
                        relatorioPartes.Add(dataGrid.GetQuebra(quebras, objetoAnt, listaDeObjetoAnt));
                    }

                    objetoAnt = objeto;
                    listaDeObjetoAnt = new List<object>();
                }

                listaDeObjetoAnt.Add(objeto);
            }

            if (objetoAnt != null && listaDeObjetoAnt?.Any() == true)
            {
                relatorioPartes.Add(dataGrid.GetQuebra(quebras, objetoAnt, listaDeObjetoAnt));
            }

            return relatorioPartes;
        }

        private static IRelatorioParte GetQuebra(this DataGrid dataGrid, IList<IRelatorioCampo> quebras,
            object objeto, IList<object> listaDeObjeto)
        {
            return new RelatorioParte
            {
                Tipo = RelatorioParteTipo.Quebra,
                Campos = quebras,
                Objeto = objeto,
                Partes = new List<IRelatorioParte>
                {
                    dataGrid.GetCorpo(listaDeObjeto),
                }
            };
        }

        private static bool CompareObjeto(this IList<IRelatorioCampo> quebras, object objeto, object objetoAnt)
        {
            if (objeto == null || objetoAnt == null)
                return false;

            foreach (var quebra in quebras)
            {
                var value = objeto.GetInstancePropOrField(quebra.Codigo);
                var valueAnt = objetoAnt.GetInstancePropOrField(quebra.Codigo);
                if (!value.Equals(valueAnt))
                {
                    return false;
                }
            }

            return true;
        }

        //-- corpo

        private static IRelatorioParte GetCorpo(this DataGrid dataGrid, IList<object> listaDeObjetoPar)
        {
            var corpo = new RelatorioParte
            {
                Tipo = RelatorioParteTipo.Corpo,
                Partes = new List<IRelatorioParte>()
                {
                    dataGrid.GetTituloColunas(),
                }
            };

            dataGrid.GetDetahes(listaDeObjetoPar).ToList()
                .ForEach((d) => corpo.Partes.Add(d));

            return corpo;
        }

        private static IList<object> GetListaDeObjetoView(this ListCollectionView listCollectionView)
        {
            var listaDeObjeto = new List<object>();

            foreach (var collectionView in listCollectionView)
                listaDeObjeto.Add(collectionView);

            return listaDeObjeto;
        }

        private static IList<object> GetListaDeObjetoList(this IList list)
        {
            var listaDeObjeto = new List<object>();

            foreach (var item in list)
                listaDeObjeto.Add(item);

            return listaDeObjeto;
        }

        private static IList<object> GetListaDeObjeto(this DataGrid dataGrid)
        {
            IList<object> listaDeObjeto = new List<object>();

            if (dataGrid.ItemsSource is ListCollectionView)
            {
                listaDeObjeto = GetListaDeObjetoView(dataGrid.ItemsSource as ListCollectionView);
            }
            else if (dataGrid.ItemsSource is IList)
            {
                listaDeObjeto = GetListaDeObjetoList(dataGrid.ItemsSource as IList);
            }

            return listaDeObjeto;
        }

        private static IRelatorioParte GetTituloColunas(this DataGrid dataGrid)
        {
            var objeto = dataGrid.GetListaDeObjeto().FirstOrDefault();

            IRelatorioParte parte = new RelatorioParte()
            {
                Tipo = RelatorioParteTipo.TituloColunas,
                Campos = dataGrid.GetCampos(),
                Objeto = objeto,
            };

            return parte;
        }

        private static IList<IRelatorioParte> GetDetahes(this DataGrid dataGrid, IList<object> listaDeObjetoPar = null)
        {
            IList<IRelatorioParte> detalhes = new List<IRelatorioParte>();

            var campos = dataGrid.GetCampos();
            var listaDeObjeto = listaDeObjetoPar ?? dataGrid.GetListaDeObjeto();

            foreach (var objeto in listaDeObjeto)
            {
                IRelatorioParte parte = new RelatorioParte()
                {
                    Tipo = RelatorioParteTipo.Detalhe,
                    Campos = campos,
                    Objeto = objeto,
                };

                detalhes.Add(parte);
            }

            return detalhes;
        }

        private static IList<IRelatorioCampo> GetCampos(this DataGrid dataGrid)
        {
            if (dataGrid.Tag is IList<IRelatorioCampo>)
                return (dataGrid.Tag as IList<IRelatorioCampo>);

            IList<IRelatorioCampo> campos = new List<IRelatorioCampo>();

            foreach (var column in dataGrid.Columns)
            {
                var width = column.Width;
                campos.Add(new RelatorioCampo(
                    codigo: column.SortMemberPath,
                    descricao: column.Header as string,
                    tamanho: Convert.ToInt32(width.DisplayValue > 0 && !width.IsAuto ? width.DisplayValue / 8 : 20),
                    precisao: 0,
                    alinhamento: RelatorioAlinhamento.Esquerda));
            }

            return campos;
        }

        private static int GetLargura(this DataGrid dataGrid, RelatorioFormato? formato)
        {
            if (formato == null)
                return 0;

            var demilitador = formato.Value.GetDelimitador();
            var campos = dataGrid.GetCampos();

            var tamInicial = demilitador?.Inicial?.Length ?? 0;
            var tamEntre = demilitador?.Entre?.Length ?? 0;
            var tamFinal = demilitador?.Final?.Length ?? 0;
            var tamCampos = campos.Sum(x => x.Tamanho);
            var tamCamposEntre = campos.Count > 1 ? (campos.Count - 1) * tamEntre : 0;

            var largura = tamInicial + tamCampos + tamCamposEntre + tamFinal;

            return largura;
        }
    }
}