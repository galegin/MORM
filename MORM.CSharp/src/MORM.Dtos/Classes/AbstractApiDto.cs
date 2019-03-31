namespace MORM.Dtos
{
    public class AbstractApiDto : AbstractDto
    {
    }

    public class AbstractApiDto<TObject> : AbstractDto<TObject>
        where TObject : class
    {
    }
}