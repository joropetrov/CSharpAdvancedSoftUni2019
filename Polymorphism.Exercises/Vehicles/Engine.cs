namespace Vehicles
{
    using System;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine()
                .Split()
                .ToArray();

            string[] truckInfo = Console.ReadLine()
                .Split()
                .ToArray();

            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);

            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckConsumption = double.Parse(truckInfo[2]);

            var car = new Car(carFuelQuantity, carFuelConsumption);
            var truck = new Truck(truckFuelQuantity, truckConsumption);

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] inputInfo = Console.ReadLine()
                    .Split()
                    .ToArray();

                string command = inputInfo[0];
                string vehicleType = inputInfo[1];
                double value = double.Parse(inputInfo[2]);

                if (command == "Drive")
                {
                    if (vehicleType == "Car")
                    {
                        DriveVehicle(car, value);
                    }

                    else if (vehicleType == "Truck")
                    {
                        DriveVehicle(truck, value);
                    }
                }
                
                else if (command == "Refuel")
                {

                    if (vehicleType == "Car")
                    {
                        car.Refuel(value);
                    }
                    else if (vehicleType == "Truck")
                    {
                        truck.Refuel(value);
                    }
                }

            }
            Console.WriteLine($"Car: {Math.Round(car.FuelQuantity, 2, MidpointRounding.ToEven):F2}");
            Console.WriteLine($"Truck: {Math.Round(truck.FuelQuantity, 2, MidpointRounding.ToEven):F2}");

        }

         static void DriveVehicle(Vehicle vehicle, double value)
        {
            bool canTravel = vehicle.Drive(value);

            string result = !canTravel
                ? $"{vehicle.GetType().Name} needs refueling"
                : $"{vehicle.GetType().Name} travelled {value} km";
            Console.WriteLine(result);
            //if travelledDistance is 0, stringresult is "needs refueling", else -the second message 
        }
    }
}
