using System;

namespace MORM.Aplicacao.Ioc.Container.Classes
{
    public class RegisterClasse
    {
        public RegisterClasse(Type interf, Type classe, RegisterTipo tipo)
        {
            Interf = interf ?? throw new ArgumentNullException(nameof(interf));
            Classe = classe ?? throw new ArgumentNullException(nameof(classe));
            Tipo = tipo;
        }

        public Type Interf { get; set; }
        public Type Classe { get; set; }
        public RegisterTipo Tipo { get; set; }
    }
}