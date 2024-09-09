namespace CarServiceAndRequests.Entities;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime InsertedDate { get; set; }
    public DateTime DeletedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
}
