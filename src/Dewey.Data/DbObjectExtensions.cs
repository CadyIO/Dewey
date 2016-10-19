using System;

namespace Dewey.Data
{
    /// <summary>
    /// Extension methods for DbObject type
    /// </summary>
    public static class DbObjectExtensions
    {
        /// <summary>
        /// Get a string from a db object
        /// </summary>
        /// <param name="o">Tne object to convert</param>
        /// <returns>The string value of the db object</returns>
        public static string GetString(this object o)
        {
            if (Convert.IsDBNull(o)) {
                return null;
            }

            return (string)o;
        }

        /// <summary>
        /// Get an int from a db object
        /// </summary>
        /// <param name="o">Tne object to convert</param>
        /// <returns>The int value of the db object</returns>
        public static int GetInt(this object o)
        {
            if (Convert.IsDBNull(o) || o == null) {
                return 0;
            }

            return (int)o;
        }
    }
}
