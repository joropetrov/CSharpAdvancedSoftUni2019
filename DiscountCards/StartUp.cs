using System;

namespace DiscountCards
{
    class StartUp
    {
        static void Main(string[] args)
        {
            BronzeCard bronzeCard = new BronzeCard(90, 150);
            BronzeCard bronzeCard1 = new BronzeCard(600, 250);
            SilverCard silverClass = new SilverCard(600, 850);
            GoldCard goldCard = new GoldCard(1500, 1300);

            PayDeck.AddBronzeCard(bronzeCard);
            PayDeck.AddBronzeCard(bronzeCard1);
            PayDeck.AddSilverCard(silverClass);
            PayDeck.AddGoldCard(goldCard);

            PayDeck.BronzeCards();
            PayDeck.SilverCards();
            PayDeck.GoldCards();
        }
    }
}
