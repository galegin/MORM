using MORM.Utilidade.Atributos;
using System;
using System.Collections.Generic;

namespace MORM.Utilidade.Dtos
{
    //-- galeg - 30/03/2018 16:10:47
    public class DtoAbstract
    {
        public class Comum
        {
        }
    }

    public class DtoAbstract<TObject> : DtoAbstract where TObject : class
    {
        // filtro

        public class ComumFiltro : Comum
        {
            public ComumFiltro()
            {
            }

            public ComumFiltro(Func<TObject, string> filtro)
            {
                Filtro = filtro ?? throw new ArgumentNullException(nameof(filtro));
            }

            public Func<TObject, string> Filtro { get; set; }
        }

        // where

        public class ComumWhere : Comum
        {
            public ComumWhere()
            {
            }

            public ComumWhere(string where)
            {
                Where = where ?? throw new ArgumentNullException(nameof(where));
            }

            public string Where { get; set; }
        }

        // objeto

        public class ComumObjeto : Comum
        {
            public ComumObjeto()
            {
            }

            public ComumObjeto(TObject objeto)
            {
                Objeto = objeto ?? throw new ArgumentNullException(nameof(objeto));
            }

            public TObject Objeto { get; set; }
        }

        // lista

        public class ComumLista : Comum
        {
            public ComumLista()
            {
            }

            public ComumLista(IList<TObject> lista)
            {
                Lista = lista ?? throw new ArgumentNullException(nameof(lista));
            }

            public IList<TObject> Lista { get; set; }
        }

        // lista

        //-- listar

        [URL("Listar")]
        public class Listar : ComumFiltro
        {
            public Listar()
            {
            }

            public Listar(Func<TObject, string> filtro) : base(filtro)
            {
            }

            public int QtdeRegistro { get; set; } = -1;

            public int NumeroPagina { get; set; } = 0;
        }

        public class ListarRet : ComumLista
        {
            public ListarRet()
            {
            }

            public ListarRet(IList<TObject> lista) : base(lista)
            {
            }
        }

        //-- consultar

        [URL("Consultar")]
        public class Consultar : ComumFiltro
        {
            public Consultar()
            {
            }

            public Consultar(Func<TObject, string> filtro) : base(filtro)
            {
            }
        }

        public class ConsultarRet : ComumObjeto
        {
            public ConsultarRet()
            {                    
            }

            public ConsultarRet(TObject objeto) : base(objeto)
            {
            }
        }

        //-- incluir

        [URL("Incluir")]
        public class Incluir : ComumObjeto
        {
            public Incluir()
            {
            }

            public Incluir(TObject objeto) : base(objeto)
            {
            }
        }

        [URL("IncluirLista")]
        public class IncluirLista : ComumLista
        {
            public IncluirLista()
            {
            }

            public IncluirLista(IList<TObject> lista) : base(lista)
            {
            }
        }

        //-- alterar

        [URL("Alterar")]
        public class Alterar : ComumObjeto
        {
            public Alterar()
            {
            }

            public Alterar(TObject objeto) : base(objeto)
            {
            }
        }

        [URL("AlterarLista")]
        public class AlterarLista : ComumLista
        {
            public AlterarLista()
            {
            }

            public AlterarLista(IList<TObject> lista) : base(lista)
            {
            }
        }

        //-- salvar

        [URL("Salvar")]
        public class Salvar : ComumObjeto
        {
            public Salvar()
            {
            }

            public Salvar(TObject objeto) : base(objeto)
            {
            }
        }

        [URL("SalvarLista")]
        public class SalvarLista : ComumLista
        {
            public SalvarLista()
            {
            }

            public SalvarLista(IList<TObject> lista) : base(lista)
            {
            }
        }

        //-- excluir

        [URL("Excluir")]
        public class Excluir : ComumObjeto
        {
            public Excluir()
            {
            }

            public Excluir(TObject objeto) : base(objeto)
            {
            }
        }

        [URL("ExcluirLista")]
        public class ExcluirLista : ComumLista
        {
            public ExcluirLista()
            {
            }

            public ExcluirLista(IList<TObject> lista) : base(lista)
            {
            }
        }

        //-- sequencia

        public class SequenciaGen : Comum
        {
            public SequenciaGen()
            {
            }
        }

        //-- select max

        public class SequenciaMax : ComumFiltro
        {
            public SequenciaMax()
            {
            }

            public SequenciaMax(Func<TObject, string> filtro) : base(filtro)
            {
            }
        }
    }
}