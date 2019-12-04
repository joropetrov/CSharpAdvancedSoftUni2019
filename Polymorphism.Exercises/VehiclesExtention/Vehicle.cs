using System;

namespace Vehicles
{
   public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelConsumption = fuelConsumption;
            this.FuelQuantity = fuelQuantity;
        }

        
        public double TankCapacity
        {
            get
            {
                return tankCapacity;
            }

            private set
            {
                tankCapacity = value;
            }
        }
        
        public double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }

           private set
            {
                if (value > this.TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }

        public virtual double FuelConsumption
        {
            get { return fuelConsumption; }
           protected set { fuelConsumption = value; }
        }

        public virtual bool Drive(double distance)
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
            if (fuel <= 0 )
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }
            if (this.FuelQuantity + fuel > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {fuel} fuel in the tank");
            }
            this.FuelQuantity += fuel;
        }
    }
}
