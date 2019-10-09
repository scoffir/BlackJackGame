using BlackJackGame.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BlackJackGame.Tests.Models
{
    public class DeckTest
    {
        private readonly Deck _deck;
        public DeckTest()
        {
            _deck = new Deck();
        }
        [Fact]
        public void Draw_ReturnsBlackJackCard()
        {
            Assert.IsType<BlackJackCard>(_deck.Draw());
        }


    }
}
