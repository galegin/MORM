<?php

define("DATABASE", "igreja");
define("USERNAME", "root");
define("PASSWORD", "");
define("HOSTNAME", "localhost");

class Parametro
{
    private static $instance;

    public static function Instance()
    {
        if (!isset(self::$instance))
            self::$instance = new Parametro(DATABASE, USERNAME, PASSWORD, HOSTNAME);
        return self::$instance;
    }
    
    //--
    
    public function __construct($database, $username, $password, $hostname)
    {
        $this->Database = $database;
        $this->Username = $username;
        $this->Password = $password;
        $this->Hostname = $hostname;
    }
    
    public $Hostname;
    public $Username;
    public $Password;
    public $Database;    
}
?>