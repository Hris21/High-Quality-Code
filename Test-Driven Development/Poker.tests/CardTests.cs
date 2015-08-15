namespace Poker.tests
{
    using NUnit.Framework;
    using Poker;
    using System;

    [TestFixture]
    public class CardTests
    {
        [Test]
        public void ToStringShouldReturnTheCardFaceAndTheCardSuitWhenTheCardIsAnAce()
        {
            Card testCard = new Card(CardFace.Ace, CardSuit.Spades);
            Console.WriteLine(testCard);
            Assert.AreEqual(
                "A♠",
                testCard.ToString(),
                "Card ToString method should return string in the format '[CardFace - number or capital first letter][Card Suit Char]'.");
        }

        [Test]
        public void ToStringShouldReturnTheCardFaceAndTheCardSuitWhenTheCardIsAKing()
        {
            Card testCard = new Card(CardFace.King, CardSuit.Diamonds);
            Assert.AreEqual(
                "K♦",
                testCard.ToString(),
                "Card ToString method should return string in the format '[CardFace - number or capital first letter][Card Suit Char]'.");
        }

        [Test]
        public void ToStringShouldReturnTheCardFaceAndTheCardSuitWhenTheCardIsAQueen()
        {
            Card testCard = new Card(CardFace.Queen, CardSuit.Clubs);
            Assert.AreEqual(
                "Q♣",
                testCard.ToString(),
                "Card ToString method should return string in the format '[CardFace - number or capital first letter][Card Suit Char]'.");
        }

        [Test]
        public void ToStringShouldReturnTheCardFaceAndTheCardSuitWhenTheCardFaceIsANumber()
        {
            Card testCard = new Card(CardFace.Three, CardSuit.Hearts);
            Assert.AreEqual(
                "3♥",
                testCard.ToString(),
                "Card ToString method should return string in the format '[CardFace - number or capital first letter][Card Suit Char]'.");
        }

        [Test]
        public void ToStringShouldReturnTheCardFaceAndTheCardSuitWhenTheCardIsAJack()
        {
            Card testCard = new Card(CardFace.Jack, CardSuit.Spades);
            Assert.AreEqual(
                "J♠",
                testCard.ToString(),
                "Card ToString method should return string in the format '[CardFace - number or capital first letter][Card Suit Char]'.");
        }
    }
}