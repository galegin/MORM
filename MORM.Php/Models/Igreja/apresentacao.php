<?php

require_once("../../models/collectionitem.php");

define("TA_CONF_SERVICO", 1);
define("TA_APRES_SERVICO", 2);
define("TA_APRES_SERVO", 3);

class Apresentacao extends CollectionItem
{
    public $Codigo;
    public $Codigo_Reuniao;
    public $Codigo_Localidade;
    public $Tipo;
    public $Codigo_Tipo_Servico;
    public $Funcao;
    public $Nome;
}
?>