namespace Albaflex.Data.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; protected set; } = DateTime.Now;
        public DateTime UpdatedAt { get; protected set; } = DateTime.Now;

        public void SetId(Guid id)
        {
            Id = id;
        }

        public void UpdateAudit()
        {
            UpdatedAt = DateTime.Now;
        }
    }
}
