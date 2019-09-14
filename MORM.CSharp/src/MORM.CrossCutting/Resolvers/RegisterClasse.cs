using System;

namespace MORM.CrossCutting
{
    public class RegisterClasse : IRegisterClasse
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

    public static class RegisterClasseExtensions
    {
        public static RegisterClasse SetRegisterTipo(this RegisterClasse registerClasse, RegisterTipo tipo)
        {
            registerClasse.Tipo = tipo;
            return registerClasse;
        }

        public static RegisterClasse PerScope(this RegisterClasse registerClasse) =>
            registerClasse.SetRegisterTipo(RegisterTipo.Scope);
        public static RegisterClasse PerSingleton(this RegisterClasse registerClasse) =>
            registerClasse.SetRegisterTipo(RegisterTipo.Singleton);
        public static RegisterClasse PerThread(this RegisterClasse registerClasse) =>
            registerClasse.SetRegisterTipo(RegisterTipo.PerThread);
        public static RegisterClasse PerTransient(this RegisterClasse registerClasse) =>
            registerClasse.SetRegisterTipo(RegisterTipo.Transient);
        public static RegisterClasse PerWebRequest(this RegisterClasse registerClasse) =>
            registerClasse.SetRegisterTipo(RegisterTipo.PerWebRequest);
    }
}