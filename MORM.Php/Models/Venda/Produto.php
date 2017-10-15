<?php

require_once("collectionitem.php");

class public Produto extends CollectionItem
{
    public $Id_Produto;
    public $U_Version;
    public $Cd_Operador;
    public $Dt_Cadastro;
    public $Cd_Produto;
    public $Ds_Produto;
    public $Cd_Especie;
    public $Cd_Ncm;
    public $Cd_Cst;
    public $Cd_Csosn;
    public $Pr_Aliquota;
    public $Tp_Producao;
    public $Vl_Custo;
    public $Vl_Venda;
    public $Vl_Promocao;
}
?>