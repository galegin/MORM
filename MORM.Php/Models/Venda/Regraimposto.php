<?php

require_once("collectionitem.php");

class public Regraimposto extends CollectionItem
{
    public $Id_Regrafiscal;
    public $Cd_Imposto;
    public $U_Version;
    public $Cd_Operador;
    public $Dt_Cadastro;
    public $Pr_Aliquota;
    public $Pr_Basecalculo;
    public $Cd_Cst;
    public $Cd_Csosn;
    public $In_Isento;
    public $In_Outro;
}
?>