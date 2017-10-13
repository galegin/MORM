<?php

class Objeto
{
    public static function SetValues($obj, $values)
    {
        foreach ($obj as $name => $value)
            $obj->{$name} = $values[$name];
    }
}
?>