namespace Vehicles
{
    using System;

    public class Truck : Vehicle
    {
        private const double AirConditionAdditionConsump = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += AirConditionAdditionConsump;
        }

        public override void Refuel(double fuel)
        {
            if (this.FuelQuantity + fuel > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {fuel} fuel in the tank");
            }

            fuel *= 0.95;
            base.Refuel(fuel);  
        }
    }
}
