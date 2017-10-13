<?php

require_once("collectionitem.php");

class Collection
{
    public function __construct($collectionItemClass)
    {
        $this->CollectionItemClass = $collectionItemClass;
        $this->Lista = new ArrayObject();
    }
    
    public $CollectionItemClass;
    public $Lista;
    
    public function Add()
    {
        $collectionItem = new $this->CollectionItemClass();
        $this->Lista->append($collectionItem);
        return $collectionItem;
    }
}
?>