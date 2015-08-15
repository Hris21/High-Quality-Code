namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        private int MaxNumberOfSameCards(IHand hand)
        {
            int result = 1;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                ICard typeOfCardToCheck = hand.Cards[i];
                int numberOfSuchCardsInTheHand = hand.Cards.Where(x => x.Face == typeOfCardToCheck.Face).Count();
                if (numberOfSuchCardsInTheHand > result)
                {
                    result = numberOfSuchCardsInTheHand;
                }
            }

            return result;
        }

        private string DeterminePairTwoPairOrFullHouseIfPairInTheHand(IHand hand)
        {
            List<ICard> theOtherCards = new List<ICard>();
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                ICard typeOfCardToCheck = hand.Cards[i];
                int numberOfSuchCardsInTheHand = hand.Cards.Where(x => x.Face == typeOfCardToCheck.Face).Count();
                if (numberOfSuchCardsInTheHand == 2)
                {
                    theOtherCards = hand.Cards.Where(x => x.Face != typeOfCardToCheck.Face).ToList();
                    break;
                }
            }

            int maxNumberOfSameCards = 1;

            for (int i = 0; i < theOtherCards.Count; i++)
            {
                ICard typeOfCardToCheck = theOtherCards[i];
                int numberOfSuchCardsInTheOtherCards = theOtherCards.Where(x => x.Face == typeOfCardToCheck.Face).Count();

                if (numberOfSuchCardsInTheOtherCards > maxNumberOfSameCards)
                    maxNumberOfSameCards = numberOfSuchCardsInTheOtherCards;
            }

            return maxNumberOfSameCards == 1 ? "pair" : maxNumberOfSameCards == 2 ? "two pair" : "full house";
        }

        public bool IsValidHand(IHand hand)
        {
            if (hand == null)
            {
                return false;
            }

            if (hand.Cards.Count != 5)
            {
                return false;
            }

            byte initialCardsCount = 5;

            for (int i = 0; i < initialCardsCount; i++)
            {
                if (hand.ToString().IndexOf(hand.Cards[i].ToString()) != hand.ToString().LastIndexOf(hand.Cards[i].ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            if (this.MaxNumberOfSameCards(hand) != 1)
            {
                return false;
            }

            CardSuit firstCardSuit = hand.Cards[0].Suit;

            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if (hand.Cards[i].Suit != firstCardSuit)
                {
                    return false;
                }
            }

            var cards = hand.Cards.ToList();
            cards.Sort((x, y) => (int)x.Face - (int)y.Face);

            if ((int)cards[0].Face == 2 && (int)cards[1].Face == 3 && (int)cards[2].Face == 4 && (int)cards[3].Face == 5 && (int)cards[4].Face == 14)
            {
                return true;
            }

            for (int i = 1; i < cards.Count; i++)
            {
                if ((int)cards[i].Face != (int)cards[i - 1].Face + 1)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (this.MaxNumberOfSameCards(hand) == 4)
            {
                return true;
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (MaxNumberOfSameCards(hand) != 3)
            {
                return false;
            }

            return this.DeterminePairTwoPairOrFullHouseIfPairInTheHand(hand) == "full house";
        }

        public bool IsFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            CardSuit firstCardSuit = hand.Cards[0].Suit;

            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if (hand.Cards[i].Suit != firstCardSuit)
                {
                    return false;
                }
            }

            if (this.IsStraightFlush(hand))
            {
                return false;
            }

            return true;
        }

        public bool IsStraight(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            if (this.MaxNumberOfSameCards(hand) != 1)
            {
                return false;
            }

            if (this.IsFlush(hand))
            {
                return false;
            }

            if (this.IsStraightFlush(hand))
            {
                return false;
            }

            var cards = hand.Cards.ToList();
            cards.Sort((x, y) => (int)x.Face - (int)y.Face);

            if ((int)cards[0].Face == 2 && (int)cards[1].Face == 3 && (int)cards[2].Face == 4 && (int)cards[3].Face == 5 && (int)cards[4].Face == 14)
            {
                return true;
            }

            for (int i = 1; i < cards.Count; i++)
            {
                if ((int)cards[i].Face != (int)cards[i - 1].Face + 1)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (MaxNumberOfSameCards(hand) != 3)
            {
                return false;
            }

            List<ICard> remainingCards = new List<ICard>();
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                ICard currentCard = hand.Cards[i];
                int numberOfSameCards = hand.Cards.Where(x => x.Face == currentCard.Face).Count();
                if (numberOfSameCards == 3)
                {
                    remainingCards = hand.Cards.Where(x => x.Face != currentCard.Face).ToList();
                    break;
                }
            }

            return remainingCards[0].Face != remainingCards[1].Face;
        }

        public bool IsTwoPair(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (MaxNumberOfSameCards(hand) != 2)
            {
                return false;
            }

            return this.DeterminePairTwoPairOrFullHouseIfPairInTheHand(hand) == "two pair";
        }

        public bool IsOnePair(IHand hand)
        {
            if (!IsValidHand(hand))
            {
                return false;
            }

            if (MaxNumberOfSameCards(hand) != 2)
            {
                return false;
            }

            return this.DeterminePairTwoPairOrFullHouseIfPairInTheHand(hand) == "pair";
        }

        public bool IsHighCard(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            if (this.IsFlush(hand))
            {
                return false;
            }

            if (this.IsStraight(hand) || this.IsStraightFlush(hand))
            {
                return false;
            }

            if (this.MaxNumberOfSameCards(hand) == 1)
            {
                return true;
            }

            return false;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}