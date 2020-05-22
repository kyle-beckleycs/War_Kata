using System;
using System.Collections.Generic;
using System.Text;

namespace War_Kata
{
    public
    class War_Game
    {
        private
        Player PlayerOne = new Player();
        Player PlayerTwo = new Player();

        Deck Game_Deck;

        public War_Game()
        {

        }

        public string Play_Game(Deck New_Deck)                              //If New_Deck is null game will create a deck and shuffle, if not Game will be played as is with provided deck
        {
            if(New_Deck == null)
            {
                Game_Deck = new Deck();
                //Game_Deck.Print_Deck();
                Console.WriteLine("Players will now shuffle the deck\n");
                Game_Deck.Shuffle_Deck();
                //Game_Deck.Print_Deck();
                Console.WriteLine("The deck has been shuffled");
            }
            else
            {
                Game_Deck = New_Deck;
            }
            

            if(Game_Deck.IsEmpty() != 0)
            {
                while (Game_Deck.IsEmpty() != 0)        //Players take turns adding cards from Game_Deck into individual hands
                {
                    PlayerOne.Draw_Card(Game_Deck);
                    PlayerTwo.Draw_Card(Game_Deck);

                }

                if(PlayerOne.Cards_In_Deck() == PlayerTwo.Cards_In_Deck())
                {
                    Play_War();

                    Console.WriteLine("GAME OVER");
                    //Determine which player won
                    if(PlayerOne.Cards_In_Deck() == 0 && PlayerTwo.Cards_In_Deck() == 0)
                    {
                        Console.WriteLine("Both players have run out of cards\nThe game is a tie!!!");
                        return "The game is a tie!!!";
                    }
                    if (PlayerOne.Cards_In_Deck() == 0)
                    {
                        Console.WriteLine("Player Two Wins!!!");
                        return "Player Two Wins!!!";
                    }
                    else
                    {
                        Console.WriteLine("Player One Wins!!!");
                        return "Player One Wins!!!";
                    }
                }
                else
                {
                    return "Players must have an even sized deck for a fair game.\n Try a new Deck";

                }
            }
            else
            {
                return "You cannot play a game with an Empty Deck\n";
            }
        }

        private void Play_War()
        {
            while ((PlayerOne.Cards_In_Deck() != 0) && (PlayerTwo.Cards_In_Deck() != 0))
            {
                Console.WriteLine("Player One Plays a " + PlayerOne.Play_Card().ToString());
                Console.WriteLine("Player Two Plays a " + PlayerTwo.Play_Card().ToString());
                if (PlayerOne.Play_Card().Get_Card_Rank() == PlayerTwo.Play_Card().Get_Card_Rank())     //Play_Card returns peeked card, Moves peeked card to players hand
                {
                    
                    Console.WriteLine("LET THERE BE WAR!");
                    PlayerOne.Ready_War();
                    PlayerTwo.Ready_War();

                    if (PlayerOne.Cards_In_Deck() != 0 && PlayerTwo.Cards_In_Deck() != 0)
                    {
                        int Current_Card = 1;
                        if (PlayerOne.Play_Hand(Current_Card).Get_Card_Rank() == PlayerTwo.Play_Hand(Current_Card).Get_Card_Rank())
                        {
                            do
                            {
                                Current_Card++;
                                PlayerOne.Continue_War();
                                PlayerTwo.Continue_War();
                                Console.WriteLine("Player One Plays a " + PlayerOne.Play_Hand(Current_Card).ToString());
                                Console.WriteLine("Player Two Plays a " + PlayerTwo.Play_Hand(Current_Card).ToString());
                            }
                            while ((PlayerOne.Play_Hand(Current_Card).Get_Card_Rank() == PlayerTwo.Play_Hand(Current_Card).Get_Card_Rank()) && (PlayerOne.Cards_In_Deck() != 0 && PlayerTwo.Cards_In_Deck() != 0));

                            if (PlayerOne.Play_Hand(Current_Card).Get_Card_Rank() > PlayerTwo.Play_Hand(Current_Card).Get_Card_Rank())
                            {
                                Console.WriteLine("Player One wins the war with: " + PlayerOne.Play_Hand(Current_Card).ToString());
                                PlayerOne.Take_Cards(PlayerTwo.Give_Cards(PlayerTwo.Cards_In_Hand()));

                            }
                            else
                            {
                                Console.WriteLine("Player Two wins the war with: " + PlayerOne.Play_Hand(Current_Card).ToString());
                                PlayerTwo.Take_Cards(PlayerOne.Give_Cards(PlayerOne.Cards_In_Hand()));
                            }

                        }
                    }
                }
                else if (PlayerOne.Play_Card().Get_Card_Rank() > PlayerTwo.Play_Card().Get_Card_Rank())  //card played goes to winners hand.
                {
                    Console.WriteLine("Player One wins the fight with: " + PlayerOne.Play_Card().ToString());
                    PlayerOne.Take_Cards(PlayerOne.Give_Cards(1));
                    PlayerOne.Take_Cards(PlayerTwo.Give_Cards(1));
                }
                else
                {
                    Console.WriteLine("Player Two wins the fight with: " + PlayerTwo.Play_Card().ToString());
                    PlayerTwo.Take_Cards(PlayerTwo.Give_Cards(1));                                              
                    PlayerTwo.Take_Cards(PlayerOne.Give_Cards(1));
                }
            }
        }
    }
}
