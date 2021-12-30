using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWords.classes
{
    class Words
    {
       private static int      _hard_word;
       private static int      _easy_word;
       private static string[] _easy_Words = { "RUG", "BOG", "HAT", "SEA", "JOY", "BOY", "SUN", "SKY", "MAP" };
       private static string[] _hard_Words = { "STARS", "TABLE", "BREAD", "WOMAN", "DRESS", "TOWEL", "HOUSE", "MOUTH", "CHAIR" };



        #region Easy_Words
        public static string Easy_Words()
        {
            if (_easy_word == 8) _easy_word = 0;
            return _easy_Words[_easy_word++];
        }
        #endregion

        #region Hard_Words
        public static string Hard_Words()
        {
            if (_hard_word == 8) _hard_word = 0;
            return _hard_Words[_hard_word++];
        } 
        #endregion
    }
}