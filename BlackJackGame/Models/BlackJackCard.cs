using System;

namespace BlackJackGame.Models
{
    public class BlackJackCard : Card
    {
        #region Properties
        public bool FaceUp { get; private set; }
        public int Value
        {
            get
            {
                return FaceUp ? Math.Min(10, (int)FaceValue) : 0;
            }
        }
        #endregion

        #region Methods
        public BlackJackCard(Suit suit, FaceValue faceValue) : base(suit, faceValue)
        {
            FaceUp = false;
        }

        public void TurnCard()
        {
            FaceUp = !FaceUp;
        }
        #endregion
    }
}
