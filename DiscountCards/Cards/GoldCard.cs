using System.Text;

namespace DiscountCards
{
    public class GoldCard : Card
    {
        private string owner;
        private double turnOver;
        private double discountRate = 2;
        private double purchaseValue;
        private double calculatedDiscount;
        private double totalSum;
        public GoldCard(double turnOver, double purchaseValue) 
        {
            this.turnOver = turnOver;
            this.purchaseValue = purchaseValue;
            this.discountRate = CalculateDiscountRate();
            this.calculatedDiscount = CalculateDiscount();
            this.totalSum = CalculateTotal();
        }
        public override double CalculateDiscount()
        {
            return this.calculatedDiscount = (this.purchaseValue * this.discountRate) / 100;
        }

        public override double CalculateDiscountRate()
        {
            int additionalDiscount = 0;
            additionalDiscount = (this.turnOver >= 100)? (int)turnOver / 100 : 0;

            if (additionalDiscount + discountRate > 10)
            {
                this.discountRate = 10;
                return this.discountRate;
            }
            this.discountRate += additionalDiscount;
            return discountRate;
        }

        public override double CalculateTotal()
        {
            return this.totalSum = this.purchaseValue - this.calculatedDiscount;
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

