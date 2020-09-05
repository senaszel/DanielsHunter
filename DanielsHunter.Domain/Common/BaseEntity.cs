namespace DanielsHunter.Domain.Entity
{
    public class BaseEntity : AuditableModel
    {
        public int Id { get; }
        public bool IsCurrent { get; set; }
    }
}
