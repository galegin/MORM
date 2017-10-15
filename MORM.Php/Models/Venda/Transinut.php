<?php

require_once("collectionitem.php");

class public Transinut extends CollectionItem
{
    public $Id_Transacao;
    public $U_Version;
    public $Cd_Operador;
    public $Dt_Cadastro;
    public $Dt_Emissao;
    public $Tp_Modelonf;
    public $Cd_Serie;
    public $Nr_Nf;
    public $Dt_Recebimento;
    public $Nr_Recibo;
}
?>