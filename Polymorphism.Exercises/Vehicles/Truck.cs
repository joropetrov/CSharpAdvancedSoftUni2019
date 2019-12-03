namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double AirConditionAdditionConsump = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += AirConditionAdditionConsump;
        }

        public override void Refuel(double fuel)
        {
            fuel *= 0.95;
            base.Refuel(fuel);  
        }
    }
}
