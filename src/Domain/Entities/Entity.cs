namespace Domain.Entities
{
    public class Entity
    {
        public Guid Id { get; protected set; }
        public bool IsActive { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
    }
}