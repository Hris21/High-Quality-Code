namespace Santase.tests
{
    using NUnit.Framework;
    using Logic;
    using Santase.Logic.Cards;
    using System;

    [TestFixture]
    public class UnitTest1
    {
        [TestCase(24)]
        public void NewDeckShouldContain24Cards(int intitialCardsCount)
        {
            Deck testDeck = new Deck();
            Assert.AreEqual(intitialCardsCount, testDeck.CardsLeft, "A new deck should contain 24 cards, precisely.");
        }

        [Test]
        public void TrumpCardShouldBeAValidCard()
        {
            Deck testDeck = new Deck();
            Assert.IsTrue(Enum.IsDefined(typeof(CardSuit), testDeck.GetTrumpCard.Suit), "Card must have one of the predefined suits");
            Assert.IsTrue(Enum.IsDefined(typeof(CardType), testDeck.GetTrumpCard.Type), "Card must have one of the predefined types");
        }

        [Test]
        public void TestsIfCardRemovalWorks()
        {
            Deck testDeck = new Deck();
            int initialCardsCount = testDeck.CardsLeft;
            testDeck.GetNextCard();
            Assert.AreEqual((initialCardsCount - 1), testDeck.CardsLeft, "GetNextCard() should remove 1 card from the deck");
        }

        [Test]
        public void WhenACardIsDrawnTwentyThreeCardsShouldRemainInTheDeck()
        {
            var deck = new Santase.Logic.Cards.Deck();
            var card = deck.GetNextCard();
            Assert.AreEqual(23, deck.CardsLeft);
        }

        [TestCase(25)]
        [ExpectedException(typeof(InternalGameException))]
        public void GetNextCardShouldThrowAnInternalGameExceptionWhenThereAreNoCardsLeftInTheDeck(int cardsToBeDrawn)
        {
            Deck testDeck = new Deck();
            for (int i = 0; i < cardsToBeDrawn; i++)
            {
                testDeck.GetNextCard();
            }
        }

        [Test]
        public void ChangeTrumpCardShouldChangeTheTrumpCardIfThereAreCardsLeftInTheDeck()
        {
            Deck testDeck = new Deck();
            Card initialTrumpCard = testDeck.GetTrumpCard;
            Card newCard = testDeck.GetNextCard();
            testDeck.ChangeTrumpCard(newCard);
            Assert.AreNotSame(initialTrumpCard, testDeck.GetTrumpCard);
        }
    }
}