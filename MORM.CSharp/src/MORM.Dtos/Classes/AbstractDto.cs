using MORM.Dominio.Atributos;
using System;
using System.Collections.Generic;

namespace MORM.Dtos
{
    public class AbstractDto
    {
        public class Comum
        {
        }
    }

    public class AbstractDto<TObject> : AbstractDto where TObject : class
    {
        // filtro

        public class ComumFiltro : Comum
        {
            public ComumFiltro(Func<TObject, string> filtro = null)
            {
                Filtro = filtro;
            }

            public Func<TObject, string> Filtro { get; set; }
        }

        // where

        public class ComumWhere : Comum
        {
            public ComumWhere(string where = null)
            {
                Where = where;
            }

            public string Where { get; set; }
        }

        // objeto

        public class ComumObjeto : Comum
        {
            public ComumObjeto(TObject objeto = null)
            {
                Objeto = objeto;
            }

            public TObject Objeto { get; set; }
        }

        // lista

        public class ComumLista : Comum
        {
            public ComumLista(IList<TObject> lista = null)
            {
                Lista = lista;
            }

            public IList<TObject> Lista { get; set; }
        }

        //-- listar

        [URL("Listar")]
        public class Listar : ComumFiltro
        {
            public Listar(Func<TObject, string> filtro = null) : base(filtro)
            {
            }

            public int QtdeRegistro { get; set; } = -1;
            public int NumeroPagina { get; set; } = 0;
        }

        public class ListarRet : ComumLista
        {
            public ListarRet(IList<TObject> lista = null) : base(lista)
            {
            }
        }

        //-- consultar

        [URL("Consultar")]
        public class Consultar : ComumFiltro
        {
            public Consultar(Func<TObject, string> filtro = null) : base(filtro)
            {
            }
        }

        public class ConsultarRet : ComumObjeto
        {
            public ConsultarRet(TObject objeto = null) : base(objeto)
            {
            }
        }

        //-- incluir

        [URL("Incluir")]
        public class Incluir : ComumObjeto
        {
            public Incluir(TObject objeto = null) : base(objeto)
            {
            }
        }

        //-- alterar

        [URL("Alterar")]
        public class Alterar : ComumObjeto
        {
            public Alterar(TObject objeto = null) : base(objeto)
            {
            }
        }

        //-- salvar

        [URL("Salvar")]
        public class Salvar : ComumObjeto
        {
            public Salvar(TObject objeto = null) : base(objeto)
            {
            }
        }

        //-- excluir

        [URL("Excluir")]
        public class Excluir : ComumObjeto
        {
            public Excluir(TObject objeto = null) : base(objeto)
            {
            }
        }

        //-- sequencia

        public class SequenciaGen : Comum
        {
        }

        //-- select max

        public class SequenciaMax : ComumFiltro
        {
            public SequenciaMax(Func<TObject, string> filtro = null) : base(filtro)
            {
            }
        }
    }
}