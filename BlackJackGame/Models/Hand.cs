using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackGame.Models
{
    public class Hand
    {
        #region Fields
        private IList<BlackJackCard> _cards;
        #endregion

        #region Properties
        public IEnumerable<BlackJackCard> Cards { get; }
        public int NrOfCards { get; }
        public int Value { get; }
        #endregion

        #region Methods
        public Hand()
        {
            _cards = new List<BlackJackCard>();
            NrOfCards = _cards.Count;
        }

        public void AddCard(BlackJackCard blackJackCard)
        {
            _cards.Add(blackJackCard);
        }

        private int CalculateValue()
        {
            throw new NotImplementedException();
        }

        public void TurnAllCardsFaceUp()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
