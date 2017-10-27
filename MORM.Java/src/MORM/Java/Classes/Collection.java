package MORM.Java.Classes;

import java.util.ArrayList;

import MORM.Java.Classes.Mapping.Relacao;

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
    
    private Relacao relacao;
    
    public void SetRelacao(Object owner, String campos)
    {
    	this.relacao = new Mapping().new Relacao(owner, campos);
    }

    public Relacao GetRelacao()
    {
        return this.relacao;
    }
}