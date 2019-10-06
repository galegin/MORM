using MORM.CrossCutting;
using System;

namespace MORM.Repositorio
{
    public class Parametro : IParametro
    {
        public Parametro(string nome, object valor)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Valor = valor;
        }

        public string Nome { get; set; }
        public object Valor { get; set; }
    }
}