<?php

require_once("collectionitem.php");

class public Transdfe extends CollectionItem
{
    public $Id_Transacao;
    public $Nr_Sequencia;
    public $U_Version;
    public $Cd_Operador;
    public $Dt_Cadastro;
    public $Tp_Evento;
    public $Tp_Ambiente;
    public $Tp_Emissao;
    public $Ds_Envioxml;
    public $Ds_Retornoxml;
}
?>