namespace CombinableEnumValues
{
    using System;

    [Flags]
   public enum Margins
    {
        None = 0,
        Top = 1 << 0,
        Left = 1 << 1,
        Bottom = 1<< 2,
        Right = 1 << 3
    }
}
