namespace MORM.Reppositorio.Classes
{
    public class Collection : IList<CollectionItem>
    {
        public Collection(Type collectionItemClass)
        {
            CollectionItemClass = collectionItemClass;
        }
        
        public Type CollectionItemClass { get; private set; }
        
        public CollectionItem AddItem()
        {
            var collectionItem = Activator.Create(CollectionItemClass);
            this.Add(collectionItem);
            return collectionItem;
        }
    }
}