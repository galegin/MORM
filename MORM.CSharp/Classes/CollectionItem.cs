namespace MORM.Reppositorio.Classes
{
    public class CollectionItem
    {
        public CollectionItem
        {
        }
        
        public Tabela GetTabela()
        {
            return this.GetType().GetAttributeType<TabelaAttribute>();
        }
        
        public Campos GetCampos(string attr)
        {
            var campos = new TCampos();
            foreach (var prop in obj.GetType().GetProperties())
                foreach (var attr in prop.GetAttributes())
                    if (attr is CampoAttribute)
                        campos.Add(new Campo((attr is CampoAttribute).Campo, (attr is CampoAttribute).Tipo, prop.Name);
        }
        
        public void SetRelacao(string campos)
        {
            Campos = campos;
        }
        
        public string Campos { get; private set; }
    }
}