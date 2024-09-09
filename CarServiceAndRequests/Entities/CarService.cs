
namespace CarServiceAndRequests.Entities;

public class CarService : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Car> Cars { get; set; }

    internal void SaveChanges()
    {
        throw new NotImplementedException();
    }
}
