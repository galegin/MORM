<?php

require_once("../../models/collectionitem.php");

class AgendaServico extends CollectionItem
{
    public $Codigo;
    public $Codigo_Tipo_Servico;
    public $Codigo_Localidade;
    public $Dia_Semana;
    public $Semana_Mes;
    public $Hora;
    public $Complemento;
    public $Atendente;
}
?>