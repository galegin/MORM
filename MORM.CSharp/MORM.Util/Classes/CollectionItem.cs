using System;

namespace MORM.Util.Classes
{
    public class CollectionItem
    {
        public CollectionItem()
        {
        }
        
        public Tabela GetTabela()
        {
            Tabela tabela = null;
            foreach (var attr in this.GetType().GetCustomAttributes(false))
                if (attr.GetType() == typeof(Tabela))
                    tabela = (attr as Tabela);
            return tabela;
        }
        
        public Campos GetCampos()
        {
            var campos = new Campos();
            foreach (var prop in this.GetType().GetProperties())
                foreach (var attr in prop.GetCustomAttributes(false))
                    if (attr.GetType() == typeof(Campo))
                        campos.Add(new Campo((attr as Campo).Nome, (attr as Campo).Tipo, prop.Name));
            return campos;
        }
        
        private Relacao _relacao;
        
        public void SetRelacao(object owner, string campos)
        {
            _relacao = new Relacao(owner, campos);
        }
        
        public Relacao GetRelacao()
        {
            return _relacao;
        }
    }
}