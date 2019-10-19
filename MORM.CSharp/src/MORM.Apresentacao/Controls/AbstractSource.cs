using MORM.CrossCutting;

namespace MORM.Apresentacao
{
    public struct AbstractSource
    {
        #region propriedades
        public object Source { get; set; }
        public string Nome { get; set; }
        #endregion

        #region construtores
        public AbstractSource(object source, string nome)
        {
            Source = source;
            Nome = nome;
        }
        #endregion

        #region metodos
        public object Model => Source.GetInstancePropOrField(Nome);
        #endregion
    }
}