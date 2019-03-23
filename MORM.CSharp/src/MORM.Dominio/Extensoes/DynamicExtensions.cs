namespace MORM.Dominio.Extensoes
{
    public static class DynamicExtensions
    {
        public static void SetValueFromObjeto(this object obj, object objDes)
        {
            obj.GetCampos().ForEach(campo => 
            {
                obj.SetInstancePropOrField(campo.Atributo, objDes.GetInstancePropOrField(campo.Atributo));
            });
        }
    }
}