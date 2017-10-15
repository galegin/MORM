<?php

require_once("collectionitem.php");

class public Transimposto extends CollectionItem
{
    public $Id_Transacao;
    public $Nr_Item;
    public $Cd_Imposto;
    public $U_Version;
    public $Cd_Operador;
    public $Dt_Cadastro;
    public $Pr_Aliquota;
    public $Vl_Basecalculo;
    public $Pr_Basecalculo;
    public $Pr_Redbasecalculo;
    public $Vl_Imposto;
    public $Vl_Outro;
    public $Vl_Isento;
    public $Cd_Cst;
    public $Cd_Csosn;
}
?>