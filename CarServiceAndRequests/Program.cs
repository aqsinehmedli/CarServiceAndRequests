using CarServiceAndRequests.Context;
using CarServiceAndRequests.Entities;

class Program
{


    static void Main(string[] args)
    {
        DisplayCarService displayCarService = new DisplayCarService();
        Console.WriteLine("Add a new car:");
        displayCarService.AddCar();

        //displayCarService.DeleteCar(1);
        displayCarService.UpdateCar(1);
    }
}