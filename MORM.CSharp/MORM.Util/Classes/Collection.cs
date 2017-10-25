using System;
using System.Collections.Generic;

namespace MORM.Util.Classes
{
    public class Collection : List<CollectionItem>
    {
        public Collection(Type collectionItemClass)
        {
            CollectionItemClass = collectionItemClass;
        }
        
        public Type CollectionItemClass { get; private set; }
        
        public CollectionItem AddItem()
        {
            var collectionItem = Activator.CreateInstance(CollectionItemClass) as CollectionItem;
            this.Add(collectionItem);
            return collectionItem;
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