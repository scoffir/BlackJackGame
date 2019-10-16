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

        [Fact]
        public void NewDeck_Created52Cards()
        {
            
            int count = 0;
            while(_deck.Draw() != null)
            {
                Assert.False(_deck.Draw().FaceUp);
                count++;
            }
            Assert.Equal(52, count);
        }

        [Fact]
        public void Draw_DrawsFromEmptyStack_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => _deck.Draw());
        }
    }
}
