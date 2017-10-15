<?php

require_once("collectionitem.php");

class public Usuario extends CollectionItem
{
    public $Id_Usuario;
    public $U_Version;
    public $Cd_Operador;
    public $Dt_Cadastro;
    public $Nm_Usuario;
    public $Nm_Login;
    public $Cd_Senha;
    public $Cd_Papel;
    public $Tp_Bloqueio;
    public $Dt_Bloqueio;
}
?>