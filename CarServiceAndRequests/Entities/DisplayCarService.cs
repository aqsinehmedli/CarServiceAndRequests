using CarServiceAndRequests.Context;

namespace CarServiceAndRequests.Entities;

public class DisplayCarService
{
    private CarServiceDbContext context;

    public DisplayCarService()
    {
    }

    public DisplayCarService(CarServiceDbContext context)
    {
        this.context = context;
    }

    public void AddCar()
    {
        Console.Write("Model:");
        var model = Console.ReadLine();
        Console.Write("Vendor:");
        var vendor = Console.ReadLine();
        Console.Write("Price:");
        var priceInput = Console.ReadLine();

        if (float.TryParse(priceInput, out float price))
        {
            var car = new Car
            {
                Model = model,
                Vendor = vendor,
                Price = (int)price,
                InsertedDate = DateTime.UtcNow
            };
            //_context.InsertedDate = DateTime.Now;


            using (var context = new CarServiceDbContext())
            {
                context.Cars.Add(car);
                context.SaveChanges();
            }

            Console.WriteLine("Car successfully added!");
        }
        else
        {
            Console.WriteLine("Invalid price format.");
        }
    }

    public void DeleteCar(int id)
    {
        var car = context.Cars.FirstOrDefault(c => c.Id == id);
        if (car == null)
        {
            Console.WriteLine("Car not found.");
            return;
        }

        car.IsDeleted = true;
        car.DeletedDate = DateTime.UtcNow;
        context.SaveChanges();

        Console.WriteLine("Car deleted successfully.");
    }
    public void UpdateCar(int id)
    {
        var car = context.Cars.FirstOrDefault(c => c.Id == id);
        if (car == null)
        {
            Console.WriteLine("Car not found.");
            return;
        }
        else
        {
            context.Cars.Update(car);
            car.UpdatedDate = DateTime.UtcNow;
            context.SaveChanges();
        }
    }

}

