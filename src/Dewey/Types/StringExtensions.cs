using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Dewey.Types
{
    /// <summary>
    /// Extension methods for String type
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Remove a length from the end of a string
        /// </summary>
        /// <param name="value">The string value</param>
        /// <param name="len">The length to remove</param>
        /// <returns>The resulting string after length removed</returns>
        public static string Chomp(this string value, int len)
        {
            if (value == null) {
                return value;
            }
            
            if (value.Length <= len) {
                return value;
            }

            return value.Substring(0, value.Length - len);
        }

        /// <summary>
        /// Convert a string to a nullable Guid
        /// </summary>
        /// <param name="guid">The Guid string to convert</param>
        /// <returns>A nullable Guid</returns>
        public static Guid? ToNullableGuid(this string guid) => (guid.IsEmpty()) ? null : (Guid?)(new Guid(guid));

        /// <summary>
        /// Convert a string to a Guid
        /// </summary>
        /// <param name="guid">The Guid string to convert</param>
        /// <returns>A Guid</returns>
        public static Guid ToGuid(this string guid)
        {
            if (guid.IsEmpty()) {
                throw new ArgumentNullException(nameof(guid));
            }

            return new Guid(guid);
        }

        /// <summary>
        /// Get the digits in a string
        /// </summary>
        /// <remarks>Helpful for stripping a phone number or social security number of extra characters</remarks>
        /// <param name="value">The string value from which to get the difits</param>
        /// <returns>A string of the digits</returns>
        public static string Digits(this string value) => new string(value?.Where(c => c >= '0' && c <= '9').ToArray());

        public static bool IsEmpty(this string value) => string.IsNullOrWhiteSpace(value);

        public static bool IsNotEmpty(this string value) => !value.IsEmpty();

        public static T Default<T>(this T value, T defaultValue = default(T)) => (value.IsBlank()) ? defaultValue : value;

        public static string Between(this string value, char from, char to)
        {
            var result = string.Empty;
            bool read = false;
            bool stopped = false;

            foreach (var c in value.ToArray()) {
                if ((from != to && !read && c == to) || (read && c == to)) {
                    stopped = true;
                    break;
                }

                if (read) {
                    result += c;
                }

                if (c == from) {
                    read = true;
                }
            }

            // from and to were found
            if (read && stopped) {
                return result;
            }

            return string.Empty;
        }

        public static string ToPascal(this string value)
        {
            // Probably a constant value
            if (value.Contains("_") || value.IsAllUpper()) {
                value = value.ToLower();
                string[] parts = value.Split('_');
                var result = string.Empty;

                foreach (var part in parts) {
                    result += part.ToPascal();
                }

                return result;
            }

            return value.Capitalize();
        }

        public static bool IsAllUpper(this string value)
        {
            for (int i = 0; i < value.Length; i++) {
                if (char.IsLetter(value[i]) && !char.IsUpper(value[i]))
                    return false;
            }

            return true;
        }

        public static string Capitalize(this string value) => char.ToUpper(value[0]) + value.Substring(1);

        public static string AsDisplayName(this string value)
        {
            var result = string.Empty;

            foreach (string s in value.SplitOnUpper()) {
                result += s + " ";
            }

            return result.Trim();
        }

        public static string[] SplitOnUpper(this string value)
        {
            var result = new List<string>();
            var s = string.Empty;

            foreach (var c in value.ToList()) {
                if (char.IsLetter(c) && char.IsUpper(c)) {
                    if (s.IsNotEmpty()) {
                        result.Add(s);
                    }

                    s = string.Empty;
                }

                s += c;
            }

            result.Add(s);

            return result.ToArray();
        }

        public static string Minify(this string value)
        {
            var lines = value.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            var result = new StringBuilder();

            foreach (var line in lines) {
                var trimLine = line.Trim();

                result.Append(trimLine);
            }

            return result.ToString();
        }

        public static string ToMinifiedString(this StringBuilder value)
        {
            var valueText = value.ToString();

            var lines = valueText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            var result = new StringBuilder();

            foreach (var line in lines) {
                var trimLine = line.Trim();

                result.Append(trimLine);
            }

            return result.ToString();
        }

        public static string ToEllipsisString(this string value, int count = 10)
        {
            return (value.Length < count) ? value : string.Concat(value.Substring(0, count - 1), "...");
        }

        public static bool IsValidEmail(this string emailAddress)
        {
            var valid = Regex.IsMatch(emailAddress.Trim(), @"\A(?:[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?)\Z");

            return valid;
        }

        public static string SanitizeFileName(this string value)
        {
            var invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            var invalidRegStr = string.Format(@"([{0}]*.+$)|([{0}]+)", invalidChars);

            return Regex.Replace(value, invalidRegStr, "_");
        }

        public static string EscapeStringForCsv(this string value)
        {
            if (value == null) {
                return null;
            }

            var result = value.Replace("\"", "\"\"");

            if (result.Contains(",")) {
                result = "\"" + result + "\"";
            }

            return result;
        }

        private static readonly List<char> InvalidCharacters = new List<char> {
            '%', '&', '^', '*', '@', '[', ']', '(', ')', '!'
        };

        public static string Sanitize(this string value)
        {
            InvalidCharacters.ForEach(c => value.Replace(c, ' '));

            return value;
        }
    }
}
