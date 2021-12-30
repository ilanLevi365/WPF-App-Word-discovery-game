using GameWords.classes;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;


namespace GameWords
{
    public sealed partial class MainPage : Page
    {
        private Canvas _canvas_game_words;
        private TextBlock[] _textBlocks;
        private Button[] _buttons;
        private Image[] _images;
        private DispatcherTimer _timer;
        private Image _new_Image;
        private bool _sign_Music;
        private bool _sign_Screaming_Sound;


        public MainPage()
        {
            this.InitializeComponent();
            _canvas_game_words = Canvas_Game_Words;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(10);
            _timer.Tick += timer_Tick;
            _timer.Start();
            _textBlocks = new TextBlock[8];
            _buttons = new Button[26];
            _images = new Image[11];
            _new_Image = new Image();
            Text_Blokc_Words_Set();
            Buttons_Set();
            Image_Set();
            foreach (var item in _buttons) _canvas_game_words.Children.Remove(item);     
        }

        #region timer_Tick
        private void timer_Tick(object sender, object e)
        {
            if (_sign_Music == true)
                Music_Playing.Play();

            if (System_Game.Sign_For_Num_Word == false)
                foreach (Button item in _buttons)
                    item.IsEnabled = true;
            Game_Over();
        }
        #endregion

        #region Btn_Easy_Click
        private void Btn_Easy_Click(object sender, RoutedEventArgs e)
        {
            System_Game.Hard_Game = false;
            Screen_Arrangement();
        }
        #endregion

        #region Btn_Hard_Click
        private void Btn_Hard_Click(object sender, RoutedEventArgs e)
        {
            System_Game.Hard_Game = true;
            Screen_Arrangement();
        }
        #endregion

        #region Screen_Arrangement
        private void Screen_Arrangement()
        {
            txtBl_Choice_Difficulty.Width = 0; txtBl_Choice_Difficulty.Height = 0;
            txtBl_Sing.Width = 0; txtBl_Sing.Height = 0;
            _sign_Music = true;
            Instructions_Music.Stop();
            texBl_Instructions.Text = "";
            System_Game.Sign_Start = true;
            foreach (Button item in _buttons)
            {
                _canvas_game_words.Children.Add(item);
                item.IsEnabled = true;
            }
            foreach (var item in _images)
            {
                item.Width = 322; item.Height = 425;
            }
            Btn_New_Word.Height = 103; Btn_New_Word.Width = 170;
            _canvas_game_words.Children.Remove(Btn_Hard);
            _canvas_game_words.Children.Remove(Btn_Easy);
           
            if (System_Game.Hard_Game == true)
            {
                Canvas.SetLeft(TxtBl_1, 420);
                Canvas.SetLeft(TxtBl_2, 520);
                Canvas.SetLeft(TxtBl_3, 620);
                TxtBl_1.Text = "?";
                TxtBl_2.Text = "?";
                TxtBl_3.Text = "?";
                TxtBl_4.Text = "?";
                TxtBl_5.Text = "?";
            }
            else
            {
                Canvas.SetLeft(TxtBl_1, 520);
                Canvas.SetLeft(TxtBl_2, 620);
                Canvas.SetLeft(TxtBl_3, 720);
                TxtBl_1.Text = "?";
                TxtBl_2.Text = "?";
                TxtBl_3.Text = "?";
            }
        }
        #endregion

        #region Text_Blokc_Words_Set
        private void Text_Blokc_Words_Set()
        {
            _textBlocks[0] = TxtBl_1;
            _textBlocks[1] = TxtBl_2;
            _textBlocks[2] = TxtBl_3;
            _textBlocks[3] = TxtBl_4;
            _textBlocks[4] = TxtBl_5;
            _textBlocks[5] = TxtBl_Word1;
            _textBlocks[6] = TxtBl_Word2;
            _textBlocks[7] = TxtBl_Word3;
        } 
        #endregion

        #region Buttons_Letters_Set
        private void Buttons_Set()
        {
            _buttons[0] = Btn_A; _buttons[1] = Btn_B; _buttons[2] = Btn_C;
            _buttons[3] = Btn_D; _buttons[4] = Btn_E; _buttons[5] = Btn_F;
            _buttons[6] = Btn_G; _buttons[7] = Btn_H; _buttons[8] = Btn_I;
            _buttons[9] = Btn_J; _buttons[10] = Btn_K; _buttons[11] = Btn_L;
            _buttons[12] = Btn_M; _buttons[13] = Btn_N; _buttons[14] = Btn_O;
            _buttons[15] = Btn_P; _buttons[16] = Btn_Q; _buttons[17] = Btn_R;
            _buttons[18] = Btn_S; _buttons[19] = Btn_T; _buttons[20] = Btn_U;
            _buttons[21] = Btn_V; _buttons[22] = Btn_W; _buttons[23] = Btn_X;
            _buttons[24] = Btn_Y; _buttons[25] = Btn_Z;
        } 
        #endregion

        #region Images_Set
        private void Image_Set()
        {
            _images[0] = Img_Hang_0_jpg;
            _images[1] = Img_Hang_1_jpg;
            _images[2] = Img_Hang_2_jpg;
            _images[3] = Img_Hang_3_jpg;
            _images[4] = Img_Hang_4_jpg;
            _images[5] = Img_Hang_5_jpg;
            _images[6] = Img_Hang_6_jpg;
            _images[7] = Img_Hang_7_jpg;
            _images[8] = Img_Hang_8_jpg;
            _images[9] = Img_Hang_9_jpg;
            _images[10] = Img_Hang_10_jpg;
        } 
        #endregion

        #region Btn_New_Word_Click
        private void Btn_New_Word_Click(object sender, RoutedEventArgs e)
        {
            System_Game.Sign_For_Num_Word = false;
            if (System_Game.Hard_Game == true)
            {
                TxtBl_1.Text = "?";
                TxtBl_2.Text = "?";
                TxtBl_3.Text = "?";
                TxtBl_4.Text = "?";
                TxtBl_5.Text = "?";
            }
            else
            {
                TxtBl_1.Text = "?";
                TxtBl_2.Text = "?";
                TxtBl_3.Text = "?";
            }
        }
        #endregion

        #region Btn_Exit_Click
        private void Btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
        #endregion

        #region Btn_Start_Click
        private void Btn_Start_Click(object sender, RoutedEventArgs e)
        {
            txtBl_Choice_Difficulty.Width = 322; txtBl_Choice_Difficulty.Height = 425;
            txtBl_Sing.Width = 100; txtBl_Sing.Height = 100;
            System_Game.Sign_Start_To_Placement_letters = true;
            _sign_Screaming_Sound = false;
            foreach (var item in _images)
            {
                item.Width = 0; item.Height = 0;
            }
            Btn_Start.Width = 0; Btn_Start.Height = 0;
            if (System_Game.Loss == true)
            {
                txtBl_Game_Over.Width = 0; txtBl_Game_Over.Height = 0;
                System_Game.Loss = false;
            }
            else _canvas_game_words.Children.Remove(_new_Image);
            _canvas_game_words.Children.Add(Btn_Hard);
            _canvas_game_words.Children.Add(Btn_Easy);
            for (int i = 0; i < 8; i++) _textBlocks[i].Text = "";
        }
        #endregion

        #region Game_Over
        private void Game_Over()
        {
            if (System_Game.Victory == true || System_Game.Loss == true)
            {
                Btn_New_Word.Height = 0; Btn_New_Word.Width = 0;
                System_Game.Sign_Game_Over = true;
                if (System_Game.Victory == true)
                {
                    _new_Image.Source = new BitmapImage(new Uri($"ms-appx:///Assets/Img_Victory_Cup.jpeg"));
                    _new_Image.Width = 300; _new_Image.Height = 400;
                    Canvas.SetLeft(_new_Image, 565); Canvas.SetTop(_new_Image, 70);
                    _canvas_game_words.Children.Add(_new_Image);
                    System_Game.Victory = false;
                }
                else
                {
                    if (_sign_Screaming_Sound == false) Screaming_Sound.Play();
                    _sign_Screaming_Sound = true;
                    txtBl_Game_Over.Width = 329; txtBl_Game_Over.Height = 329;
                }
                Btn_Start.Width = 100; Btn_Start.Height = 70;
                foreach (Button item in _buttons) _canvas_game_words.Children.Remove(item);
                _canvas_game_words.Children.Remove(Btn_Hard);
                _canvas_game_words.Children.Remove(Btn_Easy);
                for (int i = 0; i < 5; i++) _textBlocks[i].Text = "";
            }
        }
        #endregion



        #region Letters_Buttons

        #region Btn_A_Click
        private void Btn_A_Click(object sender, RoutedEventArgs e)
        {
            Key_Sound.Play();
            Discovered discovered = new Discovered("A");
            discovered.Discovere_Letter(_canvas_game_words, _textBlocks, _images);
            Btn_A.IsEnabled = false;
        }
        #endregion

        #region Btn_B_Click
        private void Btn_B_Click(object sender, RoutedEventArgs e)
        {
            Key_Sound.Play();
            Discovered discovered = new Discovered("B");
            discovered.Discovere_Letter(_canvas_game_words, _textBlocks, _images);
            Btn_B.IsEnabled = false;
        }
        #endregion

        #region Btn_C_Click
        private void Btn_C_Click(object sender, RoutedEventArgs e)
        {
            Key_Sound.Play();
            Discovered discovered = new Discovered("C");
            discovered.Discovere_Letter(_canvas_game_words, _textBlocks, _images);
            Btn_C.IsEnabled = false;
        }
        #endregion

        #region Btn_D_Click
        private void Btn_D_Click(object sender, RoutedEventArgs e)
        {
            Key_Sound.Play();
            Discovered discovered = new Discovered("D");
            discovered.Discovere_Letter(_canvas_game_words, _textBlocks, _images);
            Btn_D.IsEnabled = false;
        }
        #endregion

        #region Btn_E_Click
        private void Btn_E_Click(object sender, RoutedEventArgs e)
        {
            Key_Sound.Play();
            Discovered discovered = new Discovered("E");
            discovered.Discovere_Letter(_canvas_game_words, _textBlocks, _images);
            Btn_E.IsEnabled = false;
        }
        #endregion

        #region Btn_F_Click
        private void Btn_F_Click(object sender, RoutedEventArgs e)
        {
            Key_Sound.Play();
            Discovered discovered = new Discovered("F");
            discovered.Discovere_Letter(_canvas_game_words, _textBlocks, _images);
            Btn_F.IsEnabled = false;
        }
        #endregion

        #region Btn_G_Click
        private void Btn_G_Click(object sender, RoutedEventArgs e)
        {
            Key_Sound.Play();
            Discovered discovered = new Discovered("G");
            discovered.Discovere_Letter(_canvas_game_words, _textBlocks, _images);
            Btn_G.IsEnabled = false;
        }
        #endregion

        #region Btn_H_Click
        private void Btn_H_Click(object sender, RoutedEventArgs e)
        {
            Key_Sound.Play();
            Discovered discovered = new Discovered("H");
            discovered.Discovere_Letter(_canvas_game_words, _textBlocks, _images);
            Btn_H.IsEnabled = false;
        }
        #endregion

        #region Btn_I_Click
        private void Btn_I_Click(object sender, RoutedEventArgs e)
        {
            Key_Sound.Play();
            Discovered discovered = new Discovered("I");
            discovered.Discovere_Letter(_canvas_game_words, _textBlocks, _images);
            Btn_I.IsEnabled = false;
        }
        #endregion

        #region Btn_J_Click
        private void Btn_J_Click(object sender, RoutedEventArgs e)
        {
            Key_Sound.Play();
            Discovered discovered = new Discovered("J");
            discovered.Discovere_Letter(_canvas_game_words, _textBlocks, _images);
            Btn_J.IsEnabled = false;
        }
        #endregion

        #region Btn_K_Click
        private void Btn_K_Click(object sender, RoutedEventArgs e)
        {
            Key_Sound.Play();
            Discovered discovered = new Discovered("K");
            discovered.Discovere_Letter(_canvas_game_words, _textBlocks, _images);
            Btn_K.IsEnabled = false;
        }
        #endregion

        #region Btn_L_Click
        private void Btn_L_Click(object sender, RoutedEventArgs e)
        {
            Key_Sound.Play();
            Discovered discovered = new Discovered("L");
            discovered.Discovere_Letter(_canvas_game_words, _textBlocks, _images);
            Btn_L.IsEnabled = false;
        }
        #endregion

        #region Btn_M_Click
        private void Btn_M_Click(object sender, RoutedEventArgs e)
        {
            Key_Sound.Play();
            Discovered discovered = new Discovered("M");
            discovered.Discovere_Letter(_canvas_game_words, _textBlocks, _images);
            Btn_M.IsEnabled = false;
        }
        #endregion

        #region Btn_N_Click
        private void Btn_N_Click(object sender, RoutedEventArgs e)
        {
            Key_Sound.Play();
            Discovered discovered = new Discovered("N");
            discovered.Discovere_Letter(_canvas_game_words, _textBlocks, _images);
            Btn_N.IsEnabled = false;
        }
        #endregion

        #region Btn_O_Click
        private void Btn_O_Click(object sender, RoutedEventArgs e)
        {
            Key_Sound.Play();
            Discovered discovered = new Discovered("O");
            discovered.Discovere_Letter(_canvas_game_words, _textBlocks, _images);
            Btn_O.IsEnabled = false;
        }
        #endregion

        #region Btn_P_Click
        private void Btn_P_Click(object sender, RoutedEventArgs e)
        {
            Key_Sound.Play();
            Discovered discovered = new Discovered("P");
            discovered.Discovere_Letter(_canvas_game_words, _textBlocks, _images);
            Btn_P.IsEnabled = false;
        }
        #endregion

        #region Btn_Q_Click
        private void Btn_Q_Click(object sender, RoutedEventArgs e)
        {
            Key_Sound.Play();
            Discovered discovered = new Discovered("Q");
            discovered.Discovere_Letter(_canvas_game_words, _textBlocks, _images);
            Btn_Q.IsEnabled = false;
        }
        #endregion

        #region Btn_R_Click
        private void Btn_R_Click(object sender, RoutedEventArgs e)
        {
            Key_Sound.Play();
            Discovered discovered = new Discovered("R");
            discovered.Discovere_Letter(_canvas_game_words, _textBlocks, _images);
            Btn_R.IsEnabled = false;
        }
        #endregion

        #region Btn_S_Click
        private void Btn_S_Click(object sender, RoutedEventArgs e)
        {
            Key_Sound.Play();
            Discovered discovered = new Discovered("S");
            discovered.Discovere_Letter(_canvas_game_words, _textBlocks, _images);
            Btn_S.IsEnabled = false;
        }
        #endregion

        #region Btn_T_Click
        private void Btn_T_Click(object sender, RoutedEventArgs e)
        {
            Key_Sound.Play();
            Discovered discovered = new Discovered("T");
            discovered.Discovere_Letter(_canvas_game_words, _textBlocks, _images);
            Btn_T.IsEnabled = false;
        }
        #endregion

        #region Btn_U_Click
        private void Btn_U_Click(object sender, RoutedEventArgs e)
        {
            Key_Sound.Play();
            Discovered discovered = new Discovered("U");
            discovered.Discovere_Letter(_canvas_game_words, _textBlocks, _images);
            Btn_U.IsEnabled = false;
        }
        #endregion

        #region Btn_V_Click
        private void Btn_V_Click(object sender, RoutedEventArgs e)
        {
            Key_Sound.Play();
            Discovered discovered = new Discovered("V");
            discovered.Discovere_Letter(_canvas_game_words, _textBlocks, _images);
            Btn_V.IsEnabled = false;
        }
        #endregion

        #region Btn_W_Click
        private void Btn_W_Click(object sender, RoutedEventArgs e)
        {
            Key_Sound.Play();
            Discovered discovered = new Discovered("W");
            discovered.Discovere_Letter(_canvas_game_words, _textBlocks, _images);
            Btn_W.IsEnabled = false;
        }
        #endregion

        #region Btn_X_Click
        private void Btn_X_Click(object sender, RoutedEventArgs e)
        {
            Key_Sound.Play();
            Discovered discovered = new Discovered("X");
            discovered.Discovere_Letter(_canvas_game_words, _textBlocks, _images);
            Btn_X.IsEnabled = false;
        }
        #endregion

        #region Btn_Y_Click
        private void Btn_Y_Click(object sender, RoutedEventArgs e)
        {
            Key_Sound.Play();
            Discovered discovered = new Discovered("Y");
            discovered.Discovere_Letter(_canvas_game_words, _textBlocks, _images);
            Btn_Y.IsEnabled = false;
        }
        #endregion

        #region Btn_Z_Click
        private void Btn_Z_Click(object sender, RoutedEventArgs e)
        {
            Key_Sound.Play();
            Discovered discovered = new Discovered("Z");
            discovered.Discovere_Letter(_canvas_game_words, _textBlocks, _images);
            Btn_Z.IsEnabled = false;
        }
        #endregion 

        #endregion
    }
}


