using System;

namespace SmallsOnline.IntuneLAPS.Client.Models.PasswordGenerator
{
    /// <summary>
    /// Houses data for a specific UTF32 decimal code's character.
    /// </summary>
    public class CharacterItem
    {       
        public CharacterItem(int utf32Code)
        {
            Utf32Code = utf32Code;
        }

        /// <summary>
        /// The UTF32 decimal code for a character.
        /// </summary>
        public int Utf32Code { get; }

        /// <summary>
        /// The character in a string format.
        /// </summary>
        public char Character
        {
            get
            {
                return Convert.ToChar(char.ConvertFromUtf32(Utf32Code));
            }
        }

        public override string ToString()
        {
            return Character.ToString();
        }
    }
}