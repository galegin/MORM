<?php 

require_once("../../models/collectionitem.php");

class IgrejaServicoConsulta extends CollectionItem
{
	public $Codigo_Localidade;
	public $Nome_Localidade;
	public $Tipo_Localidade;
	public $Codigo_Servico;
	public $Codigo_Reuniao;
	public $Descricao_Reuniao;
	public $Codigo_Tipo_Servico;
	public $Descricao_Tipo_Servico;
	public $Tipo_Servico;
	public $Ordem_Servico;
	public $Data_Inicio;
	public $Data_Termino;
	public $Hora_Inicio;
	public $Hora_Termino;
	public $Complemento;
	public $Atendente;
	public $Qtde_Irmao;
	public $Qtde_Irma;

	public function GetAtendente($index)
	{
		$atendente = '/' . ($this->Atendente ?: '') . '/';
		$atendentes = explode("/", $atendente);
		return trim($atendentes[$index]);
	}
}
?>