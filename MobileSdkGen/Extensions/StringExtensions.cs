using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MobileSdkGen.Extensions
{
    static class StringExtensions
    {
        public static string SaneReplace(this string input, string oldValue, string newValue, IReservedWordProvider wordProvider)
        {
            foreach (var word in wordProvider.ReservedWords)
            {
                var regex = new Regex("\b" + word + "\b");
                newValue = regex.Replace(newValue, "__" + word + "__");
            }

            foreach (var character in wordProvider.ControlChars)
            {
                newValue = newValue.Replace(character.ToString(), "__" + CharUnicodeInfo.GetDecimalDigitValue(character).ToString());
            }

            return input.Replace(oldValue, newValue);
        }
    }

    interface IReservedWordProvider
    {
        IEnumerable<string> ReservedWords { get; }
        IEnumerable<char> ControlChars { get; }
    }
}
