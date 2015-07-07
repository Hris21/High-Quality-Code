namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Static class providing various extension methods for the <see cref="T:System.String"/> class.
    /// </summary>
    public static class StringExtensions
    {
        static void Main()
        {

            // Feel free to test any of the extensions here  .

        }

        /// <summary>
        /// Converts the input string to a byte array then recreates the string and formats each byte to a hexadecimal string.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>Hexadecimal string.</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Finds wheter the input is any of the true/positive values in the hardcoded array, such as 'yes','true',1 end etc..,
        /// It is advisable the input to be in lowe case, however, if not .ToLower() is used to make sure of that.
        /// </summary>
        /// <param name="input">A true value in string format.</param>
        /// <returns>true or false depending on where the value is contained.</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Tries to convert the string input to short datatype.
        /// </summary>
        /// <param name="input">The input is advisable to be a number in string format.</param>
        /// <returns>If the input is a number it's value will be assigned to shortValue, otherwise it returns 0 .</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Tries to convert the string input to integer datatype.
        /// </summary>
        /// <param name="input">The input is advisable to be a number in string format.</param>
        /// <returns>If the input is a number it's value will be assigned to integerValue, otherwise it returns 0 .</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }


        /// <summary>
        /// Tries to convert the string input to long datatype.
        /// </summary>
        /// <param name="input">The input is advisable to be a number in string format.</param>
        /// <returns>If the input is a number it's value will be assigned to longValue, otherwise it returns 0 .</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Tries to convert the string input to DateTime format.
        /// NB! Keep in mind that the the input should be in format dd.mm.yy the mounth must always be in the middle otherwise it won't work.
        /// </summary>
        /// <param name="input">The input is advisable to follow the date conventions.</param>
        /// <returns>If the input is correct date , otherwise it returns a blank date 1.1.0001 </returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Capitalizes the first letter of a string, if the string is letters.
        /// </summary>
        /// <param name="input">The input string should be a word or a letter if it is a number, nothing would happen.</param>
        /// <returns>Nothing if the string is null or empty, otherwise the first letter capitalized.</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Gives/Cuts the containing text between two words first of which is the start and the second end given (excluding the words).
        /// </summary>
        /// <param name="input">A text, sentence or combination of words.</param>
        /// <param name="startString">The word/char used as starting point.</param>
        /// <param name="endString">The word/char used as finishing point.</param>
        /// <param name="startFrom">The index from which the cutting starts.</param>
        /// <returns>The formatted substring.</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;

            // If the startString or endString are not contained in the input empty string is returned.

            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            // StringComparison.Ordinal is used as it is the fastest.However it is not always realiabe, for example : 
            // var s1 = "Strasse";
            // var s2 = "Straße";
            // s1.Equals(s2, StringComparison.Ordinal);           // false
            // s1.Equals(s2, StringComparison.InvariantCulture);  // true

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts cyrillic letters to their latin representation.
        /// </summary>
        /// <param name="input">String datatype , must be in cyrilic.</param>
        /// <returns>The latin representation of the input.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts latin letters to their cyrilic representation.
        /// </summary>
        /// <param name="input">String datatype , must be in latin.</param>
        /// <returns>The cyrilic representation of the input.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Corrects username, by leaving only letters and numbers, removing special symbols
        /// also converts it to latin if it is in cyrilic.
        /// </summary>
        /// <param name="input">The username to validate.</param>
        /// <returns>The username removing special symbols.</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Corrects filename, by leaving only letters and numbers, removing special symbols and whitespaces
        /// also converts it to latin if it is in cyrilic.
        /// </summary>
        /// <param name="input">The filename to validate.</param>
        /// <returns>The filename removing special symbols.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Gets the desired number of characters in a word/text starting from the first (index = 0), including whitespaces.
        /// </summary>
        /// <param name="input">The string.</param>
        /// <param name="charsCount">The number of characters.</param>
        /// <returns>The desired number of characters.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Gets the extension of the file, for example : exe,sln,cs, etc.. 
        /// </summary>
        /// <param name="fileName">The full name of the file.</param>
        /// <returns>File`s extension.</returns>
        public static string GetFileExtension(this string fileName)
        {
            // If not filename is entered it returns an empty string, instead of throwing an Error.
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// String extension method which returns the content type of a file determined by its extension.
        /// </summary>
        /// <param name="fileExtension">The extension of a filename represented as a string on which the method is invoked.</param>
        /// <returns>Returns the content type if known, "application/octet-stream" - otherwise.</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts the input string to a byte array.
        /// </summary>
        /// <param name="input">The string on which the method to be invoked.</param>
        /// <returns>Returns a byte array of the input string</returns>

        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
