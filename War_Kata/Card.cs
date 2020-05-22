using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace War_Kata
{
    public
    class Card
    {
        private
        string Suit { get; set; }
        string Card_Rank { get; set; }
        public Card(string New_Suit, string New_Card_Rank)
        {
            Suit = New_Suit;
            Card_Rank = New_Card_Rank;
            
        }

        public override string ToString()
        {
            return Card_Rank + " of " + Suit;
        }

        public int Get_Card_Rank()
        {
            int Value;
            if(Card_Rank == "J")
            {
                Value = 11;
            }
            else if(Card_Rank == "Q")
            {
                Value = 12;
            }
            else if(Card_Rank == "K")
            {
                Value = 13;
            }
            else if(Card_Rank == "A")
            {
                Value = 14;
            }
            else
            {
                Value = Convert.ToInt32(Card_Rank);
            }
            return Value;
        }
    }
}
