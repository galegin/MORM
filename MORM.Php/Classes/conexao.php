<?php

require_once("logger.php");
require_once("parametro.php");

class ConexaoMySql
{
    public function __construct($parametro)
    {
        $this->Parametro = $parametro;
        $this->SetConexao();
    }

    public $Parametro;
    public $Conexao;

    private function SetConexao()
    {
        $this->Conexao = new PDO("mysql:host=$this->Parametro->Hostname;dbname=$this->Parametro->Database", $this->Parametro->Username, $this->Parametro->Password);
        $this->Conexao->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);            
        if (!$this->Conexao)
            throw new Exception("Erro ao connectar", 1);
    }

    /*
    $conn = new ConexaoMySql("localhost", "root", "", "igreja");
    $row = $conn->GetConsulta("select Codigo, Nome from Pessoa");
    echo $row["Codigo"];
    echo $row["Nome"];
    */
    public function GetConsulta($sql)
    {
        $METHOD = "ConexaoMySql.GetConsulta";
        Logger::Instance()->Info($METHOD, "sql: " . $sql);

        if (is_null($sql))
            throw new Exception("Consulta deve ser informada", 1);

        try 
        {
            return $this->Conexao->query($sql);
        }
        catch (Exception $e)
        {
            Logger::Instance()->Erro($METHOD, $e->getMessage());
            throw new Exception("Error " . $e->getMessage(), 1);
        }
    }    

    /*
    $conn = new ConexaoMySql("localhost", "root", "", "igreja");
    $conn->ExecComando("insert into Pessoa(Codigo, Nome) values ('$Codigo', '$Nome')");
    */
    public function ExecComando($cmd)
    {
        $METHOD = "ConexaoMySql.ExecComando";
        Logger::Instance()->Info($METHOD, "cmd: " . $cmd);

        if (is_null($cmd))
            throw new Exception("Comando deve ser informado", 1);

        try 
        {
            $this->Conexao->exec($cmd);
        }
        catch (Exception $e)
        {
            Logger::Instance()->Erro($METHOD, $e->getMessage());
            throw new Exception("Error " . $e->getMessage(), 1);
        }
    }
}
?>