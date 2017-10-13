<?php

define ("LOG_PATH", "D:/xampp/apache/logs/");

class Logger
{
    private static $instance;

    public static function Instance()
    {
        if (!isset(self::$instance))
            self::$instance = new Logger();
        return self::$instance;
    } 
    
    //--

    protected function Log($tipo, $method, $message)
    {
        $data = date('d.m.Y h:i:s');
        $log = 
            "<log>\n" .
            "<data>$data<data/>\n" . 
            "<tipo>$tipo</tipo>\n" . 
            "<mensagem>$message</mensagem>\n" . 
            "<metodo>$method</metodo>\n" . 
            "</log>\n\n" ;
        $path = LOG_PATH . date("Y.m.d") . ".audit.xml";
        error_log($log, 3, $path);
    }

    public function Debug($method, $message)
    {
        $this->Log("DEBUG", $method, $message);
    }

    public function Erro($method, $message)
    {
        $this->Log("ERRO", $method, $message);
    }

    public function Info($method, $message)
    {
        $this->Log("INFO", $method, $message);
    }

    public function Warning($method, $message)
    {
        $this->Log("WARNING", $method, $message);
    }    
}
?>