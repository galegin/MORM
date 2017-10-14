package MORM.Java.Classes;

public class Collection
{
    public Collection(Class collectionItemClass)
    {
        CollectionItemClass = collectionItemClass;
        Lista = new TList<CollectionItem>;
    }
    
    public Class CollectionItemClass;
    public TList<CollectionItem> Lista;
    
    public CollectionItem AddItem()
    {
        CollectionItem collectionItem;
        Lista.Add(collectionItem);
        return collectionItem;
    }
}