namespace Interfaces.Entities
{
    public interface IBaseEntity : IHaveId, IHaveName
    {
        string ToString();
    }
 }
