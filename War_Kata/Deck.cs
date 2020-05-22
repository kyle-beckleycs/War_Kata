using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;

namespace War_Kata
{
    public
    class Deck
    {
        private Queue<Card> Game_Deck = new Queue<Card>();
        public Deck() 
        {
            //populates Deck with cards in order
            string[] Face_Values = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

            foreach(string s in Face_Values)
            {
                Game_Deck.Enqueue(new Card("Hearts", s));
            }

            foreach (string s in Face_Values)
            {
                Game_Deck.Enqueue(new Card("Spades", s));
            }

            foreach (string s in Face_Values)
            {
                Game_Deck.Enqueue(new Card("Clubs", s));
            }

            foreach (string s in Face_Values)
            {
                Game_Deck.Enqueue(new Card("Diamonds", s));
            }

        }

        public int IsEmpty()
        {
            return Game_Deck.Count;
        }

        public Card Draw_Card()
        {
            return Game_Deck.Dequeue();
        }

        public void Shuffle_Deck()
        {
            Card[] New_Deck = new Card[52];   // New Deck to insert Shuffled Values
            int i = 0;
            while(Game_Deck.Count != 0)      // read items into temp deck
            {
                New_Deck[i] = Game_Deck.Dequeue();
                i++;
            }

            for(int j = New_Deck.Length - 1; j > 0; j--)        // shuffle using Knuth-Fisher-Yates shuffle algorithm
            {
                Random k = new Random();
                int n = k.Next(j + 1);
                Card temp = New_Deck[j];
                New_Deck[j] = New_Deck[n];
                New_Deck[n] = temp;

            }

            Game_Deck.Clear();                                  //clear existing in order deck

            foreach(Card C in New_Deck)                         //insert shuffled cards into new deck
            {
                Game_Deck.Enqueue(C);
            }

        }

        public List<Card> Print_Deck()
        {
            List<Card> Deck_List = new List<Card>();
            foreach(Card C in Game_Deck)
            {
                Console.WriteLine( C.ToString());
                Deck_List.Add(C);
            }
            return Deck_List;
        }

    }
}
