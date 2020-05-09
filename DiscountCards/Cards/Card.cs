namespace DiscountCards
{
    public abstract class Card : IDiscauntable
    {
        public abstract double CalculateDiscount();

        public abstract double CalculateDiscountRate();
        
        public abstract double CalculateTotal();

    }
}
