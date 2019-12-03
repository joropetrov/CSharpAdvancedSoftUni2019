namespace Vehicles
{
   public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelConsumption = fuelConsumption;
            this.FuelQuantity = fuelQuantity;
        }

        //TODO add validation
        public double FuelQuantity
        {
            get { return fuelQuantity; }
           protected set { fuelQuantity = value; }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
           protected set { fuelConsumption = value; }
        }

        public bool Drive(double distance)
        {
            bool canDrive = this.FuelQuantity - this.FuelConsumption * distance >= 0;

            if (canDrive)
            {
                this.FuelQuantity -= this.FuelConsumption * distance;

                return true;
            }
            //throw new InvalidOperationException , in normal case, but in our task- not;
            return false;
        }

        public virtual void Refuel(double fuel)
        {
            this.FuelQuantity += fuel;
        }
    }
}
