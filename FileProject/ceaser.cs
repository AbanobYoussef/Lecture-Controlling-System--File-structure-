using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProject
{
    class ceaser
    {
        public static string Cipher(string OriginalText, int Shift)
        {
            char[] originalTextArr = OriginalText.ToCharArray();
            int FirstCharIdx = 'a';
            int Offset = ('z' - 'a') + 1; // number of letters in alphabet

            for (int i = 0; i < originalTextArr.Length; i++)
            {
                char OldCharIdx = originalTextArr[i];
                int OldIdxInAlphabet = OldCharIdx - FirstCharIdx;
                int NewIdxInAlphabet = (OldIdxInAlphabet + Shift) % Offset;

                char NewCharIdx = (char)(FirstCharIdx + NewIdxInAlphabet);
                originalTextArr[i] = NewCharIdx;
            }

            return new string(originalTextArr);
        }

        public static string Decipher(string CipheredText, int Shift)
        {
            return Cipher(CipheredText, Shift * -1);
        }

    }
}
