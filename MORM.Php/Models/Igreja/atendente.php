<?php

require_once("../../models/collectionitem.php");

define("TM_ANCIAO", 0);
define("TM_DIACONO", 1);
define("TM_COOPERADOR", 2);
define("TM_COOPERADOR_JOVEM", 3);
define("TM_ENCARREGADO", 4);
define("TM_ENCARREGADO_LOCAL", 5);
define("TM_EXAMINADORA", 6);
define("TM_INSTRUTORA", 7);
define("TM_ORAGNISTA", 8);
define("TM_ADMINISTRADOR", 9);

define("TA_PRESIDENTE", 0);
define("TA_VICE_PRESIDENTE", 1);
define("TA_SECRETARIO", 2);
define("TA_VICE_SECRETARIO", 3);
define("TA_TESOUREIRO", 4);
define("TA_VICE_TESOUREIRO", 5);
define("TA_CONTADOR", 6);
define("TA_CONSELHO_FISCAL", 7);
define("TA_AUX_SECRETARIA", 8);
define("TA_AUX_LIVRO", 9);

class Atendente extends CollectionItem
{
    public $Codigo;
    public $Nome;
    public $Ministerio;
    public $Administracao;
    public $Codigo_Localidade;
    public $Telefone_Pessoal;
    public $Telefone_Trabalho;
    public $Telefone_Recado;
    public $Data_Apresentacao;
}
?>