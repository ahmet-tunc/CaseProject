using Core.Entities.Abstract;

namespace Core.Entities.Concrete
{
    public class EntityBase : IEntity
    {
        public virtual int Id { get; set; }
        public int CreatedUserId { get; set; }
        public int UpdatedUserId { get; set; }
    }
}
