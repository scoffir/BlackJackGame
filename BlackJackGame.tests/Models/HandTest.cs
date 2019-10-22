using BlackJackGame.Models;
using Xunit;

namespace BlackJackGame.Tests.Models
{

    public class HandTest
    {
        private Hand _aHand;

        public HandTest()
        {
            _aHand = new Hand();
        }

        [Fact]
        public void NewHand_HasNoCards()
        {
            Assert.Equal(0, _aHand.NrOfCards);
        }

        [Fact]
        public void AddCard_EmptyHand_ResultsInHandWithOneCard()
        {
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Ace));
            Assert.Equal(1, _aHand.NrOfCards);
        }

        [Fact]
        public void AddCard_AHandWithCards_AddsACard()
        {
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Ace));
            _aHand.AddCard(new BlackJackCard(Suit.Diamonds, FaceValue.Ace));
            Assert.Equal(2, _aHand.NrOfCards);
        }

        [Fact]
        public void TurnAllCardsFaceUp_TurnsAllCardsFaceUp()
        {
            BlackJackCard card = new BlackJackCard(Suit.Hearts, FaceValue.Ace);
            card.TurnCard();
            _aHand.AddCard(card);
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Two));
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Two));
            _aHand.TurnAllCardsFaceUp();
            foreach (BlackJackCard c in _aHand.Cards)
                Assert.True(c.FaceUp);
        }

        [Fact]
        public void Value_EmptyHand_IsZero()
        {
            Assert.Equal(0, _aHand.Value);
        }

        [Fact]
        public void Value_HandWith6and5_Is11()
        {
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Five));
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Six));
            _aHand.TurnAllCardsFaceUp();
            Assert.Equal(11, _aHand.Value);
        }

        [Fact]
        public void Value_HandWith5AndKing_Is15()
        {
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Five));
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.King));
            _aHand.TurnAllCardsFaceUp();
            Assert.Equal(15, _aHand.Value);
        }

        [Fact]
        public void Value_HandWithCardsFacingDown_DoesNotAddValuesOfCardsFacingDown()
        {
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Five));
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Six));
            Assert.Equal(0, _aHand.Value);
        }

        [Fact]
        public void Value_HandWithAceAndNotExceeding21_TakesAceAs11()
        {
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Ace));
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.King));
            _aHand.TurnAllCardsFaceUp();
            Assert.Equal(21, _aHand.Value);
        }

        [Fact]
        public void ValueHandWithAceAndExceeding21_TakesAceAs1()
        {

            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.King));
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.King));
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Ace));
            _aHand.TurnAllCardsFaceUp();
            Assert.Equal(21, _aHand.Value);
        }

        [Fact]
        public void Value_HandWithAceFaceDown_DoesNotCountAce()
        {
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Two));
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Two));
            _aHand.TurnAllCardsFaceUp();
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Ace));
            Assert.Equal(4, _aHand.Value);
        }
    }
}
