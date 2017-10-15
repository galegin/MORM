<?php

require_once("collectionitem.php");

class public Transacao extends CollectionItem
{
    public $Id_Transacao;
    public $U_Version;
    public $Cd_Operador;
    public $Dt_Cadastro;
    public $Id_Empresa;
    public $Id_Pessoa;
    public $Id_Operacao;
    public $Dt_Transacao;
    public $Nr_Transacao;
    public $Tp_Situacao;
    public $Dt_Cancelamento;
}
?>