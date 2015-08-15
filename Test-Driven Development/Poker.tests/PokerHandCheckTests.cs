using NUnit.Framework;
using System.Collections.Generic;

namespace Poker.tests
{
    [TestFixture]
    public class PokerHandCheckTests
    {
        private Hand testValidHand =
        new Hand(
            new List<ICard>
                {
                        new Card(CardFace.Ace, CardSuit.Clubs),
                        new Card(CardFace.Ten, CardSuit.Spades),
                        new Card(CardFace.Jack, CardSuit.Hearts),
                        new Card(CardFace.Eight, CardSuit.Clubs),
                        new Card(CardFace.Eight, CardSuit.Diamonds)
                });

        private Hand testValidFlushHand =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Ace, CardSuit.Clubs),
                        new Card(CardFace.Ten, CardSuit.Clubs),
                        new Card(CardFace.Jack, CardSuit.Clubs),
                        new Card(CardFace.Eight, CardSuit.Clubs),
                        new Card(CardFace.Nine, CardSuit.Clubs)
                    });

        private Hand testValidFlushHand2 =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Ace, CardSuit.Clubs),
                        new Card(CardFace.Ten, CardSuit.Clubs),
                        new Card(CardFace.Five, CardSuit.Clubs),
                        new Card(CardFace.Eight, CardSuit.Clubs),
                        new Card(CardFace.Nine, CardSuit.Clubs)
                    });

        private Hand testInvalidHandWithLessCards =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Ace, CardSuit.Clubs),
                        new Card(CardFace.Ten, CardSuit.Spades),
                        new Card(CardFace.Jack, CardSuit.Hearts),
                        new Card(CardFace.Eight, CardSuit.Clubs)
                    });

        private Hand testInvalidHandWithMoreCards =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Ace, CardSuit.Clubs),
                        new Card(CardFace.Ten, CardSuit.Spades),
                        new Card(CardFace.Jack, CardSuit.Hearts),
                        new Card(CardFace.Eight, CardSuit.Clubs),
                        new Card(CardFace.Eight, CardSuit.Diamonds),
                        new Card(CardFace.Nine, CardSuit.Diamonds)
                    });

        private Hand testInvalidHandWithSameCards =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Ace, CardSuit.Clubs),
                        new Card(CardFace.Ten, CardSuit.Spades),
                        new Card(CardFace.Jack, CardSuit.Hearts),
                        new Card(CardFace.Eight, CardSuit.Clubs),
                        new Card(CardFace.Eight, CardSuit.Clubs)
                    });

        private Hand testValidOnePairHand =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.King, CardSuit.Clubs),
                        new Card(CardFace.Ten, CardSuit.Spades),
                        new Card(CardFace.Jack, CardSuit.Hearts),
                        new Card(CardFace.Eight, CardSuit.Diamonds),
                        new Card(CardFace.Eight, CardSuit.Clubs)
                    });

        private Hand testValidOnePairHand2 =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.King, CardSuit.Clubs),
                        new Card(CardFace.Five, CardSuit.Spades),
                        new Card(CardFace.Jack, CardSuit.Hearts),
                        new Card(CardFace.Ten, CardSuit.Diamonds),
                        new Card(CardFace.Ten, CardSuit.Clubs)
                    });

        private Hand testValidFourOfAKindHand = new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Eight, CardSuit.Spades),
                        new Card(CardFace.Eight, CardSuit.Hearts),
                        new Card(CardFace.Jack, CardSuit.Hearts),
                        new Card(CardFace.Eight, CardSuit.Diamonds),
                        new Card(CardFace.Eight, CardSuit.Clubs)
                    });

        private Hand testValidFourOfAKindHand2 = new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Seven, CardSuit.Spades),
                        new Card(CardFace.Seven, CardSuit.Hearts),
                        new Card(CardFace.Jack, CardSuit.Hearts),
                        new Card(CardFace.Seven, CardSuit.Diamonds),
                        new Card(CardFace.Seven, CardSuit.Clubs)
                    });

        private Hand testValidFourOfAKindHand3 = new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Seven, CardSuit.Spades),
                        new Card(CardFace.Seven, CardSuit.Hearts),
                        new Card(CardFace.Five, CardSuit.Hearts),
                        new Card(CardFace.Seven, CardSuit.Diamonds),
                        new Card(CardFace.Seven, CardSuit.Clubs)
                    });

        private Hand testValidHigCardHand =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Ace, CardSuit.Clubs),
                        new Card(CardFace.Ten, CardSuit.Spades),
                        new Card(CardFace.Jack, CardSuit.Hearts),
                        new Card(CardFace.Eight, CardSuit.Clubs),
                        new Card(CardFace.Nine, CardSuit.Clubs)
                    });

        private Hand testValidHigCardHand2 =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Ace, CardSuit.Clubs),
                        new Card(CardFace.Ten, CardSuit.Spades),
                        new Card(CardFace.Two, CardSuit.Hearts),
                        new Card(CardFace.Eight, CardSuit.Clubs),
                        new Card(CardFace.Nine, CardSuit.Clubs)
                    });

        private Hand testValidTwoPairHand =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Ace, CardSuit.Clubs),
                        new Card(CardFace.Ten, CardSuit.Spades),
                        new Card(CardFace.Ten, CardSuit.Hearts),
                        new Card(CardFace.Eight, CardSuit.Clubs),
                        new Card(CardFace.Eight, CardSuit.Diamonds)
                    });

        private Hand testValidTwoPairHand4 =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Seven, CardSuit.Clubs),
                        new Card(CardFace.Ten, CardSuit.Spades),
                        new Card(CardFace.Ten, CardSuit.Hearts),
                        new Card(CardFace.Eight, CardSuit.Clubs),
                        new Card(CardFace.Eight, CardSuit.Diamonds)
                    });

        private Hand testValidTwoPairHand2 =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Ace, CardSuit.Clubs),
                        new Card(CardFace.Jack, CardSuit.Spades),
                        new Card(CardFace.Jack, CardSuit.Hearts),
                        new Card(CardFace.Eight, CardSuit.Clubs),
                        new Card(CardFace.Eight, CardSuit.Diamonds)
                    });

        private Hand testValidTwoPairHand3 =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Ace, CardSuit.Clubs),
                        new Card(CardFace.Ten, CardSuit.Spades),
                        new Card(CardFace.Ten, CardSuit.Hearts),
                        new Card(CardFace.Two, CardSuit.Clubs),
                        new Card(CardFace.Two, CardSuit.Diamonds)
                    });

        private Hand testValidThreeOfAKindHand =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Ace, CardSuit.Clubs),
                        new Card(CardFace.Ten, CardSuit.Spades),
                        new Card(CardFace.Ten, CardSuit.Hearts),
                        new Card(CardFace.Ten, CardSuit.Clubs),
                        new Card(CardFace.Eight, CardSuit.Diamonds)
                    });

        private Hand testValidThreeOfAKindHand2 =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.King, CardSuit.Clubs),
                        new Card(CardFace.Nine, CardSuit.Spades),
                        new Card(CardFace.Nine, CardSuit.Hearts),
                        new Card(CardFace.Nine, CardSuit.Clubs),
                        new Card(CardFace.Eight, CardSuit.Diamonds)
                    });

        private Hand testValidThreeOfAKindHand3 =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Ace, CardSuit.Clubs),
                        new Card(CardFace.Nine, CardSuit.Spades),
                        new Card(CardFace.Nine, CardSuit.Hearts),
                        new Card(CardFace.Nine, CardSuit.Clubs),
                        new Card(CardFace.Eight, CardSuit.Diamonds)
                    });

        private Hand testValidFullHouseHand =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Ace, CardSuit.Clubs),
                        new Card(CardFace.Ten, CardSuit.Spades),
                        new Card(CardFace.Ten, CardSuit.Hearts),
                        new Card(CardFace.Ten, CardSuit.Clubs),
                        new Card(CardFace.Ace, CardSuit.Diamonds)
                    });

        private Hand testValidFullHouseHand2 =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Ace, CardSuit.Clubs),
                        new Card(CardFace.Jack, CardSuit.Spades),
                        new Card(CardFace.Jack, CardSuit.Hearts),
                        new Card(CardFace.Jack, CardSuit.Clubs),
                        new Card(CardFace.Ace, CardSuit.Diamonds)
                    });

        private Hand testValidFullHouseHand3 =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Five, CardSuit.Clubs),
                        new Card(CardFace.Ten, CardSuit.Spades),
                        new Card(CardFace.Ten, CardSuit.Hearts),
                        new Card(CardFace.Ten, CardSuit.Clubs),
                        new Card(CardFace.Five, CardSuit.Diamonds)
                    });

        private Hand testValidStraightHand =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Five, CardSuit.Clubs),
                        new Card(CardFace.Six, CardSuit.Spades),
                        new Card(CardFace.Seven, CardSuit.Hearts),
                        new Card(CardFace.Eight, CardSuit.Clubs),
                        new Card(CardFace.Nine, CardSuit.Diamonds)
                    });

        private Hand testA2345Straight =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Five, CardSuit.Clubs),
                        new Card(CardFace.Four, CardSuit.Spades),
                        new Card(CardFace.Two, CardSuit.Hearts),
                        new Card(CardFace.Ace, CardSuit.Clubs),
                        new Card(CardFace.Three, CardSuit.Diamonds)
                    });

        private Hand test23456Straight =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Five, CardSuit.Clubs),
                        new Card(CardFace.Four, CardSuit.Spades),
                        new Card(CardFace.Two, CardSuit.Hearts),
                        new Card(CardFace.Six, CardSuit.Clubs),
                        new Card(CardFace.Three, CardSuit.Diamonds)
                    });

        private Hand testTJQKAStraight =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Jack, CardSuit.Clubs),
                        new Card(CardFace.Ace, CardSuit.Spades),
                        new Card(CardFace.King, CardSuit.Hearts),
                        new Card(CardFace.Queen, CardSuit.Clubs),
                        new Card(CardFace.Ten, CardSuit.Diamonds)
                    });

        private Hand testValidStraightFlushHand =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Five, CardSuit.Clubs),
                        new Card(CardFace.Six, CardSuit.Clubs),
                        new Card(CardFace.Seven, CardSuit.Clubs),
                        new Card(CardFace.Eight, CardSuit.Clubs),
                        new Card(CardFace.Nine, CardSuit.Clubs)
                    });

        private Hand testA2345StraightFlushHand =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Five, CardSuit.Clubs),
                        new Card(CardFace.Two, CardSuit.Clubs),
                        new Card(CardFace.Ace, CardSuit.Clubs),
                        new Card(CardFace.Four, CardSuit.Clubs),
                        new Card(CardFace.Three, CardSuit.Clubs)
                    });

        private Hand testTJQKAStraightFlushHand =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Queen, CardSuit.Clubs),
                        new Card(CardFace.Ace, CardSuit.Clubs),
                        new Card(CardFace.Jack, CardSuit.Clubs),
                        new Card(CardFace.King, CardSuit.Clubs),
                        new Card(CardFace.Ten, CardSuit.Clubs)
                    });

        private Hand test23456StraightFlushHand =
            new Hand(
                new List<ICard>
                    {
                        new Card(CardFace.Five, CardSuit.Clubs),
                        new Card(CardFace.Two, CardSuit.Clubs),
                        new Card(CardFace.Six, CardSuit.Clubs),
                        new Card(CardFace.Four, CardSuit.Clubs),
                        new Card(CardFace.Three, CardSuit.Clubs)
                    });

        private PokerHandsChecker handChecker = new PokerHandsChecker();

        [Test]
        public void ValidHandShouldConsistOfFiveDifferentCards()
        {
            Assert.IsTrue(this.handChecker.IsValidHand(this.testValidHand));
        }

        [Test]
        public void ShouldReturnFalseWhenThereAreMoreThanFiveCards()
        {
            Assert.IsFalse(this.handChecker.IsValidHand(this.testInvalidHandWithMoreCards));
        }

        [Test]
        public void ShouldReturnFalseWhenThereAreLessThenFourCards()
        {
            Assert.IsFalse(this.handChecker.IsValidHand(this.testInvalidHandWithLessCards));
        }

        [Test]
        public void ShouldReturnFalseIfThereAreDuplicatingCards()
        {
            Assert.IsFalse(this.handChecker.IsValidHand(this.testInvalidHandWithSameCards));
        }

        [Test]
        public void ShouldReturnFalseIfNullValueIsPassedAsHand()
        {
            Assert.IsFalse(this.handChecker.IsValidHand(null));
        }

        [Test]
        public void IsFlushShouldReturnFalseWhenAnInvalidHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsFlush(this.testInvalidHandWithMoreCards));
            Assert.IsFalse(this.handChecker.IsFlush(this.testInvalidHandWithLessCards));
            Assert.IsFalse(this.handChecker.IsFlush(this.testInvalidHandWithSameCards));
        }

        [Test]
        public void IsFlushShouldReturnFalseWhenANonFlushHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsFlush(this.testValidHand));
        }

        [Test]
        public void IsFlushShouldReturnTrueWhenAFlushHandIsPassed()
        {
            Assert.IsTrue(this.handChecker.IsFlush(this.testValidFlushHand));
        }

        [Test]
        public void IsFlushShouldReturnFalseWhenAStraightFlushHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsFlush(this.testValidStraightFlushHand));
        }

        // IsFourOfAKind() tests
        [Test]
        public void IsFourOfAKindShouldReturnFalseWhenAnInvalidHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsFourOfAKind(this.testInvalidHandWithMoreCards));
            Assert.IsFalse(this.handChecker.IsFourOfAKind(this.testInvalidHandWithLessCards));
            Assert.IsFalse(this.handChecker.IsFourOfAKind(this.testInvalidHandWithSameCards));
        }

        [Test]
        public void IsFourOfAKindShouldReturnFalseWhenANonFourOfAKindHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsFourOfAKind(this.testValidHand));
        }

        [Test]
        public void IsFourOfAKindShouldReturnTrueWhenAFourOfAKindHandIsPassed()
        {
            Assert.IsTrue(this.handChecker.IsFourOfAKind(this.testValidFourOfAKindHand));
        }

        // IsHighCard() tests
        [Test]
        public void IsHighcardShouldReturnFalseWhenAnInvalidHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsHighCard(this.testInvalidHandWithMoreCards));
            Assert.IsFalse(this.handChecker.IsHighCard(this.testInvalidHandWithLessCards));
            Assert.IsFalse(this.handChecker.IsHighCard(this.testInvalidHandWithSameCards));
        }

        [Test]
        public void IsHighCardShouldReturnFalseWhenANonHighCardHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsHighCard(this.testValidHand));
        }

        [Test]
        public void IsHighCardShouldReturnTrueWhenAHighCardHandIsPassed()
        {
            Assert.IsTrue(this.handChecker.IsHighCard(this.testValidHigCardHand));
        }

        [Test]
        public void IsHighCardShouldReturnFalseWhenAFlushHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsHighCard(this.testValidFlushHand));
        }

        [Test]
        public void IsHighCardShouldReturnFalseWhenAStraightHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsHighCard(this.testValidStraightHand));
        }

        [Test]
        public void IsHighCardShouldReturnFalseWhenAStraightFlushHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsHighCard(this.testValidStraightFlushHand));
        }

        // IsOnePair() tests
        [Test]
        public void IsOnePairShouldReturnFalseWhenAnInvalidHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsOnePair(this.testInvalidHandWithLessCards));
            Assert.IsFalse(this.handChecker.IsOnePair(this.testInvalidHandWithMoreCards));
            Assert.IsFalse(this.handChecker.IsOnePair(this.testInvalidHandWithSameCards));
        }

        [Test]
        public void IsOnePairShouldReturnTrueWhenAValidOnePairHandIsPassed()
        {
            Assert.IsTrue(this.handChecker.IsOnePair(this.testValidHand));
        }

        [Test]
        public void IsOnePairShouldReturnFalseWhenAValidHighCardHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsOnePair(this.testValidHigCardHand));
        }

        [Test]
        public void IsOnePairShouldReturnFalseWhenAValidTwoPairHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsOnePair(this.testValidTwoPairHand));
        }

        [Test]
        public void IsOnePairShouldReturnFalseWhenAValidFourOfAKindHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsOnePair(this.testValidFourOfAKindHand));
        }

        [Test]
        public void IsOnePairShouldReturnFalseWhenAValidThreeOfAKindHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsOnePair(this.testValidThreeOfAKindHand));
        }

        [Test]
        public void IsOnePairShouldReturnFalseWhenAValidFullHouseHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsOnePair(this.testValidFullHouseHand));
        }

        // IsTwoPair() tests
        [Test]
        public void IsTwoPairShouldReturnFalseWhenAnInvalidHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsTwoPair(this.testInvalidHandWithLessCards));
            Assert.IsFalse(this.handChecker.IsTwoPair(this.testInvalidHandWithMoreCards));
            Assert.IsFalse(this.handChecker.IsTwoPair(this.testInvalidHandWithSameCards));
        }

        [Test]
        public void IsTwoPairShouldReturnTrueWhenAValidTwoPairHandIsPassed()
        {
            Assert.IsTrue(this.handChecker.IsTwoPair(this.testValidTwoPairHand));
        }

        [Test]
        public void IsTwoPairShouldReturnFalseWhenAValidHighCardHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsTwoPair(this.testValidHigCardHand));
        }

        [Test]
        public void IsTwoPairShouldReturnFalseWhenAValidOnePairHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsTwoPair(this.testValidHand));
        }

        [Test]
        public void IsTwoPairShouldReturnFalseWhenAValidFourOfAKindHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsTwoPair(this.testValidFourOfAKindHand));
        }

        [Test]
        public void IsTwoPairShouldReturnFalseWhenAValidThreeOfAKindHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsTwoPair(this.testValidThreeOfAKindHand));
        }

        [Test]
        public void IsTwoPairShouldReturnFalseWhenAValidFullHouseHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsTwoPair(this.testValidFullHouseHand));
        }

        // IsThreeOfAKind() tests
        [Test]
        public void IsThreeOfAKindShouldReturnFalseWhenAnInvalidHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsThreeOfAKind(this.testInvalidHandWithLessCards));
            Assert.IsFalse(this.handChecker.IsThreeOfAKind(this.testInvalidHandWithMoreCards));
            Assert.IsFalse(this.handChecker.IsThreeOfAKind(this.testInvalidHandWithSameCards));
        }

        [Test]
        public void IsThreeOfAKindShouldReturnTrueWhenAValidThreeOfAKindHandIsPassed()
        {
            Assert.IsTrue(this.handChecker.IsThreeOfAKind(this.testValidThreeOfAKindHand));
        }

        [Test]
        public void IsThreeOfAKindShouldReturnFalseWhenAValidHighCardHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsThreeOfAKind(this.testValidHigCardHand));
        }

        [Test]
        public void IsThreeOfAKindShouldReturnFalseWhenAValidOnePairHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsThreeOfAKind(this.testValidHand));
        }

        [Test]
        public void IsThreeOfAKindShouldReturnFalseWhenAValidFourOfAKindHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsThreeOfAKind(this.testValidFourOfAKindHand));
        }

        [Test]
        public void IsThreeOfAKindShouldReturnFalseWhenAValidTwoPairHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsThreeOfAKind(this.testValidTwoPairHand));
        }

        [Test]
        public void IsThreeOfAKindShouldReturnFalseWhenAValidFullHouseHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsThreeOfAKind(this.testValidFullHouseHand));
        }

        // IsFullHouse() tests
        [Test]
        public void IsFullHouseShouldReturnFalseWhenAnInvalidHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsFullHouse(this.testInvalidHandWithLessCards));
            Assert.IsFalse(this.handChecker.IsFullHouse(this.testInvalidHandWithMoreCards));
            Assert.IsFalse(this.handChecker.IsFullHouse(this.testInvalidHandWithSameCards));
        }

        [Test]
        public void IsFullHouseShouldReturnFalseWhenAValidThreeOfAKindHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsFullHouse(this.testValidThreeOfAKindHand));
        }

        [Test]
        public void IsFullHouseShouldReturnFalseWhenAValidHighCardHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsFullHouse(this.testValidHigCardHand));
        }

        [Test]
        public void IsFullHouseShouldReturnFalseWhenAValidOnePairHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsFullHouse(this.testValidHand));
        }

        [Test]
        public void IsFullHouseShouldReturnFalseWhenAValidFourOfAKindHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsFullHouse(this.testValidFourOfAKindHand));
        }

        [Test]
        public void IsFullHouseShouldReturnFalseWhenAValidTwoPairHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsFullHouse(this.testValidTwoPairHand));
        }

        [Test]
        public void IsFullHouseShouldReturnTrueWhenAValidFullHouseHandIsPassed()
        {
            Assert.IsTrue(this.handChecker.IsFullHouse(this.testValidFullHouseHand));
        }

        // IsStraight() tests
        [Test]
        public void IsStraightShouldReturnFalseWhenAnInvalidHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsStraight(this.testInvalidHandWithLessCards));
            Assert.IsFalse(this.handChecker.IsStraight(this.testInvalidHandWithMoreCards));
            Assert.IsFalse(this.handChecker.IsStraight(this.testInvalidHandWithSameCards));
        }

        [Test]
        public void IsStraightShouldReturnTrueWhenAValidStraightHandIsPassed()
        {
            Assert.IsTrue(this.handChecker.IsStraight(this.testValidStraightHand));
        }

        [Test]
        public void IsStraightShouldReturnTrueWhenAnA2345HandIsPassed()
        {
            Assert.IsTrue(this.handChecker.IsStraight(this.testA2345Straight));
        }

        [Test]
        public void IsStraightShouldReturnTrueWhenATJQKAHandIsPassed()
        {
            Assert.IsTrue(this.handChecker.IsStraight(this.testTJQKAStraight));
        }

        [Test]
        public void IsStraightShouldReturnFalseWhenAValidThreeOfAKindHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsStraight(this.testValidThreeOfAKindHand));
        }

        [Test]
        public void IsStraightShouldReturnFalseWhenAValidHighCardHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsStraight(this.testValidHigCardHand));
        }

        [Test]
        public void IsStraightShouldReturnFalseWhenAValidPairHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsStraight(this.testValidHand));
        }

        [Test]
        public void IsStraightShouldReturnFalseWhenAValidFlushHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsStraight(this.testValidFlushHand));
        }

        [Test]
        public void IsStraightShouldReturnFalseWhenAValidStraightFlushHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsStraight(this.testValidStraightFlushHand));
        }

        // IsStraightFlush() tests
        [Test]
        public void IsStraightFlushShouldReturnFalseWhenAnInvalidHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsStraightFlush(this.testInvalidHandWithLessCards));
            Assert.IsFalse(this.handChecker.IsStraightFlush(this.testInvalidHandWithMoreCards));
            Assert.IsFalse(this.handChecker.IsStraightFlush(this.testInvalidHandWithSameCards));
        }

        [Test]
        public void IsStraightFlushShouldReturnTrueWhenAValidStraightFlushHandIsPassed()
        {
            Assert.IsTrue(this.handChecker.IsStraightFlush(this.testValidStraightFlushHand));
        }

        [Test]
        public void IsStraightFlushShouldReturnTrueWhenAnA2345StraightFlushHandIsPassed()
        {
            Assert.IsTrue(this.handChecker.IsStraightFlush(this.testA2345StraightFlushHand));
        }

        [Test]
        public void IsStraightFlushShouldReturnFalseWhenAValidThreeOfAKindHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsStraightFlush(this.testValidThreeOfAKindHand));
        }

        [Test]
        public void IsStraightFlushShouldReturnFalseWhenAValidHighCardHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsStraightFlush(this.testValidHigCardHand));
        }

        [Test]
        public void IsStraightFlushShouldReturnFalseWhenAValidPairHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsStraightFlush(this.testValidHand));
        }

        [Test]
        public void IsStraightFlushShouldReturnFalseWhenAValidFlushHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsStraightFlush(this.testValidFlushHand));
        }

        [Test]
        public void IsStraightFlushShouldReturnFalseWhenANonflushStraightHandIsPassed()
        {
            Assert.IsFalse(this.handChecker.IsStraightFlush(this.testValidStraightHand));
        }
    }
}