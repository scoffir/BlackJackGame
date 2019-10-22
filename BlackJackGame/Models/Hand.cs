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
        public IEnumerable<BlackJackCard> Cards { get
            {
                return _cards;
                    } 
        }
        public int NrOfCards { get
            {
                return _cards.Count;
            }
        }
        public int Value
        {
            get
            {
                return CalculateValue();
            }
        }
        #endregion

        #region Methods
        public Hand()
        {
            _cards = new List<BlackJackCard>();
            CalculateValue();
        }

        public void AddCard(BlackJackCard blackJackCard)
        {
            _cards.Add(blackJackCard);
            CalculateValue();
        }

        private int CalculateValue()
        {
            int value = 0;
            foreach (BlackJackCard blackJackCard in Cards)
            {
                if (blackJackCard.FaceUp)
                {
                    if (blackJackCard.Value == 1 && value <= 10)
                    {
                        value += 11;
                    }
                    else
                    {
                        value += blackJackCard.Value;
                    }
                }

                
            }
            return value;
        }

        public void TurnAllCardsFaceUp()
        {
            foreach(var blackJackCard in Cards)
            {
                if(!blackJackCard.FaceUp)
                blackJackCard.TurnCard();
            }
        }
        #endregion
    }
}
