using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace GameWords.classes
{
    class Discovered
    {
        private string _letter;
        private static bool[] _discovered = new bool[5];
        public static string Word { get; private set; }
        

        public Discovered (string letter)
        {
            _letter = letter;
        }

      
        #region Discovere_Letter
        public void Discovere_Letter(Canvas canvas, TextBlock[] textBlocks, Image[] images)
        {
            Word_Choice();
            Placing_letters_and_pictures(canvas, textBlocks, images);
            Placing_Words_In_Text_Black(textBlocks);
        }
        #endregion



        #region Word_Choice
        private void Word_Choice()
        {
            if (System_Game.Sign_Start == true)
            {
                System_Game.Sign_For_Num_Word = false;
                System_Game.Sign_Start = false;
            }
            if (System_Game.Hard_Game == true && System_Game.Sign_For_Num_Word == false) Word = Words.Hard_Words();
            else if (System_Game.Hard_Game == false && System_Game.Sign_For_Num_Word == false) Word = Words.Easy_Words();
            System_Game.Sign_For_Num_Word = true;
        }
        #endregion

        #region Placing_letters_and_pictures
        private void Placing_letters_and_pictures(Canvas canvas, TextBlock[] textBlocks, Image[] images)
        {
            int locationNumber = -1;
            foreach (char letter in Word)
            {
                locationNumber++;
                if (letter.ToString() == _letter)
                {
                    textBlocks[locationNumber].Text = _letter;
                    _discovered[locationNumber] = true;
                    System_Game.Sign_Right = true;
                }
            }
            System_Game.Remov_Image(canvas, images);
            System_Game.Sign_Right = false;
        }
        #endregion

        #region Placing_Words_In_Text_Black
        private void Placing_Words_In_Text_Black(TextBlock[] textBlocks)
        {
            if (System_Game.Hard_Game == false)
            {
                for (int location1 = 0; location1 < 3; location1++)
                {
                    if (_discovered[location1] == false) break;
                    else if (location1 == 2)
                    {
                        System_Game.Sign_For_Num_Word = false;
                        System_Game.Placement_letters(textBlocks);
                        for (int location2 = 0; location2 < _discovered.Length; location2++)
                        {
                            _discovered[location2] = false;
                        }
                    }
                }
            }
            else
            {
                for (int location1 = 0; location1 < 5; location1++)
                {
                    if (_discovered[location1] == false) break;
                    if (location1 == 4)
                    {
                        System_Game.Sign_For_Num_Word = false;
                        System_Game.Placement_letters(textBlocks);
                        for (int location2 = 0; location2 < _discovered.Length; location2++)
                        {
                            _discovered[location2] = false;
                        }
                    }
                }
            }
        } 
        #endregion
    }
}
