using System;
using System.Collections.Generic;
using System.Text;


namespace War_Kata
{
    class Player
    {
        private Queue<Card> Player_Deck = new Queue<Card>();                    //Unknown deck of face down cards
        private List<Card>  Player_Hand = new List<Card>();                     //list of cards currently in play

        public Player()
        {

        }

        public void Draw_Card(Deck Game_Deck)
        {
            if(Game_Deck.IsEmpty() != 0)
            {
                Player_Deck.Enqueue(Game_Deck.Draw_Card());
            }
            
        }

        public Card Play_Card()                 
        {
            Card Drawn_Card = Player_Deck.Peek();
            
            return Drawn_Card;
        }

        public int Cards_In_Deck()
        {
            return Player_Deck.Count;
        }

        public int Cards_In_Hand()
        {
            return Player_Hand.Count;
        }

        public Queue<Card> Give_Cards(int cards_played)
        {
            Queue<Card> Cards_To_Give = new Queue<Card>();

            while(cards_played != 0)
            {
                Cards_To_Give.Enqueue(Player_Deck.Dequeue());
                cards_played--;
            }

            return Cards_To_Give;
        }

        public void Take_Cards(Queue<Card> Hand)
        {
            while(Hand.Count != 0) 
            {
                Player_Deck.Enqueue(Hand.Dequeue());
            }
        }

        public void Ready_War()             //Dequeues two more cards and moves to players hand for a total of three cards
        {
            if (Player_Deck.Count >= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    Player_Hand.Add(Player_Deck.Dequeue());
                }
            }
            else
            {
                while(Player_Deck.Count != 0)
                {
                    Player_Hand.Add(Player_Deck.Dequeue());
                }
            }
        }

        public void Continue_War()
        {
            if (Player_Deck.Count >= 1)
            {
                Player_Hand.Add(Player_Deck.Dequeue());
            }
        }

        public Card Play_Hand(int index)
        {
            return Player_Hand[index];
        }
    }
}
