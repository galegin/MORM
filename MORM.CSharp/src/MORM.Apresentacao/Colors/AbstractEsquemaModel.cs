namespace MORM.Apresentacao
{
    public class AbstractEsquemaModel : AbstractModel
    {
        #region variaveis
        private EsquemaCor _cabecalho;
        private EsquemaCor _corpo;
        private EsquemaCor _destaque;
        private EsquemaCor _detalhe;
        private EsquemaCor _menu;
        private EsquemaCor _rodape;
        private EsquemaCor _titulo;
        #endregion

        #region propriedades
        public EsquemaCor Cabecalho
        {
            get => _cabecalho;
            set => SetField(ref _cabecalho, value);
        }
        public EsquemaCor Corpo
        {
            get => _corpo;
            set => SetField(ref _corpo, value);
        }
        public EsquemaCor Destaque
        {
            get => _destaque;
            set => SetField(ref _destaque, value);
        }
        public EsquemaCor Detalhe
        {
            get => _detalhe;
            set => SetField(ref _detalhe, value);
        }
        public EsquemaCor Menu
        {
            get => _menu;
            set => SetField(ref _menu, value);
        }
        public EsquemaCor Rodape
        {
            get => _rodape;
            set => SetField(ref _rodape, value);
        }
        public EsquemaCor Titulo
        {
            get => _titulo;
            set => SetField(ref _titulo, value);
        }
        #endregion

        #region construtores
        public AbstractEsquemaModel()
        {
            Cabecalho = EsquemaTipo.Cabecalho.GetEsquema();
            Corpo = EsquemaTipo.Corpo.GetEsquema();
            Destaque = EsquemaTipo.Destaque.GetEsquema();
            Detalhe = EsquemaTipo.Detalhe.GetEsquema();
            Menu = EsquemaTipo.Menu.GetEsquema();
            Rodape = EsquemaTipo.Rodape.GetEsquema();
            Titulo = EsquemaTipo.Titulo.GetEsquema();
        }
        #endregion
    }
}