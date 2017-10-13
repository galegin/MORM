<?php

require_once("conexao.php");
require_once("comando.php");
require_once("parametro.php");
require_once("collection.php");
require_once("collectionitem.php");
require_once("objeto.php");

class Contexto
{
    private static $instance;

    public static function Instance()
    {
        if (!isset(self::$instance))
            self::$instance = new Contexto(Parametro::Instance());
        return self::$instance;
    }
    
    //--

    function __construct($parametro)
    {
        $this->Parametro = $parametro;
        $this->Conexao = new ConexaoMySql($parametro);
    }
    
    public $Parametro;
    public $Conexao;

    //-- lista
    
    public function GetLista($class, $where = "")
    {
        $collection = new Collection($class);
        $sql = Comando::GetSelect($class, $where);
        $query = $this->Conexao->GetConsulta($sql);
        foreach ($query as $row)
        {
            $obj = $collection->Add();
            Objeto::SetValues($obj, $row);
        }
        return $lista;
    }

    public function SetLista($lista)
    {
        foreach ($lista as $obj) 
            $this->SetObjeto($obj);
    }
    
    public function RemLista($lista)
    {
        foreach ($lista as $obj)
            $this->RemObjeto($obj);
    }
    
    //-- objeto
    
    public function GetObjeto($class, $where = "")
    {
        $sql = Comando::GetSelect($class, $where);
        $query = $this->Conexao->GetConsulta($sql);
        $row = $query->fetch();
        $obj = new $class();
        Objeto::SetValues($obj, $row);
        return $obj;
    }

    public function SetObjeto($obj)
    {
        $sql = Comando::GetSelectObj($obj);
        $query = $this->Conexao->GetConsulta($sql);
        $row = $query->fetch();
        $cmd = "";
        if ($row["Codigo"] > 0)
            $cmd = Comando::GetUpdate($obj);
        else
            $cmd = Comando::GetInsert($obj);
        $this->Conexao->ExecComando($cmd);
    }

    public function RemObjeto($obj)
    {
        $cmd = Comando::GetDelete($obj);
        $this->Conexao->ExecComando($cmd);
    }
}
?>