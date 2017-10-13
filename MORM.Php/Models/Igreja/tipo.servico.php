<?php

require_once("../../models/collectionitem.php");

define("TS_SERVICO", 0);
define("TS_BATISMO", 1);
define("TS_SANTACEIA", 2);
define("TS_CULTOENSINAMENTO", 3);
define("TS_REUNIAOMOCIDADE", 4);
define("TS_COLETA", 5);

class TipoServico extends CollectionItem
{
    public $Codigo;
    public $Descricao;
    public $Tipo;
    public $Ordem;
}
?>