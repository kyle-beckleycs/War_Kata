using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using War_Kata;

namespace War_Tests
{
    [TestClass]
    public class War_Tests
    {


        public War_Tests()
        {

        }

        [TestMethod]
        public void Start_Empty_Deck()
        {
            War_Game Game = new War_Game();
            Deck Game_Deck = new Deck();
            while(Game_Deck.IsEmpty() != 0)
            {
                _ = Game_Deck.Draw_Card();
            }

            Assert.AreEqual("You cannot play a game with an Empty Deck\n", Game.Play_Game(Game_Deck));
        }

        [TestMethod]
        public void One_Card_Deck()
        {
            War_Game Game = new War_Game();
            Deck Game_Deck = new Deck();
            while (Game_Deck.IsEmpty() != 1)
            {
                _ = Game_Deck.Draw_Card();
            }

            Assert.AreEqual("Players must have an even sized deck for a fair game.\n Try a new Deck", Game.Play_Game(Game_Deck));
        }

        [TestMethod]                                
        public void Two_Cards_First_Greater()
        {
            War_Game Game = new War_Game();
            Deck Game_Deck = new Deck();
            List<Card> Deck_List;
            Card A;
            Card B;
            do
            {
                Game_Deck.Shuffle_Deck();
                Deck_List = Game_Deck.Print_Deck();
                A = Deck_List[50];
                B = Deck_List[51];
            }
            while (A.Get_Card_Rank() <= B.Get_Card_Rank());

            while (Game_Deck.IsEmpty() != 2)
            {
                _ = Game_Deck.Draw_Card();
            }

            Assert.AreEqual("Player One Wins!!!", Game.Play_Game(Game_Deck));
        }

        [TestMethod]
        public void Two_Cards_Second_Greater()      
        {
            War_Game Game = new War_Game();
            Deck Game_Deck = new Deck();
            List<Card> Deck_List;
            Card A;
            Card B;
            do
            {
                Game_Deck.Shuffle_Deck();
                Deck_List = Game_Deck.Print_Deck();
                A = Deck_List[50];
                B = Deck_List[51];
            }
            while (A.Get_Card_Rank() >= B.Get_Card_Rank());

            while (Game_Deck.IsEmpty() != 2)
            {
                _ = Game_Deck.Draw_Card();
            }

            Assert.AreEqual("Player Two Wins!!!", Game.Play_Game(Game_Deck));
        }

        [TestMethod]
        public void Two_Cards_Equal()
        {
            War_Game Game = new War_Game();
            Deck Game_Deck = new Deck();
            List<Card> Deck_List;
            Card A;
            Card B;
            do
            {
                Game_Deck.Shuffle_Deck();
                Deck_List = Game_Deck.Print_Deck();
                A = Deck_List[50];
                B = Deck_List[51];
            }
            while (A.Get_Card_Rank() != B.Get_Card_Rank());

            while (Game_Deck.IsEmpty() != 2)
            {
                _ = Game_Deck.Draw_Card();
            }

            Assert.AreEqual("The game is a tie!!!", Game.Play_Game(Game_Deck));
        }


        [TestMethod]
        public void War_Ends_In_Draw()
        {
            War_Game Game = new War_Game();
            Deck Game_Deck = new Deck();
            List<Card> Deck_List;
            Card A;
            Card B;
            Card C;
            Card D;
            do
            {
                Game_Deck.Shuffle_Deck();
                Deck_List = Game_Deck.Print_Deck();
                A = Deck_List[48];
                B = Deck_List[49];
                C = Deck_List[50];
                D = Deck_List[51];

            }
            while ((A.Get_Card_Rank() != B.Get_Card_Rank()) && (C.Get_Card_Rank() != D.Get_Card_Rank()));

            while (Game_Deck.IsEmpty() != 4)
            {
                _ = Game_Deck.Draw_Card();
            }

            Assert.AreEqual("The game is a tie!!!", Game.Play_Game(Game_Deck));
        }

    }
}
