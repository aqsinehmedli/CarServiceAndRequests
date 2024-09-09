namespace CarServiceAndRequests.Entities;

public class Car : BaseEntity
{
    public string Model { get; set; }
    public string Vendor { get; set; }
    public float Price { get; set; }
    public ICollection<CarService> CarServices { get; set; }
}
