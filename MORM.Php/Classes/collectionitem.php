<?php

class Collection
{
    public function GetTabela()
    {
        return get_class($this);
    }
    
    public function GetCampo($campo)
    {
        return strtoupper($atr);
    }
    
    private $_campos;
    
    public function SetRelacao($campos)
    {
        $this->_campos = $campos;
    }
}
?>