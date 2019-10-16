using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackGame.Models
{
    public class Deck
    {
        #region Fields
        private Random _random;
        protected IList<BlackJackCard> _cards;
        #endregion

        #region Methods
        public Deck()
        {
            _cards = new List<BlackJackCard>();
            foreach (var faceValue in Enum.GetValues(typeof(FaceValue)))
                foreach (var suit in Enum.GetValues(typeof(Suit)))
                    _cards.Add(new BlackJackCard((Suit)suit, (FaceValue)faceValue));
        }

        public BlackJackCard Draw()
        {
            if (_cards == null || _cards.Count == 0)
                throw new InvalidOperationException("Cannot draw from an empty deck");
            BlackJackCard theCard = _cards[0];
            _cards.RemoveAt(0);
            return theCard;
        }

        private void Shuffle()
        {
            int n = _cards.Count;
            while (n > 1)
            {
                n--;
                int k = _random.Next(n + 1);
                BlackJackCard value = _cards[k];
                _cards[k] = _cards[n];
                _cards[n] = value;
            }
        }
        #endregion
    }
}
