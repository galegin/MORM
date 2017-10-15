<?php

require_once("collectionitem.php");

class public Transfiscal extends CollectionItem
{
    public $Id_Transacao;
    public $U_Version;
    public $Cd_Operador;
    public $Dt_Cadastro;
    public $Tp_Operacao;
    public $Tp_Modalidade;
    public $Tp_Modelonf;
    public $Cd_Serie;
    public $Nr_Nf;
    public $Tp_Processamento;
    public $Ds_Chaveacesso;
    public $Dt_Recebimento;
    public $Nr_Recibo;
}
?>