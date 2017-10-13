namespace MORM.Reppositorio.Classes
{
    public class CollectionItem
    {
        public CollectionItem
        {
        }
        
        public TabelaAttribute GetTabela()
        {
            return this.GetType().GetAttributeType<TabelaAttribute>();
        }
        
        public CampoAttribute GetCampo(string attr)
        {
            return obj.GetType().GetProperties()
                .FirstOrDefault(x => x.Name == attr)
                .GetAttributeProp<CampoAttribute>();
        }
        
        public void SetRelacao(string campos)
        {
            Campos = campos;
        }
        
        public string Campos { get; private set; }
    }
}