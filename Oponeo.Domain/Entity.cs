namespace Oponeo.Domain;

public class Entity
{
    public long Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
}