using Core.Entities.Concrete;

namespace Core.Entities.Abstract
{
    public interface IEntity
    {
        public int Id { get; set; }
        public int CreatedUserId { get; set; }
        public int UpdatedUserId { get; set; }
    }
}
