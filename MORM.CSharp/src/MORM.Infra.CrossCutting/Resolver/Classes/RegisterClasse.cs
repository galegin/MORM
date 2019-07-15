using MORM.Dominio.Interfaces;
using System;

namespace MORM.Infra.CrossCutting
{
    public class RegisterClasse
    {
        public RegisterClasse(Type iclasse, Type classe, RegisterTipo tipo)
        {
            IClasse = iclasse ?? throw new ArgumentNullException(nameof(iclasse));
            Classe = classe ?? throw new ArgumentNullException(nameof(classe));
            Tipo = tipo;
        }

        public Type IClasse { get; set; }
        public Type Classe { get; set; }
        public RegisterTipo Tipo { get; set; }
    }
}