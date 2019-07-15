using MORM.Dominio.Interfaces;
using System;

namespace MORM.Infra.Data.Context
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