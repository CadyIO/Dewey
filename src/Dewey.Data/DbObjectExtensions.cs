using System;

namespace Dewey.Data
{
    public static class DbObjectExtensions
    {
        public static string GetString(this object o)
        {
            if (Convert.IsDBNull(o)) {
                return null;
            }

            return (string)o;
        }

        public static int GetInt(this object o)
        {
            if (Convert.IsDBNull(o) || o == null) {
                return 0;
            }

            return (int)o;
        }
    }
}
