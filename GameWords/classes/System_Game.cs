using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace GameWords.classes
{
    static class System_Game
    {
        private static int _num_Word;
        private static int _num_Image;

        public static bool Hard_Game { get; set; }
        public static bool Sign_New_Word { get; set; }
        public static bool Sign_Start { get; set; }
        public static bool Sign_Start_To_Placement_letters { get; set; }
        public static bool Sign_Game_Over { get; set; }
        public static bool Sign_Right { get; set; }
        public static bool Sign_For_Num_Word { get; set; }
        public static bool Victory { get; set; }
        public static bool Loss { get; set; }      
        public static Image New_Image { get; set; }



        #region Placement_letters
        public static void Placement_letters(TextBlock[] textBlocks)
        {
            if (Sign_Start_To_Placement_letters == true) _num_Word = 0;
            Sign_Start_To_Placement_letters = false;
            _num_Word++;
            if (System_Game.Hard_Game == false) for (int i = 0; i < 3; i++) textBlocks[i].Text = "?";
            else for(int i = 0; i < 5; i++) textBlocks[i].Text = "?";
            if (_num_Word == 1) textBlocks[5].Text = Discovered.Word;
            else if (_num_Word == 2) textBlocks[6].Text = Discovered.Word;
            else if (_num_Word == 3)
            {
                Victory = true;
                textBlocks[7].Text = Discovered.Word;
            }
        }
        #endregion

        #region Remov_Image
        public static void Remov_Image(Canvas canvas, Image[] images)
        {
            if (Sign_Right == false)
            {
                if (Sign_Game_Over == true)
                {
                    _num_Image = 0;
                    Sign_Game_Over = false;
                }
                images[_num_Image].Width = 0; images[_num_Image].Height = 0;
                _num_Image++;
                if (_num_Image == images.Length - 1)
                {
                    _num_Image = 0;
                    Loss = true;
                }
            }
        } 
        #endregion

    }
}
