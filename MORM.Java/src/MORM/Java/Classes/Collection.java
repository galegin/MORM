package MORM.Java.Classes;

import java.util.ArrayList;

@SuppressWarnings("serial")
public class Collection extends ArrayList<CollectionItem>
{
    public Collection(Class<CollectionItem> collectionItemClass)
    {
        CollectionItemClass = collectionItemClass;
    }
    
    public Class<CollectionItem> CollectionItemClass;
    
    public CollectionItem AddItem()
    {
        CollectionItem collectionItem = null;
		try {
			collectionItem = CollectionItemClass.newInstance();
	        this.add(collectionItem);
		} catch (InstantiationException e) {
			e.printStackTrace();
		} catch (IllegalAccessException e) {
			e.printStackTrace();
		}
        return collectionItem;
    }
}