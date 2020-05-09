using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountCards
{
   public static class PayDeck
    {
        private static List<GoldCard> goldCards = new List<GoldCard>();
        private static List<SilverCard> silverCards = new List<SilverCard>();
        private static List<BronzeCard> bronzeCards = new List<BronzeCard>();

        public static void AddGoldCard (GoldCard goldCard)
        {
                goldCards.Add(goldCard);
        }
        public static void AddSilverCard(SilverCard silverCard)
        {
            silverCards.Add(silverCard);
        }
        public static void AddBronzeCard(BronzeCard bronzeCard)
        {
            bronzeCards.Add(bronzeCard);
        }
        public static void GoldCards()
        {
            foreach (var card in goldCards)
            {
                Console.WriteLine(card.ToString());
            }
        }
        public static void SilverCards()
        {
            foreach (var card in silverCards)
            {
                Console.WriteLine(card.ToString());
            }
        }
        public static void BronzeCards()
        {
            foreach (var card in bronzeCards)
            {
                Console.WriteLine(card.ToString());
            }
        }


    }
}
