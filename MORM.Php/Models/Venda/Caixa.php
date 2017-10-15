<?php

require_once("collectionitem.php");

class public Caixa extends CollectionItem
{
    public $Id_Caixa;
    public $U_Version;
    public $Cd_Operador;
    public $Dt_Cadastro;
    public $Id_Empresa;
    public $Id_Terminal;
    public $Dt_Abertura;
    public $Vl_Abertura;
    public $In_Fechado;
    public $Dt_Fechado;
}
?>