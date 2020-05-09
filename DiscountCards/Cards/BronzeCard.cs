using System.Text;

namespace DiscountCards
{
    public class BronzeCard : Card
    {
        private string owner;
        private double turnOver;
        private double discountRate;
        private double purchaseValue;
        private double calculatedDiscount;
        private double totalSum;
        public BronzeCard(double turnOver, double purchaseValue)
        {
            this.turnOver = turnOver;
            this.purchaseValue = purchaseValue;
            this.discountRate = CalculateDiscountRate();
            this.calculatedDiscount = CalculateDiscount();
            this.totalSum = CalculateTotal();
        }

        public override double CalculateDiscount()
        {
            return this.calculatedDiscount = (this.purchaseValue * this.discountRate)/100;
        }
        public override double CalculateTotal()
        {
           return this.totalSum = this.purchaseValue - this.calculatedDiscount;
        }

        public override double CalculateDiscountRate()
        {
            if (this.turnOver < 100)
            {
                this.discountRate = 0;
            }
            else if (this.turnOver >= 100 && this.turnOver <= 300)
            {
                this.discountRate = 1;
            }
            else
            {
                this.discountRate = 2.5;
            }

            return this.discountRate;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Purchase value: ${this.purchaseValue:f2}");
            sb.AppendLine($"Discount rate: {this.discountRate:f1}%");
            sb.AppendLine($"Discount: ${this.calculatedDiscount:f2}");
            sb.AppendLine($"Total: {this.totalSum:f2}%");

            return sb.ToString();
        }
    }
}
