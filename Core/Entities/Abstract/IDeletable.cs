namespace Core.Entities.Abstract
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }
    }
}