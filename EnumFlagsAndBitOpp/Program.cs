namespace CombinableEnumValues
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var bottomRightMargin = Margins.Bottom | Margins.Right;
            var topLeftMargin = Margins.Top | Margins.Left;

            //getting info
            Console.WriteLine("borromRightMargin string value: {0}", bottomRightMargin);
            Console.WriteLine("borromRightMargin integer value: {0}", (int)bottomRightMargin);
            Console.WriteLine("borromRightMargin == Margins.Bottom: {0}", bottomRightMargin == Margins.Bottom);
            Console.WriteLine(
                "borromRightMargin has flag Margins.Bottom: {0}",
                bottomRightMargin.HasFlag(Margins.Bottom));

            //combining combinations
            Console.WriteLine("bottomRightMargin and topLeftMargin: {0}", bottomRightMargin | topLeftMargin);

            //Toggling vals
            bottomRightMargin ^= Margins.Bottom;
            Console.WriteLine("borromRightMargin ^= Margins.Bottom => {0}", bottomRightMargin);  
            bottomRightMargin ^= Margins.Bottom;
            Console.WriteLine("borromRightMargin ^= Margins.Bottom => {0}", bottomRightMargin);  

        }
    }
}
